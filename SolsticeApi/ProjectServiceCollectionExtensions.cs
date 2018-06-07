using System;
using SolsticeApi.Commands.ContactCommands;
using Microsoft.Extensions.DependencyInjection;
using SolsticeApi.Commands;

namespace SolsticeApi
{
    public static class ProjectServiceCollectionExtensions
    {
        public static IServiceCollection AddProjectCommands(this IServiceCollection services) =>
            services
                .AddSingleton<IGetAllContactsCommand, GetAllContactsCommand>()
                .AddSingleton(x => new Lazy<IGetAllContactsCommand>(() => x.GetRequiredService<IGetAllContactsCommand>()));

    }
}
