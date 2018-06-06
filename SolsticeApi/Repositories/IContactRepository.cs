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
        Task<int> AddContact(Contact newContact);
        void DeleteContact(Contact contact);
    }
}
