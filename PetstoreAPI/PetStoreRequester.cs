using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace PetStoreAPI
{
    class PetStoreRequester
    {
        /// <summary>
        /// Entry Point 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //Source the Website URl from the config file
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile(@"C:\Users\LiamWard\source\repos\PetstoreAPI\PetstoreAPI\appsettings.json")
                .AddEnvironmentVariables()
                .Build();

            //Add Classes to the service provider
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
