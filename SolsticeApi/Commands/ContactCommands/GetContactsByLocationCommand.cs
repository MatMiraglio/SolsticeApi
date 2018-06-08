using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using SolsticeApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolsticeApi.Commands.ContactCommands
{
    public class GetContactsByLocationCommand : IGetContactsByLocationCommand
    {
        private readonly IActionContextAccessor actionContextAccessor;
        private IContactRepository contactRepository;

        public GetContactsByLocationCommand(
            IContactRepository contactRepository,
            IActionContextAccessor actionContextAccessor)
        {
            this.contactRepository = contactRepository;
            this.actionContextAccessor = actionContextAccessor;
        }

        public IActionResult Execute(string address)
        {
            if (address == null)
            {
                return new BadRequestResult();
            }

            var contacts = contactRepository.GetContacts.Where(p => p.Address.Contains(address));

            return new OkObjectResult(contacts);
        }
    }
}
