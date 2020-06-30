using System;
using System.ComponentModel.DataAnnotations;

namespace Contact.Service.Models
{

    public class Contact : IContact
    {
        public Contact()
        {
        }
        [Required(ErrorMessage ="Name is required")]
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(75)]
        public string Company { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [MaxLength(100)]
        public string Email { get; set; }
        [MaxLength(10)]
        public string WorkPhoneNumber { get; set; }
        public string PersonalPhoneNumber { get; set; }
        public Address Address { get; set; }
        public string ProfileImageUrl { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
