using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace PetStoreAPI
{
    static class PetStoreRequester
    {
        /// <summary>
        /// Entry Point of the whole program
        /// </summary>
        static void Main(string[] args)
        {
            //Source the Website URl from the config file
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile(Directory.GetCurrentDirectory() + @"\appsettings.json")
                .AddEnvironmentVariables()
                .Build();

            //Add Classes to the service provider
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IRequestOrchestration, RequestOrchestration>()
                .AddSingleton<IPetQuery, ReverseAlphSortPets>()
                .AddSingleton<IAPIRequest, WebRequester >()
                .AddSingleton<IDisplay, ConsoleWrite>()
                .Configure<ApplicationSettings>(config.GetRequiredSection("Settings"))
                .BuildServiceProvider();

            var petStoreApiRequest = serviceProvider.GetRequiredService<IRequestOrchestration>();
            
            petStoreApiRequest.Run();
        }
    }
}
