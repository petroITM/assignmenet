using Assignment.Dto;
using Assignment.Services;
using Microsoft.AspNetCore.Mvc;

namespace Assignment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpPost(Name = "Add")]
        public async Task<IActionResult> Add(AddContactDto contact)
        {
            await _contactService.AddContact(contact);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            _contactService.GetById(id);
            return Ok();
        }

        [HttpGet("{pageNumber}/{pageSize}")]
        public IActionResult GetAllContacts(int pageNumber, int pageSize)
        {
            _contactService.GetAllContacts(pageNumber, pageSize);
            return Ok();
        }

        [HttpGet("{lastName}/{pageNumber}/{pageSize}")]
        public IActionResult GetByLastName(string lastName, int pageNumber, int pageSize)
        {
            _contactService.GetByLastName(lastName, pageNumber, pageSize);
            return Ok();
        }

        [HttpPut(Name = "Update")]
        public IActionResult Update(UpdateContactDto contact)
        {
            _contactService.Update(contact);
            return Ok();
        }

        [HttpDelete(Name = "Delete")]
        public IActionResult Delete(int id)
        {
            _contactService.Delete(id);
            return Ok();
        }
    }
}