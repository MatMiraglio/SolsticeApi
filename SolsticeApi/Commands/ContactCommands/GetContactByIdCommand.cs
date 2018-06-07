using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using SolsticeApi.Repositories;
using SolsticeApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolsticeApi.Commands.ContactCommands
{
    public class GetContactByIdCommand : IGetContactByIdCommand
    {
        private readonly IActionContextAccessor actionContextAccessor;
        private IContactRepository contactRepository;

        public GetContactByIdCommand(
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

            return new OkObjectResult(contact);
        }
    }
}
