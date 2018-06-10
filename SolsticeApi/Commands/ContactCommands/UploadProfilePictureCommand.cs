using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using SolsticeApi.Commands.ContactCommands.Interfaces;
using SolsticeApi.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace SolsticeApi.Commands.ContactCommands
{
    public class UploadProfilePictureCommand : IUploadProfilePictureCommand
    {
        private readonly IActionContextAccessor actionContextAccessor;
        private readonly IContactRepository contactRepository;
        private readonly IHostingEnvironment hostingEnvironment;

        public UploadProfilePictureCommand(
            IContactRepository contactRepository,
            IActionContextAccessor actionContextAccessor,
            IHostingEnvironment hostingEnvironment)
        {
            this.contactRepository = contactRepository;
            this.actionContextAccessor = actionContextAccessor;
            this.hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Execute(int id, IFormFile profilePictureFile)
        {
            string wwwrootPath = hostingEnvironment.WebRootPath;
            string profilePicturesFolderPath = wwwrootPath + "\\ProfilePictures";
            string fileExtension = Path.GetExtension(profilePictureFile.FileName);

            var existingContact = contactRepository.Find(id);
            if (existingContact == null)
            {
                return new NotFoundResult();
            }

            if (profilePictureFile.Length > 0)
            {
                string fileName = "ProfilePic" + id + fileExtension;
          
                string fileDestineLocation = Path.Combine(profilePicturesFolderPath, fileName);

                profilePictureFile.CopyTo(new FileStream(fileDestineLocation, FileMode.Create));
            }
            else
            {
                return new BadRequestResult();
            }

            if (existingContact.ProfilePicFileName == null)
            {
                contactRepository.SaveProfilePicName(id);
            }

            return new OkResult();
          
        }
    }
}
