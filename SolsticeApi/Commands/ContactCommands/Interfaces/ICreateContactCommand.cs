using Microsoft.AspNetCore.Mvc;
using SolsticeApi.Models;
using SolsticeApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolsticeApi.Commands.ContactCommands
{
    public interface ICreateContactCommand
    {
        Task<IActionResult> Execute(SaveContact newContact);
    }
}
