using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using SolsticeApi.Models;
using SolsticeApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolsticeApi.Commands.ContactCommands
{
    public class UpdateContactCommand : IUpdateContactCommand
    {
        private readonly IActionContextAccessor actionContextAccessor;
        private readonly IContactRepository contactRepository;

        public UpdateContactCommand(
            IContactRepository contactRepository,
            IActionContextAccessor actionContextAccessor)
        {
            this.contactRepository = contactRepository;
            this.actionContextAccessor = actionContextAccessor;
        }

        public async Task<IActionResult> Execute(int id, Contact contact)
        {
            var existingContact = contactRepository.Find(id);
            if (existingContact == null)
            {
                return new NotFoundResult();
            }

            contact.ID = existingContact.ID;

            contact = await contactRepository.UpdateContact(contact);

            return new OkObjectResult(contact);
        }
    }
}
