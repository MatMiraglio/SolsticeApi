using SolsticeApi.Commands.ContactCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SolsticeApi.Repositories;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace SolsticeApi.Commands
{
    public class GetAllContactsCommand : IGetAllContactsCommand
    {
        private readonly IActionContextAccessor actionContextAccessor;
        private IContactRepository contactRepository;

        public GetAllContactsCommand(
            IContactRepository contactRepository,
            IActionContextAccessor actionContextAccessor)
        {
            this.contactRepository = contactRepository;
            this.actionContextAccessor = actionContextAccessor;
        }

        public IActionResult Execute()
        {
            var contacts = contactRepository.GetContacts.OrderBy(p => p.ID);

            if (contacts == null)
            {
                return new NotFoundResult();

            }

            return new OkObjectResult(contacts);
        }
    }
}
