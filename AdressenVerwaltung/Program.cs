using System;

class Program
{
    static void Main(string[] args)
    {
        AddressManager manager = new AddressManager();
        bool running = true;

        while (running)
        {
            Console.WriteLine("Wählen Sie eine Option:");
            Console.WriteLine("1. Adresse hinzufügen");
            Console.WriteLine("2. Adresse suchen");
            Console.WriteLine("3. Adresse aktualisieren");
            Console.WriteLine("4. Adresse entfernen");
            Console.WriteLine("5. Alle Adressen anzeigen");
            Console.WriteLine("6. Beenden");
            Console.Write("Ihre Auswahl: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddNewAddress(manager);
                    break;

                case "2":
                    SearchAddress(manager);
                    break;

                case "3":
                    UpdateAddress(manager);
                    break;

                case "4":
                    RemoveAddress(manager);
                    break;

                case "5":
                    manager.ShowAddress();
                    break;

                case "6":
                    running = false;
                    break;

                default:
                    Console.WriteLine("Ungültige Auswahl, bitte versuchen Sie es erneut.");
                    break;
            }
        }
    }

    private static void AddNewAddress(AddressManager manager)
    {
        try
        {
            Console.Write("Vorname: ");
            string firstName = Console.ReadLine();
            Console.Write("Nachname: ");
            string lastName = Console.ReadLine();
            Console.Write("Straße: ");
            string street = Console.ReadLine();
            Console.Write("Stadt: ");
            string city = Console.ReadLine();
            Console.Write("Postleitzahl: ");
            string postalCode = Console.ReadLine();
            Console.Write("Telefonnummer: ");
            string phoneNumber = Console.ReadLine();

            Address address = new Address(firstName, lastName, street, city, postalCode, phoneNumber);
            manager.AddAddress(address);
            Console.WriteLine("Adresse erfolgreich hinzugefügt.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Fehler: {ex.Message}");
        }
    }

    private static void SearchAddress(AddressManager manager)
    {
        Console.WriteLine("Wählen Sie die Suchkategorie:");
        Console.WriteLine("1. Nach Name suchen");
        Console.WriteLine("2. Nach Straße suchen");
        Console.WriteLine("3. Nach Stadt suchen");
        Console.WriteLine("4. Nach Telefonnummer suchen");
        Console.Write("Ihre Auswahl: ");

        string choice = Console.ReadLine();
        Address foundAddress = null;

        switch (choice)
        {
            case "1":
                Console.Write("Geben Sie den Namen (Vorname Nachname) ein: ");
                string fullName = Console.ReadLine();
                string[] nameParts = fullName.Split(' ');
                string firstName = nameParts.Length > 0 ? nameParts[0] : string.Empty;
                string lastName = nameParts.Length > 1 ? nameParts[1] : string.Empty;

                foundAddress = manager.SearchAddressByName(firstName, lastName);
                break;

            case "2":
                Console.Write("Geben Sie die Straße ein: ");
                string street = Console.ReadLine();
                foundAddress = manager.SearchAddressByStreet(street);
                break;

            case "3":
                Console.Write("Geben Sie die Stadt ein: ");
                string city = Console.ReadLine();
                foundAddress = manager.SearchAddressByCity(city);
                break;

            case "4":
                Console.Write("Geben Sie die Telefonnummer ein: ");
                string phoneNumber = Console.ReadLine();
                foundAddress = manager.SearchAddress(phoneNumber);
                break;

            default:
                Console.WriteLine("Ungültige Auswahl.");
                return;
        }

        if (foundAddress != null)
        {
            Console.WriteLine(foundAddress.DisplayInfo());
        }
        else
        {
            Console.WriteLine("Keine Adresse gefunden.");
        }
    }


    private static void UpdateAddress(AddressManager manager)
    {
        Console.Write("Geben Sie die Telefonnummer der Adresse ein, die Sie aktualisieren möchten: ");
        string phoneNumber = Console.ReadLine();

        var existingAddress = manager.SearchAddress(phoneNumber);

        if (existingAddress != null)
        {
            Console.Write($"Neuer Vorname (aktuell: {existingAddress.FirstName}): ");
            string newFirstName = Console.ReadLine();
            newFirstName = string.IsNullOrWhiteSpace(newFirstName) ? existingAddress.FirstName : newFirstName;

            Console.Write($"Neuer Nachname (aktuell: {existingAddress.LastName}): ");
            string newLastName = Console.ReadLine();
            newLastName = string.IsNullOrWhiteSpace(newLastName) ? existingAddress.LastName : newLastName;

            Console.Write($"Neue Straße (aktuell: {existingAddress.Street}): ");
            string newStreet = Console.ReadLine();
            newStreet = string.IsNullOrWhiteSpace(newStreet) ? existingAddress.Street : newStreet;

            Console.Write($"Neue Stadt (aktuell: {existingAddress.City}): ");
            string newCity = Console.ReadLine();
            newCity = string.IsNullOrWhiteSpace(newCity) ? existingAddress.City : newCity;

            Console.Write($"Neue Postleitzahl (aktuell: {existingAddress.PostalCode}): ");
            string newPostalCode = Console.ReadLine();
            newPostalCode = string.IsNullOrWhiteSpace(newPostalCode) ? existingAddress.PostalCode : newPostalCode;

            Console.Write($"Neue Telefonnummer (aktuell: {existingAddress.PhoneNumber}): ");
            string newPhoneNumber = Console.ReadLine();
            newPhoneNumber = string.IsNullOrWhiteSpace(newPhoneNumber) ? existingAddress.PhoneNumber : newPhoneNumber;

            Address newAddress = new Address(newFirstName, newLastName, newStreet, newCity, newPostalCode, newPhoneNumber);
            try
            {
                manager.UpdateAddress(phoneNumber, newAddress);
                Console.WriteLine("Adresse erfolgreich aktualisiert.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fehler: {ex.Message}");
            }
        }
        else
        {
            Console.WriteLine("Keine Adresse gefunden.");
        }
    }


    private static void RemoveAddress(AddressManager manager)
    {
        manager.ShowAddress();
        Console.Write("Geben Sie die Telefonnummer der zu entfernenden Adresse ein: ");
        string phoneNumber = Console.ReadLine();

        try
        {
            manager.RemoveAddress(phoneNumber);
            Console.WriteLine("Adresse erfolgreich entfernt.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Fehler: {ex.Message}");
        }
    }
}
