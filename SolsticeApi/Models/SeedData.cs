using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SolsticeApi.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolsticeApi.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ContactDbContext context = app.ApplicationServices
            .GetRequiredService<ContactDbContext>();
            context.Database.Migrate();
            if (!context.Contacts.Any())
            {
                context.Contacts.AddRange(
                new Contact
                {
                    Name = "Bob Johnson",
                    Company = "Microsoft",
                    Email = "Bobjohnson@gmail.com",
                    BirthDay = new DateTime(1981, 1, 11),
                    PhoneNumberWork = "1191234111",
                    PhoneNumberHome = "4241111",
                    Address = "3412 Washington Avenue Phoenix",
                },
                new Contact
                {
                    Name = "Albert D. Avans",
                    Company = "Microsoft",
                    Email = "Albert@gmail.com",
                    BirthDay = new DateTime(1978, 2, 5),
                    PhoneNumberWork = "1191234222",
                    PhoneNumberHome = "4242222",
                    Address = "2599 Bell Street Phoenix",
                },
                new Contact
                {
                    Name = "Tyler L. Tramel",
                    Company = "Github",
                    Email = "taylerlt@gmail.com3",
                    BirthDay = new DateTime(1959, 10, 9),
                    PhoneNumberWork = "1191234333",
                    PhoneNumberHome = "4243333",
                    Address = "2022 Hannah Street Asheville",
                },
                new Contact
                {
                    Name = "Theodore O. Jones",
                    Company = "Github",
                    Email = "theodorejones@gmail.com4",
                    BirthDay = new DateTime(1921, 1, 11),
                    PhoneNumberWork = "1191234444",
                    PhoneNumberHome = "4244444",
                    Address = "1921 Fire Access Road Asheville",
                },
                new Contact
                {
                    Name = "Madelyn T. Johnson",
                    Company = "Google",
                    Email = "madelynTJ@gmail.com5",
                    BirthDay = new DateTime(1981, 1, 11),
                    PhoneNumberWork = "1191234555",
                    PhoneNumberHome = "4245555",
                    Address = "2354 Rockford Mountain Lane Morrisville",
                },
                new Contact
                {
                    Name = "Ollie D. Saunders",
                    Company = "Google",
                    Email = "ollieDS@gmail.com",
                    BirthDay = new DateTime(1949, 1, 8),
                    PhoneNumberWork = "1191234666",
                    PhoneNumberHome = "4246666",
                    Address = "1561 Still Pastures Drive North Morrisville",
                },
                new Contact
                {
                    Name = "Sheila D. Schaller",
                    Company = "Solstice",
                    Email = "SheilaDS@gmail.com7",
                    BirthDay = new DateTime(1991, 5, 16),
                    PhoneNumberWork = "1191234777",
                    PhoneNumberHome = "4247777",
                    Address = "3694 Thomas Street Morrisville",
                },
                new Contact
                {
                    Name = "Heather D. Baker",
                    Company = "Solstice",
                    Email = "heatherDB@gmail.com8",
                    BirthDay = new DateTime(1981, 5, 22),
                    PhoneNumberWork = "1191234888",
                    PhoneNumberHome = "4248888",
                    Address = "1446 McDonald Avenue Albany",
                },
                new Contact
                {
                    Name = "Carlos K. Manley",
                    Company = "Solstice",
                    Email = "cmanly@gmail.com9",
                    BirthDay = new DateTime(1951, 2, 10),
                    PhoneNumberWork = "1191234999",
                    PhoneNumberHome = "4249999",
                    Address = "1392 Joes Road Albany",
                });

                context.SaveChanges();
            }
        }
    }
}
