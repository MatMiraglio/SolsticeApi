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
                    PhoneNumberWork = "11 9 1234 111",
                    PhoneNumberHome = "424 1111",
                    Address = "1111 Saddle Dr",
                },
                new Contact
                {
                    Name = "Bob Johnson 2",
                    Company = "Microsoft 2",
                    ProfilePicFileName = "ProfilePic2",
                    Email = "Bobjohnson@gmail.com2",
                    BirthDay = new DateTime(1981, 1, 11),
                    PhoneNumberWork = "11 9 1234 222",
                    PhoneNumberHome = "424 2222",
                    Address = "2222 Saddle Dr",
                },
                new Contact
                {
                    Name = "Bob Johnson 3",
                    Company = "Microsoft3",
                    ProfilePicFileName = "ProfilePic3",
                    Email = "Bobjohnson@gmail.com3",
                    BirthDay = new DateTime(1981, 1, 11),
                    PhoneNumberWork = "11 9 1234 333",
                    PhoneNumberHome = "424 3333",
                    Address = "3333 Saddle Dr",
                },
                new Contact
                {
                    Name = "Bob Johnson 4",
                    Company = "Microsoft4",
                    ProfilePicFileName = "ProfilePic4",
                    Email = "Bobjohnson@gmail.com4",
                    BirthDay = new DateTime(1981, 1, 11),
                    PhoneNumberWork = "11 9 1234 444",
                    PhoneNumberHome = "424 4444",
                    Address = "4444 Saddle Dr",
                },
                new Contact
                {
                    Name = "Bob Johnson 5",
                    Company = "Microsoft5",
                    ProfilePicFileName = "ProfilePic5",
                    Email = "Bobjohnson@gmail.com5",
                    BirthDay = new DateTime(1981, 1, 11),
                    PhoneNumberWork = "11 9 1234 555",
                    PhoneNumberHome = "424 5555",
                    Address = "5555 Saddle Dr",
                },
                new Contact
                {
                    Name = "Bob Johnson 6",
                    Company = "Microsoft6",
                    ProfilePicFileName = "ProfilePic6",
                    Email = "Bobjohnson@gmail.com",
                    BirthDay = new DateTime(1981, 1, 11),
                    PhoneNumberWork = "11 9 1234 666",
                    PhoneNumberHome = "424 6666",
                    Address = "6666 Saddle Dr",
                },
                new Contact
                {
                    Name = "Bob Johnson 7",
                    Company = "Microsoft7",
                    ProfilePicFileName = "ProfilePic7",
                    Email = "Bobjohnson@gmail.com7",
                    BirthDay = new DateTime(1981, 1, 11),
                    PhoneNumberWork = "11 9 1234 777",
                    PhoneNumberHome = "424 7777",
                    Address = "7777 Saddle Dr",
                },
                new Contact
                {
                    Name = "Bob Johnson 8",
                    Company = "Microsoft8",
                    ProfilePicFileName = "ProfilePic8",
                    Email = "Bobjohnson@gmail.com8",
                    BirthDay = new DateTime(1981, 1, 11),
                    PhoneNumberWork = "11 9 1234 888",
                    PhoneNumberHome = "424 8888",
                    Address = "8888 Saddle Dr",
                },
                new Contact
                {
                    Name = "Bob Johnson 9",
                    Company = "Microsoft9",
                    ProfilePicFileName = "ProfilePic9",
                    Email = "Bobjohnson@gmail.com9",
                    BirthDay = new DateTime(1981, 1, 11),
                    PhoneNumberWork = "11 9 1234 999",
                    PhoneNumberHome = "424 9999",
                    Address = "9999 Saddle Dr",
                });

                context.SaveChanges();
            }
        }
    }
}
