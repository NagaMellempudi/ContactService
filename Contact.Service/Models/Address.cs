using System;
namespace Contact.Service.Models
{
    public class Address : IAddress
    {
        public Address()
        {
        }

        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
    }
}
