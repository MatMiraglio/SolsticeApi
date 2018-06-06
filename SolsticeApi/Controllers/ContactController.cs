using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SolsticeApi.Models;
using SolsticeApi.Repositories;

namespace SolsticeApi.Controllers
{
    [Route("api/[controller]")]
    public class ContactController : ControllerBase
    {
        private IContactRepository repository;

        public ContactController(IContactRepository repo)
        {
            repository = repo;
        }

        // GET: api/<controller>
        [HttpGet]
        public IActionResult GetAllContacts()
        {
            var contacts = repository.GetContacts.OrderBy(p => p.ID);

            return new OkObjectResult(contacts);
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IActionResult GetContactById(int id)
        {
            var contact = repository.GetContacts.Where(p => p.ID == id);

            return Ok(contact);
        }

        // GET api/<controller>/phone/11 9 1234 111
        [HttpGet("phone/{phoneNumber}")]
        public IActionResult GetContactByPhoneNumer(string phoneNumber)
        {
            if (phoneNumber == null)
            {
                return BadRequest();
            }
            var contact  = repository.GetContacts.Single(p => p.PhoneNumberHome == phoneNumber || 
                p.PhoneNumberWork == phoneNumber);

            if (contact == null)
            {
                return NotFound();
            }

            return Ok(contact);
        }

        // GET api/<controller>/location/New York
        [HttpGet("location/{address}")]
        public IActionResult GetContactsByAddLocation(string address)
        {
            if (address == null)
            {
                return BadRequest();
            }

            var contacts = repository.GetContacts.Where(p => p.Address.Contains(address));

            return Ok(contacts);
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> CreateContact([FromBody]Contact newContact)
        {
            if (newContact == null)
            {
                return BadRequest();
            }

            int newContactID = await repository.AddContact(newContact);
            return CreatedAtAction("GetContactById", new { id = newContactID }, newContact);
        }

        // PUT api/<controller>/5
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateContact(int id, [FromBody]Contact contact)
        {
            var existingContact = repository.Find(id);
            if (existingContact == null)
            {
                return new NotFoundResult();
            }

            contact.ID = existingContact.ID;

            contact = await repository.UpdateContact(contact);

            return Ok(contact);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public  IActionResult DeleteContact(int id)
        {
            var contact = repository.GetContacts.Single(p => p.ID == id);

            if (contact == null)
            {
                return NotFound();
            }

            repository.DeleteContact(contact);

            return Ok(contact);
        }
    }
}
