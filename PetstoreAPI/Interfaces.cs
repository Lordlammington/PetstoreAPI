using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStoreAPI
{
    public interface IAPIRequest
    {
        List<PetName> APIRequester(string url);

    }
    public interface IRequestOrchestration
    {
        void Run();
    }
    public interface IPetQuery
    {
        IEnumerable<string> ReverseSortPetNames(List<PetName> allPets);
    }

    public interface IDisplay
    {
        void Title();
    }
    
}
