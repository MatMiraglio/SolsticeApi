using SolsticeApi.DbContexts;
using SolsticeApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolsticeApi.Repositories
{
    public class ContactRepository : IContactRepository
    {
        ContactDbContext context;

        public ContactRepository(ContactDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Contact> GetContacts => context.Contacts;
    }
}
