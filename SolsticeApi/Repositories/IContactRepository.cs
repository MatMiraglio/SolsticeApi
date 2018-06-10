using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SolsticeApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolsticeApi.Repositories
{
    public interface IContactRepository
    {
        IQueryable<Contact> GetContacts { get; }
        Contact Find(int id);
        Task<int> AddContact(Contact newContact);
        void DeleteContact(Contact contact);
        Task<Contact> UpdateContact(Contact contactToUpdate);
        void SaveProfilePicName(int id, string fileName);
    }
}
