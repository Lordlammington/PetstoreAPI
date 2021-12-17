using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace PetStoreAPI 
{
    //🐱‍👤
    class RequestOrchestration : IRequestOrchestration
    {
        private readonly IAPIRequest _apiRequest;
        private readonly IPetQuery _petQuery;
        private readonly IDisplay _display;
        private readonly Settings _settings;
        public RequestOrchestration(IOptions<Settings> settings, IAPIRequest apiRequest, IPetQuery petQuery, IDisplay display)
        {
            _settings = settings.Value;
            _apiRequest = apiRequest;
            _petQuery = petQuery;
            _display = display;
        }
        public void Run()
        {
            //Run async?
            var allPets = _apiRequest.APIRequester(_settings.WebsiteUrl);
            
            //Call Linq Function
            var sortedAvailablePets = _petQuery.ReverseSortPetNames(allPets);

            //Call writer function
            _display.Title();

            foreach (var pet in sortedAvailablePets)
            {
                Console.WriteLine(pet);
            }
        }
    }
}
