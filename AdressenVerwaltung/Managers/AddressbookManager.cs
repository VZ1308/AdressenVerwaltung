using Addressbook.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Implementiert das IAddressbook-Interface und verwaltet eine Liste von Adressen.
/// </summary>
public class AddressManager : IAddressbook
{
    private List<Address> addresses = new List<Address>();

    /// <summary>
    /// Fügt eine Adresse zur Liste hinzu.
    /// </summary>
    /// <param name="address">Die hinzuzufügende Adresse.</param>
    public void AddAddress(Address address)
    {
        // Überprüfen, ob die Adresse bereits existiert
        if (addresses.Any(a => a.PhoneNumber == address.PhoneNumber))
        {
            throw new Exception("Adresse mit dieser Telefonnummer existiert bereits.");
        }
        addresses.Add(address);
    }

    /// <summary>
    /// Entfernt eine Adresse anhand der Telefonnummer.
    /// </summary>
    /// <param name="phoneNumber">Die Telefonnummer der zu entfernenden Adresse.</param>
    public void RemoveAddress(string phoneNumber)
    {
        var addressToRemove = addresses.FirstOrDefault(a => a.PhoneNumber == phoneNumber);
        if (addressToRemove != null)
        {
            addresses.Remove(addressToRemove);
        }
        else
        {
            throw new Exception("Keine Adresse mit dieser Telefonnummer gefunden.");
        }
    }

    /// <summary>
    /// Sucht eine Adresse anhand der Telefonnummer.
    /// </summary>
    /// <param name="phoneNumber">Die Telefonnummer der gesuchten Adresse.</param>
    /// <returns>Die gefundene Adresse oder null, wenn keine gefunden wurde.</returns>
    public Address SearchAddress(string phoneNumber)
    {
        return addresses.FirstOrDefault(a => a.PhoneNumber == phoneNumber);
    }

    /// <summary>
    /// Aktualisiert eine Adresse.
    /// </summary>
    /// <param name="phoneNumber">Die Telefonnummer der Adresse, die aktualisiert werden soll.</param>
    /// <param name="newAddress">Die neuen Adressdetails.</param>
    public void UpdateAddress(string phoneNumber, Address newAddress)
    {
        var existingAddress = addresses.FirstOrDefault(a => a.PhoneNumber == phoneNumber);
        if (existingAddress != null)
        {
            existingAddress.FirstName = newAddress.FirstName;
            existingAddress.LastName = newAddress.LastName;
            existingAddress.Street = newAddress.Street;
            existingAddress.City = newAddress.City;
            existingAddress.PostalCode = newAddress.PostalCode;
            existingAddress.PhoneNumber = newAddress.PhoneNumber;
        }
        else
        {
            throw new Exception("Keine Adresse mit dieser Telefonnummer gefunden.");
        }
    }

    /// <summary>
    /// Zeigt alle Adressen an.
    /// </summary>
    public void ShowAddress()
    {
        foreach (var address in addresses)
        {
            Console.WriteLine(address.DisplayInfo());
            Console.WriteLine("---------------------------------------------------");
        }
    }
    // Neue Suchmethoden
    public Address SearchAddressByName(string firstName, string lastName)
    {
        return addresses.FirstOrDefault(a =>
            a.FirstName.Equals(firstName, StringComparison.OrdinalIgnoreCase) &&
            a.LastName.Equals(lastName, StringComparison.OrdinalIgnoreCase));
    }

    public Address SearchAddressByStreet(string street)
    {
        return addresses.FirstOrDefault(a =>
            a.Street.Equals(street, StringComparison.OrdinalIgnoreCase));
    }

    public Address SearchAddressByCity(string city)
    {
        return addresses.FirstOrDefault(a =>
            a.City.Equals(city, StringComparison.OrdinalIgnoreCase));
    }
}


