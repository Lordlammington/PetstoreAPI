using System.Collections.Generic;

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
