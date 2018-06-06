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
        public Contact Find(int id)
        {
            return context.Contacts.Single(e => e.ID == id);
        }
        public async Task<int> AddContact(Contact newContact)
        {

            context.Contacts.AddRange(newContact);
            await context.SaveChangesAsync();

            return newContact.ID;
        }
        public void DeleteContact(Contact contact)
        {
            context.Remove(contact);
            context.SaveChanges();
        }
        public async Task<Contact> UpdateContact(Contact contact)
        {
            var existingContact = GetContacts.FirstOrDefault(p => p.ID == contact.ID);

            existingContact.Name = contact.Name;
            existingContact.Company = contact.Company;
            existingContact.ProfilePicFileName = contact.ProfilePicFileName;
            existingContact.PhoneNumberWork = contact.PhoneNumberWork;
            existingContact.PhoneNumberHome = contact.PhoneNumberHome;
            existingContact.Email = contact.Email;
            existingContact.BirthDay = contact.BirthDay;
            existingContact.Address = contact.Address;

            await context.SaveChangesAsync();

            return existingContact;
        }
    }
}
