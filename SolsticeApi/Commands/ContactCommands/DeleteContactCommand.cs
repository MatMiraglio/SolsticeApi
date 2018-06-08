using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using SolsticeApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolsticeApi.Commands.ContactCommands
{
    public class DeleteContactCommand : IDeleteContactCommand
    {
        private readonly IActionContextAccessor actionContextAccessor;
        private readonly IContactRepository contactRepository;

        public DeleteContactCommand(
            IContactRepository contactRepository,
            IActionContextAccessor actionContextAccessor)
        {
            this.contactRepository = contactRepository;
            this.actionContextAccessor = actionContextAccessor;
        }

        public IActionResult Execute(int id)
        {
            var contact = contactRepository.GetContacts.Single(p => p.ID == id);

            if (contact == null)
            {
                return new NotFoundResult();
            }

            contactRepository.DeleteContact(contact);

            return new OkObjectResult(contact);
        }
    }
}
