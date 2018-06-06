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
        public IQueryable<Contact> GetAllContacts()
        {
            return repository.GetContacts.OrderBy(p => p.ID);
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IQueryable<Contact> GetContactById(int id)
        {
            return repository.GetContacts.Where(p => p.ID == id);
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Contact newContact)
        {
            if (newContact == null)
            {
                return BadRequest();
            }

            int newContactID = await repository.AddContact(newContact);
            return CreatedAtRoute("GetContactById", new { Controller = "Contacts", id = newContactID }, newContact);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != contact.ID)
            {
                return BadRequest();
            }

            _context.Entry(contact).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
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
