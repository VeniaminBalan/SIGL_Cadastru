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
        public Guid Id { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public string IDNP { get; set; }
        public DateOnly DataNasterii { get; set; }
        public string Domiciliu { get; set; }
        public string? Email { get; set; }
        public string? Telefon { get; set; }
        public Role Rol { get; set; }

        internal Persoana() { }
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


            return new Persoana(id, nume, prenume, iDNP, dataNasterii, domiciliu, email, telefon, rol);
        }

        public static bool IsEmailValid(string email)
        {
            string regex = @"^[^@\s]+@[^@\s]+\.(com|net|org|gov|ru)$";

            return Regex.IsMatch(email, regex, RegexOptions.IgnoreCase);
        }

    }

}
