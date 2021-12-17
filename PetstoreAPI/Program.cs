using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

//A Relic of a past I really hope everyone's forgotten
/*
AUTHOR: Liam Ward: liamtgward@gmail.com
LAST_EDITED: 10/10/2021 - Liam Ward
OVERVIEW: This code Requests all available pets from the swagger Pet store API and prints all categories in reverse alphabetical order.
 */

namespace PetStoreAPI
{
    class petStoreRequester
    {
        /// <summary>
        /// Entry Point 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile(@"C:\Users\LiamWard\source\repos\PetstoreAPI\PetstoreAPI\appsettings.json")
                .AddEnvironmentVariables()
                .Build();

            var serviceProvider = new ServiceCollection()
                .AddSingleton<IRequestOrchestration, RequestOrchestration>()
                .AddSingleton<IPetQuery, PetQuery>()
                .AddSingleton<IAPIRequest, APIRequest >()
                .AddSingleton<IDisplay, Display>()
                .Configure<Settings>(config.GetRequiredSection("Settings"))
                .BuildServiceProvider();

            var petStoreApiRequest = serviceProvider.GetRequiredService<IRequestOrchestration>();

            petStoreApiRequest.Run();
        }
    }
}
