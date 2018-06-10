using System;
using SolsticeApi.Commands.ContactCommands;
using Microsoft.Extensions.DependencyInjection;
using SolsticeApi.Commands;
using SolsticeApi.Commands.ContactCommands.Interfaces;

namespace SolsticeApi
{
    public static class ProjectServiceCollectionExtensions
    {
        public static IServiceCollection AddProjectCommands(this IServiceCollection services) =>
            services
                .AddSingleton<IGetAllContactsCommand, GetAllContactsCommand>()
                .AddSingleton(x => new Lazy<IGetAllContactsCommand>(() => x.GetRequiredService<IGetAllContactsCommand>()))
                .AddSingleton<IGetContactByIdCommand, GetContactByIdCommand>()
                .AddSingleton(x => new Lazy<IGetContactByIdCommand>(() => x.GetRequiredService<IGetContactByIdCommand>()))
                .AddSingleton<IGetContactByPhoneNumerCommand, GetContactByPhoneNumerCommand>()
                .AddSingleton(x => new Lazy<IGetContactByPhoneNumerCommand>(() => x.GetRequiredService<IGetContactByPhoneNumerCommand>()))
                .AddSingleton<IGetContactsByLocationCommand, GetContactsByLocationCommand>()
                .AddSingleton(x => new Lazy<IGetContactsByLocationCommand>(() => x.GetRequiredService<IGetContactsByLocationCommand>()))
                .AddSingleton<ICreateContactCommand, CreateContactCommand>()
                .AddSingleton(x => new Lazy<ICreateContactCommand>(() => x.GetRequiredService<ICreateContactCommand>()))
                .AddSingleton<IUpdateContactCommand, UpdateContactCommand>()
                .AddSingleton(x => new Lazy<IUpdateContactCommand>(() => x.GetRequiredService<IUpdateContactCommand>()))
                .AddSingleton<IDeleteContactCommand, DeleteContactCommand>()
                .AddSingleton(x => new Lazy<IDeleteContactCommand>(() => x.GetRequiredService<IDeleteContactCommand>()))
                .AddSingleton<IUploadProfilePictureCommand, UploadProfilePictureCommand>()
                .AddSingleton(x => new Lazy<IUploadProfilePictureCommand>(() => x.GetRequiredService<IUploadProfilePictureCommand>()));


    }
}
