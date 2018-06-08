using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using SolsticeApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolsticeApi.Commands.ContactCommands
{
    public class GetContactByPhoneNumerCommand : IGetContactByPhoneNumerCommand
    {
        private readonly IActionContextAccessor actionContextAccessor;
        private IContactRepository contactRepository;

        public GetContactByPhoneNumerCommand(
            IContactRepository contactRepository,
            IActionContextAccessor actionContextAccessor)
        {
            this.contactRepository = contactRepository;
            this.actionContextAccessor = actionContextAccessor;
        }

        public IActionResult Execute(string phoneNumber)
        {
            if (phoneNumber == null)
            {
                return new BadRequestResult();
            }
            var contact = contactRepository.GetContacts.Single(p => p.PhoneNumberHome == phoneNumber ||
               p.PhoneNumberWork == phoneNumber);

            if (contact == null)
            {
                return new NotFoundResult();
            }

            return new OkObjectResult(contact);
        }
    }
}
