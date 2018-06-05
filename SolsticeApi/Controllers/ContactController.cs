using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SolsticeApi.Models;
using SolsticeApi.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SolsticeApi.Controllers
{
    [Route("api/[controller]")]
    public class ContactController : Controller
    {
        private IContactRepository repository;

        public ContactController(IContactRepository repo)
        {
            repository = repo;
        }


        // GET: api/<controller>
        [HttpGet]
        public IQueryable<Contact> Get()
        {
            return repository.GetContacts.OrderBy(p => p.ID);
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
