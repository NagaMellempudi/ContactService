using System;
using Xunit;
using Contact.Service.Models;
using Contact.Service.Services;
using Contact.Service.Controllers;
using Moq;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Contact.Service.Tests
{
    public class ContactControllerShould
    {
        private readonly Mock<IContactService> mockContactService;
        private readonly ContactsController controller;

        public ContactControllerShould()
        {
             mockContactService = new Mock<IContactService>();
             controller = new ContactsController(mockContactService.Object);
        }

        [Fact]
        public void ReturnContacts()
        {
            //Setup
            List<Models.Contact> contacts = new List<Models.Contact>(){new Models.Contact(){
                Name = "John Tester",
                Email = "john.tester@test.com"
            }};


            mockContactService.Setup(x => x.GetContacts()).Returns(contacts);

            //Acct
            IActionResult  result = controller.GetContacts();
         
            var okResult = Assert.IsType<OkObjectResult>(result);
            JsonResult jsonResult = Assert.IsType<JsonResult>(okResult.Value);

            List<Models.Contact> returnedContacts = (List<Models.Contact>)jsonResult.Value;

            //Assert

            Assert.Equal(contacts[0], returnedContacts[0]);
        }

    }
}
