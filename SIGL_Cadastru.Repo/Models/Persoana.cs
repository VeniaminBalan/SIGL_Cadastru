﻿using Contracts;
using SIGL_Cadastru.Repo.Contracts;
using SIGL_Cadastru.Repo.Exceptions.PersonException;
using System.Text.RegularExpressions;

namespace SIGL_Cadastru.Repo.Models;

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

    public void SetNume(string nume) 
    {
        if (string.IsNullOrWhiteSpace(nume))
            throw new Exception("Numele nu poate fi gol");

        Nume = nume;
    }
    public void SetPrenume(string prenume)
    {
        if (string.IsNullOrWhiteSpace(prenume))
            throw new Exception("Prenumele nu poate fi gol");

        Prenume = prenume;
    }
    public async Task SetIDNP(IPersoanaRepository repo ,string iDNP)
    {
        if (!await repo.isIdnpUniqe(iDNP))
            throw new IDNPUsedException("O persoana cu acest IDNP este deja inregistrata");

        if (string.IsNullOrWhiteSpace(iDNP))
            throw new Exception("IDNP-ul nu poate fi gol");

        IDNP = iDNP;
    }
    public void SetDomiciliu(string domiciliu) 
    {
        if (string.IsNullOrEmpty(domiciliu))
            throw new Exception("Domiciliu nu poate fi gol");

        Domiciliu = domiciliu;
    }
    public void SetDataNasterii(DateOnly date) 
    {
        DataNasterii= date;
    }
    public void SetEmail(string email) 
    {
        if (!string.IsNullOrWhiteSpace(email))
        {
            if (!IsEmailValid(email))
                throw new InvalidEmailException($"Email-ul: {email} nu corespunde unui format corect");
        }

        Email = email;
    }
    public void SetTelefon(string telefon) 
    {
        Telefon = telefon;
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
            throw new Exception("Indicati numele persoanei");

        if (string.IsNullOrWhiteSpace(prenume))
            throw new Exception("Indicati prenumele persoanei");

        if (string.IsNullOrWhiteSpace(domiciliu))
            throw new Exception("Indicati domiciliu persoanei");
               
        if (string.IsNullOrWhiteSpace(iDNP))
            throw new Exception("Indicati IDNP-ul persoanei");

        if (!await repo.isIdnpUniqe(iDNP))
            throw new IDNPUsedException("O persoana cu acest IDNP este deja inregistrata");

        if (!string.IsNullOrWhiteSpace(email))
        {
            if (!IsEmailValid(email))
                throw new InvalidEmailException($"Email-ul: {email} nu corespunde unui format corect");
        }

        return new Persoana 
        {
            Id = id,
            Nume= nume.Trim(),
            Prenume= prenume.Trim(),
            IDNP = iDNP.Trim(),
            DataNasterii= dataNasterii,
            Domiciliu= domiciliu.Trim(),
            Email = email?.Trim(),
            Telefon= telefon?.Trim(),
            Rol= rol
        };
    }

    public static bool IsEmailValid(string email)
    {
        string regex = @"^[^@\s]+@[^@\s]+\.(com|net|org|gov|ru)$";

        return Regex.IsMatch(email, regex, RegexOptions.IgnoreCase);
    }

    public override string? ToString()
    {
        return $"Nume: {Nume}, Prenume: {Prenume}, IDNP: {IDNP}";
    }
}
