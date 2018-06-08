using Microsoft.AspNetCore.Mvc;
using SolsticeApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolsticeApi.Commands.ContactCommands
{
    public interface IUpdateContactCommand
    {
        Task<IActionResult> Execute(int id, Contact contact);
    }
}
