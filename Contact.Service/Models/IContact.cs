using System;
namespace Contact.Service.Models
{
    public interface IContact
    {
        public string Name { get; set; }
        public string Company { get; set; }
        public Address Address { get; set; }
        public string Email { get; set; }
        public string WorkPhoneNumber { get; set; }
        public string PersonalPhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string ProfileImageUrl { get; set; }
    }
}
