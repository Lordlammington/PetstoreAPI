using System.Linq;
using Microsoft.Extensions.Options;

namespace PetStoreAPI 
{
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

        /// <summary>
        /// Makes a Synchronous Web Call to a pet store API, The passed in URL will return
        /// all pets with status available. These pets are then de serialized to a list of objects,
        /// Which are then cleaned, sorted and printed out in reverse alphabetical order.
        /// </summary>
        public void Run()
        {
            var requestedPetNames = _apiRequest.APIRequester(_settings.WebsiteUrl);
            //LINQ R
            var reverseSortedPetNames = _petQuery.ReverseSortPetNames(requestedPetNames).ToList();

            //Print out the title and pets
            _display.PrintOutToConsole(reverseSortedPetNames);
        }
    }
}
