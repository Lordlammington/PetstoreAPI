using System.Collections.Generic;

namespace PetStoreAPI
{
    /// <summary>
    /// Handles the running of both the APU request and the query sort, Orchestrates the program to make the whole environment flatter
    /// </summary>
    public interface IRequestOrchestration
    {
        void Run();
    }
    /// <summary>
    /// Makes a swagger.io call with the inputted URL from the defined settings
    /// </summary>
    public interface IAPIRequest
    {
        List<PetName> APIRequester(string url);
    }
    /// <summary>
    /// Does the direct query on the list of objects, this is what returns the reverse alphabetically sorted enumerable string.
    /// </summary>
    public interface IPetQuery
    {
        IEnumerable<string> ReverseSortPetNames(List<PetName> allPets);
    }
    /// <summary>
    /// Displays the title PetStore API before the returned results... Why? because i felt this program needed some Jazz!
    /// </summary>
    public interface IDisplay
    {
        void PrintOutToConsole(IEnumerable<string> petList);
        private void WriteTitle(){}
    }
}
