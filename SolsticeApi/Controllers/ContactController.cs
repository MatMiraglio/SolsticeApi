using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SolsticeApi.Models;
using SolsticeApi.Repositories;
using SolsticeApi.Commands.ContactCommands;

namespace SolsticeApi.Controllers
{
    [Route("api/[controller]")]
    public class ContactController : ControllerBase
    {
        private readonly Lazy<IGetAllContactsCommand> getAllContactsCommand;
        private readonly Lazy<IGetContactByIdCommand> getContactByIdCommand;
        private readonly Lazy<IGetContactByPhoneNumerCommand> getContactByPhoneNumerCommand;
        private readonly Lazy<IGetContactsByLocationCommand> getContactsByLocationCommand;
        private readonly Lazy<ICreateContactCommand> createContactCommand;
        private readonly Lazy<IUpdateContactCommand> updateContactCommand;
        private readonly Lazy<IDeleteContactCommand> deleteContactCommand;

        private readonly IContactRepository repository;

        public ContactController(
            Lazy<IGetAllContactsCommand> getAllContactsCommand,
            Lazy<IGetContactByIdCommand> getContactByIdCommand,
            Lazy<IGetContactByPhoneNumerCommand> getContactByPhoneNumerCommand,
            Lazy<IGetContactsByLocationCommand> getContactsByLocationCommand,
            Lazy<ICreateContactCommand> createContactCommand,
            Lazy<IUpdateContactCommand> updateContactCommand,
            Lazy<IDeleteContactCommand> deleteContactCommand,
            IContactRepository repository)
        {
            this.getAllContactsCommand = getAllContactsCommand;
            this.getContactByIdCommand = getContactByIdCommand;
            this.getContactByPhoneNumerCommand = getContactByPhoneNumerCommand;
            this.getContactsByLocationCommand = getContactsByLocationCommand;
            this.createContactCommand = createContactCommand;
            this.updateContactCommand = updateContactCommand;
            this.deleteContactCommand = deleteContactCommand;
            this.repository = repository;
        }

        // GET: api/<controller>
        [HttpGet]
        public IActionResult GetAllContacts() => 
            this.getAllContactsCommand.Value.Execute();


        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IActionResult GetContactById([FromRoute]int id) =>
            this.getContactByIdCommand.Value.Execute(id);


        // GET api/<controller>/phone/1191234111
        [HttpGet("phone/{phoneNumber}")]
        public IActionResult GetContactByPhoneNumer([FromRoute]string phoneNumber) =>
            this.getContactByPhoneNumerCommand.Value.Execute(phoneNumber);


        // GET api/<controller>/location/New York
        [HttpGet("location/{address}")]
        public IActionResult GetContactsByLocation([FromRoute]string address) =>
            this.getContactsByLocationCommand.Value.Execute(address);


        // POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> CreateContact([FromBody]Contact newContact) =>
            await this.createContactCommand.Value.Execute(newContact);


        // PUT api/<controller>/5
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateContact([FromRoute]int id, [FromBody]Contact contact) =>
            await this.updateContactCommand.Value.Execute(id, contact);


        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteContact([FromRoute]int id) =>
            this.deleteContactCommand.Value.Execute(id);
    }
}
