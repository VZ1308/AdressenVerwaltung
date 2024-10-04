using System;
using System.Text.RegularExpressions;

/// <summary>
/// Klasse zur Darstellung einer Adresse, erbt von Person und implementiert IContact.
/// </summary>
public class Address : Person, IContact
{
    private string _street;
    private string _city;
    private string _postalCode;
    private string _phoneNumber;

    /// <summary>
    /// Straße der Adresse
    /// </summary>
    public string Street
    {
        get => _street;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Die Straße darf nicht leer sein.");
            }
            _street = value;
        }
    }

    /// <summary>
    /// Stadt der Adresse
    /// </summary>
    public string City
    {
        get => _city;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Die Stadt darf nicht leer sein.");
            }
            _city = value;
        }
    }

    /// <summary>
    /// Postleitzahl der Adresse
    /// </summary>
    public string PostalCode
    {
        get => _postalCode;
        set
        {
            if (!Regex.IsMatch(value, @"^\d{4}$"))
            {
                throw new ArgumentException("Die Postleitzahl muss genau 4 Ziffern enthalten.");
            }
            _postalCode = value;
        }
    }

    /// <summary>
    /// Telefonnummer der Adresse
    /// </summary>
    public string PhoneNumber
    {
        get => _phoneNumber;
        set
        {
            if (!Regex.IsMatch(value, @"^\+?[0-9]{10,15}$"))
            {
                throw new ArgumentException("Die Telefonnummer muss zwischen 10 und 15 Ziffern enthalten und kann mit + beginnen.");
            }
            _phoneNumber = value;
        }
    }

    // Konstruktor
    public Address(string firstName, string lastName, string street, string city, string postalCode, string phoneNumber)
        : base(firstName, lastName)
    {
        Street = street;
        City = city;
        PostalCode = postalCode;
        PhoneNumber = phoneNumber;
    }

    /// <summary>
    /// Gibt die Adressinformationen als String zurück.
    /// </summary>
    /// <returns>String mit den Adressinformationen.</returns>
    public override string DisplayInfo()
    {
        return $"Name: {FirstName} {LastName}\n" +
               $"Adresse: {Street}, {PostalCode} {City}\n" +
               $"Telefonnummer: {PhoneNumber}";
    }
}
