﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolsticeApi.Commands.ContactCommands
{
    public interface IGetContactByPhoneNumerCommand
    {
        Task<IActionResult> Execute(string phoneNumber);
    }
}
