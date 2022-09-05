using Assignment.Dto;
using Assignment.Model;
using AutoMapper;
using FluentValidation;
using Newtonsoft.Json;

namespace Assignment.Services
{
    public class ContactService : IContactService
    {

        private readonly ContactDbContext _dbContext;
        private readonly IValidator<AddContactDto> _addContactValidator;
        private readonly IValidator<UpdateContactDto> _updateContactValidator;
        private readonly IMapper _mapper;

        public ContactService(ContactDbContext dbContext,
            IValidator<AddContactDto> addContactValidator,
            IValidator<UpdateContactDto> updateContactValidator,
            IMapper mapper)
        {
            _dbContext = dbContext;
            _addContactValidator = addContactValidator;
            _updateContactValidator = updateContactValidator;
            _mapper = mapper;
        }

        public async Task AddContact(AddContactDto contact)
        {
            var result = await _addContactValidator.ValidateAsync(contact);

            if (!result.IsValid)
            {
                throw new ArgumentException(result.ToString());
            }

            var newContact = _mapper.Map(contact, typeof(AddContactDto), typeof(Contact));

            _dbContext.Add(newContact);
            _dbContext.SaveChanges();
        }

        public string GetById(int id)
        {
            var contact = _dbContext.Contacts.Where(c => c.ID == id).First();

            return JsonConvert.SerializeObject(contact);
        }

        public string GetAllContacts(int pageNumber, int pageSize)
        {
            //can be moved to separate class/method, code repeats
            var startingIndex = pageNumber == 1 ? 0 : (pageNumber - 1) * pageSize - 1;

            var contacts = _dbContext.Contacts.ToList().GetRange(startingIndex, pageSize);

            return JsonConvert.SerializeObject(contacts);
        }
        public string GetByLastName(string lastName, int pageNumber, int pageSize)
        {
            //can be moved to separate class/method, code repeats
            var startingIndex = pageNumber == 1 ? 0 : (pageNumber - 1) * pageSize - 1;

            var contacts = _dbContext.Contacts.Where(c => c.LastName == lastName).ToList().GetRange(startingIndex, pageSize);

            return JsonConvert.SerializeObject(contacts);
        }
        public async Task Update(UpdateContactDto contact)
        {
            var result = await _updateContactValidator.ValidateAsync(contact);

            if (!result.IsValid)
            {
                throw new ArgumentException(result.ToString());
            }

            var contactWithUpdatedValues = _mapper.Map<Contact>(contact);

            var contactToUpdate = _dbContext.Contacts.Where(c => c.ID == contact.Id).First();
            if (contactToUpdate != null)
            {
                contactToUpdate = contactWithUpdatedValues;
                _dbContext.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            //create Dto for delete request and add validation, same for other endpoints that lack Dto
            var contact = _dbContext.Contacts.Where(c => c.ID == id).First();
            _dbContext.Contacts.Remove(contact);
            _dbContext.SaveChanges();
        }
    }
}
