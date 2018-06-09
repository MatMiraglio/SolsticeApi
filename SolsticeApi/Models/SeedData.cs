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
                    Name = "Bob Johnson 1",
                    Company = "Microsoft",
                    ProfilePicFileName = "ProfilePic1",
                    Email = "Bobjohnson@gmail.com",
                    BirthDay = new DateTime(1981, 1, 11),
                    PhoneNumberWork = "1191234111",
                    PhoneNumberHome = "4241111",
                    Address = "1111 Saddle Dr",
                },
                new Contact
                {
                    Name = "Bob Johnson 2",
                    Company = "Microsoft 2",
                    ProfilePicFileName = "ProfilePic2",
                    Email = "Bobjohnson@gmail.com2",
                    BirthDay = new DateTime(1981, 1, 11),
                    PhoneNumberWork = "1191234222",
                    PhoneNumberHome = "4242222",
                    Address = "2222 Saddle Dr",
                },
                new Contact
                {
                    Name = "Bob Johnson 3",
                    Company = "Microsoft3",
                    ProfilePicFileName = "ProfilePic3",
                    Email = "Bobjohnson@gmail.com3",
                    BirthDay = new DateTime(1981, 1, 11),
                    PhoneNumberWork = "1191234333",
                    PhoneNumberHome = "4243333",
                    Address = "3333 Saddle Dr",
                },
                new Contact
                {
                    Name = "Bob Johnson 4",
                    Company = "Microsoft4",
                    ProfilePicFileName = "ProfilePic4",
                    Email = "Bobjohnson@gmail.com4",
                    BirthDay = new DateTime(1981, 1, 11),
                    PhoneNumberWork = "1191234444",
                    PhoneNumberHome = "4244444",
                    Address = "4444 Saddle Dr",
                },
                new Contact
                {
                    Name = "Bob Johnson 5",
                    Company = "Microsoft5",
                    ProfilePicFileName = "ProfilePic5",
                    Email = "Bobjohnson@gmail.com5",
                    BirthDay = new DateTime(1981, 1, 11),
                    PhoneNumberWork = "1191234555",
                    PhoneNumberHome = "4245555",
                    Address = "5555 Saddle Dr",
                },
                new Contact
                {
                    Name = "Bob Johnson 6",
                    Company = "Microsoft6",
                    ProfilePicFileName = "ProfilePic6",
                    Email = "Bobjohnson@gmail.com",
                    BirthDay = new DateTime(1981, 1, 11),
                    PhoneNumberWork = "1191234666",
                    PhoneNumberHome = "4246666",
                    Address = "6666 Saddle Dr",
                },
                new Contact
                {
                    Name = "Bob Johnson 7",
                    Company = "Microsoft7",
                    ProfilePicFileName = "ProfilePic7",
                    Email = "Bobjohnson@gmail.com7",
                    BirthDay = new DateTime(1981, 1, 11),
                    PhoneNumberWork = "1191234777",
                    PhoneNumberHome = "4247777",
                    Address = "7777 Saddle Dr",
                },
                new Contact
                {
                    Name = "Bob Johnson 8",
                    Company = "Microsoft8",
                    ProfilePicFileName = "ProfilePic8",
                    Email = "Bobjohnson@gmail.com8",
                    BirthDay = new DateTime(1981, 1, 11),
                    PhoneNumberWork = "1191234888",
                    PhoneNumberHome = "4248888",
                    Address = "8888 Saddle Dr",
                },
                new Contact
                {
                    Name = "Bob Johnson 9",
                    Company = "Microsoft9",
                    ProfilePicFileName = "ProfilePic9",
                    Email = "Bobjohnson@gmail.com9",
                    BirthDay = new DateTime(1981, 1, 11),
                    PhoneNumberWork = "1191234999",
                    PhoneNumberHome = "4249999",
                    Address = "9999 Saddle Dr",
                });

                context.SaveChanges();
            }
        }
    }
}
