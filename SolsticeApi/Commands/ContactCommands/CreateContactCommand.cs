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
    public class CreateContactCommand : ICreateContactCommand
    {
        private readonly IActionContextAccessor actionContextAccessor;
        private readonly IContactRepository contactRepository;

        public CreateContactCommand(
            IContactRepository contactRepository,
            IActionContextAccessor actionContextAccessor)
        {
            this.contactRepository = contactRepository;
            this.actionContextAccessor = actionContextAccessor;
        }


        public async Task<IActionResult> Execute(Contact newContact)
        {
            if (newContact == null)
            {
                return new BadRequestResult();
            }

            /*   
               The AddContact method returns the ID of the newly added contact 
               as an int and is stored in newContactID 
            */
            int newContactID = await contactRepository.AddContact(newContact);

            return new CreatedAtActionResult("GetContactById", "Contact", new { id = newContactID }, newContact);
        }

    }
}
