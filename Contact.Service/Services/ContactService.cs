using System;
using System.Collections.Generic;

namespace Contact.Service.Services
{
    public class ContactService : IContactService
    {

        public ContactService()
        {
            if (ContactsDataStore.Contacts == null)
                ContactsDataStore.Contacts = new List<Models.Contact>();
        }

        public void Add(Models.Contact contact)
        {
            ContactsDataStore.Contacts.Add(contact);
        }

        public void Update(Models.Contact contact)
        {

        }
        public bool Delete(Models.Contact contact)
        {
            return ContactsDataStore.Contacts.Remove(contact);
        }

        public List<Models.Contact> GetContacts()
        {
            return ContactsDataStore.Contacts;
        }

        public Models.Contact GetContact(string name)
        {
            return new Models.Contact();
        }
        public List<Models.Contact> GetContactsByEmail(string email)
        {
            return ContactsDataStore.Contacts.FindAll(c => c.Email == email);
        }
        public List<Models.Contact> GetContactsByPhone(string phoneNumber)
        {
            return ContactsDataStore.Contacts.FindAll(c => c.WorkPhoneNumber == phoneNumber || c.PersonalPhoneNumber == phoneNumber);
        }
        public List<Models.Contact> GetContactsByCity(string city)
        {
            return ContactsDataStore.Contacts.FindAll(c => c.Address.City.ToLower() == city.ToLower());
        }
        public List<Models.Contact> GetContactsByState(string state)
        {
            return ContactsDataStore.Contacts.FindAll(c => c.Address.State.ToLower() == state.ToLower());
        }
    }
}
