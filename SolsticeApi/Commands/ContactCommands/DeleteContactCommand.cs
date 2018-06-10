using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using SolsticeApi.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SolsticeApi.Commands.ContactCommands
{
    public class DeleteContactCommand : IDeleteContactCommand
    {
        private readonly IActionContextAccessor actionContextAccessor;
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly IContactRepository contactRepository;

        public DeleteContactCommand(
            IContactRepository contactRepository,
            IActionContextAccessor actionContextAccessor,
            IHostingEnvironment hostingEnvironment)
        {
            this.contactRepository = contactRepository;
            this.actionContextAccessor = actionContextAccessor;
            this.hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Execute(int id)
        {
            var contact = contactRepository.GetContacts.Single(p => p.ID == id);

            if (contact == null)
            {
                return new NotFoundResult();
            }

            if (contact.ProfilePicFileName != null)
            {
                string profilePicFullName = hostingEnvironment.WebRootPath + "\\ProfilePictures\\" + contact.ProfilePicFileName;

                File.Delete(profilePicFullName);
            }

            contactRepository.DeleteContact(contact);

            return new OkObjectResult(contact);
        }
    }
}
