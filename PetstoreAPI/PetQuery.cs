using System;
using System.Collections.Generic;
using System.Linq;

namespace PetStoreAPI
{
    class PetQuery : IPetQuery
    //DooDoo
    { 
        public IEnumerable<string> ReverseSortPetNames(List<PetName> allPets)
        {
            var petCategories = from petName in allPets
                                where petName.name != null
                                orderby petName.name descending
                                select petName.name;

            return petCategories;
        }
    }
}
