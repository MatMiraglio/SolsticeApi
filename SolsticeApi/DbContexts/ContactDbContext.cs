using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SolsticeApi.Models;


namespace SolsticeApi.DbContexts
{

    public class ContactDbContext : DbContext
    {
        public ContactDbContext(DbContextOptions options) : base(options){}

        public DbSet<Contact> Contacts { get; set; }
    }
}
