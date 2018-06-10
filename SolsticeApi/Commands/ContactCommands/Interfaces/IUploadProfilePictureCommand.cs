using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolsticeApi.Commands.ContactCommands.Interfaces
{
    public interface IUploadProfilePictureCommand
    {
        IActionResult Execute(int id, IFormFile profilePictureFile);
    }
}
