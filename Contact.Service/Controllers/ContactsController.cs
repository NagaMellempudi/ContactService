using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contact.Service.Services;
using Microsoft.AspNetCore.Mvc;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Contact.Service.Controllers
{
    [ApiController]
    [Route("api/contacts")]
    public class ContactsController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactsController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public IActionResult GetContacts()
        {
            return Ok(new JsonResult(_contactService.GetContacts()));
        }

        [HttpGet("{name}", Name = "GetContact")]
        public IActionResult GetContact(string name)
        {
            if(string.IsNullOrEmpty(name))  //bad request
                return BadRequest();

            var results = _contactService.GetContacts().FirstOrDefault(contact => contact.Name == name);

            if(results == null) //No results found
            {
                return NotFound();
            }

            return new JsonResult(results);
        }

        [HttpPost]
        public IActionResult AddContact([FromBody] Models.Contact contact)
        {
            var results = _contactService.GetContacts().FirstOrDefault(c => c.Name == contact.Name);

            if (results != null)
                return BadRequest(new { Message = "Name already exists"});

            _contactService.Add(contact);

            return NoContent();
        }

        [HttpDelete("{name}", Name = "DeleteContact")]
        public IActionResult DeleteContact(string name)
        {
            if (string.IsNullOrEmpty(name))  //bad request
                return BadRequest(new { Message = "Name cannot be null" });

            var results = _contactService.GetContacts().FirstOrDefault(contact => contact.Name == name);
            if (results == null)
                return NotFound();

            var status = _contactService.Delete(results);

            return NoContent();

        }
        [HttpPut]
        public IActionResult UpdateContact([FromBody] Models.Contact contact)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var results = _contactService.GetContacts().FirstOrDefault(c => c.Name == contact.Name);
            if (results == null)
                return NotFound();

            results.Email = contact.Email;
            results.Company = contact.Company;
            results.PersonalPhoneNumber = contact.PersonalPhoneNumber;

            return NoContent();
        }
        [HttpGet("{email}")]
        public IActionResult GetContactsByEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                return BadRequest();

            return Ok(_contactService.GetContactsByEmail(email));
        }
        [HttpGet("{phoneNumber}")]
        public IActionResult GetContactsByPhoneNumber(string phoneNumber)
        {
            if (string.IsNullOrEmpty(phoneNumber))
                return BadRequest();

            return Ok(_contactService.GetContactsByPhone(phoneNumber));
        }
        [HttpGet("bycity/{city}")]
        public IActionResult GetContactsByCity(string city)
        {
            if (string.IsNullOrEmpty(city))
                return BadRequest();

            return Ok(_contactService.GetContactsByCity(city));
        }
        [HttpGet("bystate/{state}")]
        public IActionResult GetContactsByState(string state)
        {
            if (string.IsNullOrEmpty(state))
                return BadRequest();

            return Ok(_contactService.GetContactsByState(state));
        }
    }
}
