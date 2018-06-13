using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolsticeApi.Mappers
{
    public class ContactMapper : Profile
    {
        public ContactMapper()
        {
            CreateMap<ViewModels.SaveContact, Models.Contact>();
            CreateMap<Models.Contact, ViewModels.Contact>();
        }
    }
}
