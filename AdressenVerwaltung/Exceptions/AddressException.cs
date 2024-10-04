using System;

namespace AddressBook.Exceptions
{
    public class AddressException : Exception
    {
        public AddressException(string message) : base(message) { }
    }
}
