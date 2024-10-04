using System;

/// <summary>
/// Basisklasse für Personen, die Vor- und Nachnamen enthält.
/// </summary>
public abstract class Person
{
    private string _firstName;
    private string _lastName;

    /// <summary>
    /// Vorname der Person
    /// </summary>
    public string FirstName
    {
        get => _firstName;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Der Vorname darf nicht leer sein.");
            }
            _firstName = value;
        }
    }

    /// <summary>
    /// Nachname der Person
    /// </summary>
    public string LastName
    {
        get => _lastName;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Der Nachname darf nicht leer sein.");
            }
            _lastName = value;
        }
    }

    // Konstruktor
    protected Person(string firstName, string lastName)
    {
        FirstName = firstName; 
        LastName = lastName;   
    }

    /// <summary>
    /// Abstrakte Methode, die in abgeleiteten Klassen implementiert werden muss.
    /// </summary>
    /// <returns>String mit den Informationen der Person.</returns>
    public abstract string DisplayInfo();
}
