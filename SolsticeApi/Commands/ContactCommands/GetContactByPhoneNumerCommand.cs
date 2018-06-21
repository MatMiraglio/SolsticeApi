using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using SolsticeApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolsticeApi.Commands.ContactCommands
{
    public class GetContactByPhoneNumerCommand : IGetContactByPhoneNumerCommand
    {
        private IContactRepository contactRepository;
        private readonly IMapper contactMapper;

        public GetContactByPhoneNumerCommand(
            IContactRepository contactRepository,
            IMapper contactMapper)
        {
            this.contactRepository = contactRepository;
            this.contactMapper = contactMapper;
        }

        public async Task<IActionResult> Execute(string phoneNumber)
        {
            if (phoneNumber == null)
            {
                return new BadRequestResult();
            }
            var contacts = await contactRepository.GetContacts.Where(p => p.PhoneNumberHome.Contains(phoneNumber) ||
               p.PhoneNumberWork.Contains(phoneNumber)).ToListAsync();

            var contactViewModel = Mapper.Map<List<ViewModels.Contact>>(contacts);

            if (contactViewModel == null)
            {
                return new NotFoundResult();
            }

            return new OkObjectResult(contactViewModel);
        }
    }
}
