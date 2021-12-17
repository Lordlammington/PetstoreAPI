using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

//A Relic of a past I really hope everyone's forgotten
/*
AUTHOR: Liam Ward: liamtgward@gmail.com
LAST_EDITED: 10/10/2021 - Liam Ward
OVERVIEW: This code Requests all avaiable pets from the swagger Petstore API and prints all categories in reverse alphabetical order.
 */

namespace PetStoreAPI
{
    class petStoreRequester
    {

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

            var PetStoreAPIRequest = serviceProvider.GetRequiredService<IRequestOrchestration>();

            PetStoreAPIRequest.Run();


        }
    }
}
