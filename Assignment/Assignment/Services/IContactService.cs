using Assignment.Dto;
using Assignment.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Xml.Linq;

namespace Assignment.Services
{
    public interface IContactService
    {
        public Task AddContact(AddContactDto contact);
        public string GetById(int id);
        public string GetAllContacts(int pageNumber, int pageSize);
        public string GetByLastName(string lastName, int pageNumber, int pageSize);
        public Task Update(UpdateContactDto contact);
        public void Delete(int id);
    }
}
