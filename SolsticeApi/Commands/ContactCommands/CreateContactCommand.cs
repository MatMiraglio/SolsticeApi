using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using SolsticeApi.Models;
using SolsticeApi.Repositories;
using SolsticeApi.ViewModels;
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
        private readonly IMapper contactMapper;

        public CreateContactCommand(
            IContactRepository contactRepository,
            IActionContextAccessor actionContextAccessor,
            IMapper saveContactToContactMapper)
        {
            this.contactRepository = contactRepository;
            this.actionContextAccessor = actionContextAccessor;
            this.contactMapper = saveContactToContactMapper;
        }


        public async Task<IActionResult> Execute(SaveContact saveContact)
        {
            var newContact = contactMapper.Map<Models.Contact>(saveContact);
            /*   
               The AddContact method returns the ID of the newly added contact 
               as an int and is stored in newContactID 
            */
            int newContactID = await contactRepository.AddContact(newContact);

            var newContactViewModel = contactMapper.Map<ViewModels.Contact>(newContact);

            return new CreatedAtActionResult("GetContactById", "Contact", new { id = newContactID }, newContactViewModel);
        }

    }
}
