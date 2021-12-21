using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace PetStoreAPI 
{
    class RequestOrchestration : IRequestOrchestration
    {
        private readonly IWebRequest _webRequest;
        private readonly IReverseAlphSortPets _reverseAlphSortPets;
        private readonly IConsoleWrite _consoleWrite;
        private readonly ApplicationSettings _settings;
        public RequestOrchestration(IOptions<ApplicationSettings> settings, IWebRequest webRequest, IReverseAlphSortPets reverseAlphSortPets, IConsoleWrite consoleWrite)
        {
            _settings = settings.Value;
            _webRequest = webRequest;
            _reverseAlphSortPets = reverseAlphSortPets;
            _consoleWrite = consoleWrite;
        }

        /// <summary>
        /// Makes a Synchronous Web Call to a pet store API, The passed in URL will return
        /// all pets with status available. These pets are then de serialized to a list of objects,
        /// Which are then cleaned, sorted and printed out in reverse alphabetical order.
        /// </summary>
        public void Run()
        {
            var requestedPetNames = _webRequest.JsonDeSerializer(_settings.WebsiteUrl);

            //LINQ R
            var reverseSortedPetNames = _reverseAlphSortPets.ReverseSortPetNames(requestedPetNames).ToList();

            //Print out the title and pets
            _consoleWrite.PrintOutToConsole(reverseSortedPetNames);
        }
    }
}
