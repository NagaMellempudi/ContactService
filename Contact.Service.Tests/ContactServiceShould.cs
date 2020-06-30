using System;
using Xunit;
using Contact.Service.Models;
using Contact.Service.Services;
using Contact.Service.Controllers;
using Moq;
using System.Collections.Generic;

namespace Contact.Service.Tests
{
    public class ContactServiceShould
    {
        private readonly ContactService _contactService;
        private readonly Models.Contact testContact;
        private readonly Mock<ContactsDataStore> mockDataStore;

        public ContactServiceShould()
        {
            // Initial Setup
            _contactService = new ContactService();
             testContact = new Models.Contact()
            {
                Name = "John Roberts",
                Company = "Fict Company",
                Email = "johnr@roberts.com",
                PersonalPhoneNumber = "8708099090"
            };
            mockDataStore = new Mock<ContactsDataStore>();
        }

        [Fact]
        public void ServiceShouldAddContact()
        {
            //Setup


            //Act
            _contactService.Add(testContact);

            //Assert
            Assert.True(testContact == ContactsDataStore.Contacts[0], "Contact added through Add method should match with store");
        }
        [Fact]
        public void ContactServiceShouldReturnValidContact()
        {
            //Setup

            ContactsDataStore.Contacts.Add(testContact);

            //Act
            List<Models.Contact> contacts = _contactService.GetContacts();

            //Assert
            Assert.True(testContact.Name == contacts[0].Name, "One contact that was added should return");
            Assert.True(testContact.Email == contacts[0].Email, "One contact that was added should return");

        }
    }
}
