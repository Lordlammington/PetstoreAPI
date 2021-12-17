using System;
using System.Collections.Generic;
using System.Linq;

namespace PetStoreAPI
{
    class PetQuery : IPetQuery
    { 
        /// <summary>
        /// Sorts through a list of PetName. Returns not null entries in reverse alphabetical order. Utilizes Linq
        /// </summary>
        /// <param name="allPets"></param>
        /// List of PetName returned by the web call
        /// <returns>
        /// IEnumerable string, the sorted pet categories.
        /// </returns>
        public IEnumerable<string> ReverseSortPetNames(List<PetName> allPets)
        {
            var petCategories = from petName in allPets
                                where petName.Name != null
                                orderby petName.Name descending
                                select petName.Name;
            return petCategories;
        }
    }
}
