

namespace Addressbook.Interfaces
{
    /// <summary>
    /// Definiert die grundlegenden Operationen zur Verwaltung eines Adressbuchs.
    /// Dieses Interface stellt Methoden bereit, um Adressen hinzuzufügen, zu entfernen, zu suchen, zu aktualisieren und anzuzeigen.
    /// </summary>
    public interface IAddressbook
    {
        /// <summary>
        /// Fügt eine neue Adresse zum Adressbuch hinzu.
        /// </summary>
        /// <param name="address">Die hinzuzufügende Adresse, die Kontaktdaten enthält.</param>
        void AddAddress(Address address);

        /// <summary>
        /// Entfernt eine Adresse aus dem Adressbuch anhand der angegebenen Telefonnummer.
        /// </summary>
        /// <param name="phoneNumber">Die Telefonnummer der zu entfernenden Adresse.</param>
        void RemoveAddress(string phoneNumber);

        /// <summary>
        /// Sucht eine Adresse im Adressbuch anhand der Telefonnummer.
        /// </summary>
        /// <param name="phoneNumber">Die Telefonnummer, die der gesuchten Adresse zugeordnet ist.</param>
        /// <returns>
        /// Die Adresse, die zur angegebenen Telefonnummer passt;
        /// gibt <c>null</c> zurück, falls kein Treffer gefunden wird.
        /// </returns>
        Address SearchAddress(string phoneNumber);

        /// <summary>
        /// Aktualisiert die Details einer bestehenden Adresse im Adressbuch.
        /// </summary>
        /// <param name="phoneNumber">Die Telefonnummer der zu aktualisierenden Adresse.</param>
        /// <param name="newAddress">Die neuen Adressdetails.</param>
        void UpdateAddress(string phoneNumber, Address newAddress);

        /// <summary>
        /// Zeigt die Details aller Adressen im Adressbuch an.
        /// </summary>
        void ShowAddress();
    }
}
