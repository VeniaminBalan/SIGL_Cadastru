using Contracts;
using Exceptions;
using SIGL_Cadastru.Repo.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SIGL_Cadastru.Repo.Models
{
    public enum Role
    {
        Client,
        Executant,
        Responsabil
    }
    public class Persoana : IModel
    {
        public Guid Id { get; private set; }
        public string Nume { get; private set; }
        public string Prenume { get; private set; }
        public string IDNP { get; private set; }
        public DateOnly DataNasterii { get; private set; }
        public string Domiciliu { get; private set; }
        public string? Email { get; private set; }
        public string? Telefon { get; private set; }
        public Role Rol { get; private set; }

        private Persoana() 
        {

        }

        internal Persoana(Guid id, string nume, string prenume, string iDNP, DateOnly dataNasterii, string domiciliu, string? email, string? telefon, Role rol)
        {
            Id = id;
            Nume = nume;
            Prenume = prenume;
            IDNP = iDNP;
            DataNasterii = dataNasterii;
            Domiciliu = domiciliu;
            Email = email;
            Telefon = telefon;
            Rol = rol;
        }

        public static async Task<Persoana> Create(
            Guid id,
            string nume,
            string prenume,
            string iDNP,
            DateOnly dataNasterii,
            string domiciliu,
            string? email,
            string? telefon,
            Role rol,
            IPersoanaRepository repo)
        {
            if (string.IsNullOrWhiteSpace(nume))
                throw new Exception("nume is null");

            if (string.IsNullOrWhiteSpace(prenume))
                throw new Exception("prenume is null");

            if (string.IsNullOrWhiteSpace(domiciliu))
                throw new Exception("domiciliu is null");
                   

            if (string.IsNullOrWhiteSpace(iDNP))
                throw new Exception("IDNP is null");

            if (!await repo.isIdnpUniqe(iDNP))
                throw new IDNPUsedException("this IDNP is already used");

            if (!string.IsNullOrWhiteSpace(email))
            {
                if (!IsEmailValid(email))
                    throw new InvalidEmailException($"this Email: {email} is invalid");
            }

            return new Persoana 
            {
                Id = id,
                Nume= nume,
                Prenume= prenume,
                IDNP = iDNP,
                DataNasterii= dataNasterii,
                Domiciliu= domiciliu,
                Email = email,
                Telefon= telefon,
                Rol= rol
            };
        }

        public static bool IsEmailValid(string email)
        {
            string regex = @"^[^@\s]+@[^@\s]+\.(com|net|org|gov|ru)$";

            return Regex.IsMatch(email, regex, RegexOptions.IgnoreCase);
        }

    }

}
