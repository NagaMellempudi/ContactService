using System;
using System.Collections.Generic;

namespace Contact.Service.Services
{
    public interface IContactService
    {
        void Add(Models.Contact contact);
        bool Delete(Models.Contact contact);
        void Update(Models.Contact contact);
        List<Models.Contact> GetContacts();
        Models.Contact GetContact(string name);
        List<Models.Contact> GetContactsByEmail(string email);
        List<Models.Contact> GetContactsByPhone(string phoneNumber);
        List<Models.Contact> GetContactsByCity(string city);
        List<Models.Contact> GetContactsByState(string state);

    }
}
