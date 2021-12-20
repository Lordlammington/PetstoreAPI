using System;
using PetStoreAPI;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace PetStoreTests
{
    public class LINQUnitTests
    {
        /// <summary>
        /// Given a list of 3 pet names, When that list is forward alphabetically (A - Z) sorted Then the returned output should be a reversed sorted list (Z - A)
        /// </summary>
        [Fact]
        public void LINQ_Valid_PetNameList()
        {
            List<PetName> Pets = new List<PetName>();
            PetQuery query = new PetQuery();

            var names = new[]
            {
                new PetName {Name = "AAA"},
                new PetName {Name = "OOO"},
                new PetName {Name = "ZZZ"}
            };

            Pets.AddRange(names);

            var sortedPetNames = query.ReverseSortPetNames(Pets);

            //Testing the reverse alphabetical sort; The entry "ZZZ" should be the first item in the list.
            Assert.True(sortedPetNames.First() == "ZZZ");
        }

        /// <summary>
        /// Given A list of Null pet names When the list is passed in Then the null entries should be dropped and an empty string should be returned
        /// </summary>
        [Fact]
        public void LINQ_Null_PetNameList()
        {
            List<PetName> Pets = new List<PetName>();
            PetQuery query = new PetQuery();

            var names = new[]
            {
                new PetName {Name = null},
                new PetName {Name = null},
                new PetName {Name = null}
            };

            Pets.AddRange(names);

            var sortedPetNames = query.ReverseSortPetNames(Pets);

            Assert.False(sortedPetNames.Any());
        }

        /// <summary>
        /// Given a List of pet names; That are just spaces. When passed in, Then the list should return the same list. Empty pet names are not checked only null names.
        /// </summary>
        [Fact]
        public void LINQ_WhiteSpace_PetNameList()
        {
            List<PetName> Pets = new List<PetName>();
            PetQuery query = new PetQuery();

            var names = new[]
            {
                new PetName {Name = "   "},
                new PetName {Name = "   "},
                new PetName {Name = "   "}
            };

            Pets.AddRange(names);

            var sortedPetNames = query.ReverseSortPetNames(Pets);

            Assert.True(sortedPetNames.Any());
        }

        /// <summary>
        /// Given a null list, When passed in, Then expect a Null exception error to be thrown.
        /// </summary>
        [Fact]
        public void LINQ_Null_List()
        {
            List<PetName> pets = null;
            PetQuery query = new PetQuery();

            Assert.Throws<ArgumentNullException>(() => query.ReverseSortPetNames(pets));
        }

        /// <summary>
        /// Given a list of half Null and half valid entries, When passed in, Then only return a list of 3 entries
        /// </summary>
        [Fact]
        public void LINQ_MixedList_NullValid()
        {
            List<PetName> Pets = new List<PetName>();
            PetQuery query = new PetQuery();

            var names = new[]
            {
                new PetName {Name = "AAA"},
                new PetName {Name = "OOO"},
                new PetName {Name = "ZZZ"},
                new PetName {Name = null},
                new PetName {Name = null},
                new PetName {Name = null}
            };
            Pets.AddRange(names);

            var sortedPetNames = query.ReverseSortPetNames(Pets);

            Assert.True(sortedPetNames.Count() == 3);
        }

        /// <summary>
        /// Given when a list of half empty and half valid pets, When passed in, Then return a list of 6 entries.
        /// </summary>
        [Fact]
        public void LINQ_MixedList_WhiteSpaceValid()
        {
            List<PetName> Pets = new List<PetName>();
            PetQuery query = new PetQuery();

            var names = new[]
            {
                new PetName {Name = "AAA"},
                new PetName {Name = "OOO"},
                new PetName {Name = "ZZZ"},
                new PetName {Name = "   "},
                new PetName {Name = "   "},
                new PetName {Name = "   "}
            };

            Pets.AddRange(names);

            var sortedPetNames = query.ReverseSortPetNames(Pets);

            Assert.True(sortedPetNames.Count() == 6);
        }

        /// <summary>
        ///  Given when a list of half empty and half null pets, When passed in, Then return a list of 3 entries.
        /// </summary>
        [Fact]
        public void LINQ_MixedList_WhiteSpaceNull()
        {
            List<PetName> Pets = new List<PetName>();
            PetQuery query = new PetQuery();

            var names = new[]
            {
                new PetName {Name = null},
                new PetName {Name = null},
                new PetName {Name = null},
                new PetName {Name = "   "},
                new PetName {Name = "   "},
                new PetName {Name = "   "}
            };

            Pets.AddRange(names);

            var sortedPetNames = query.ReverseSortPetNames(Pets);

            Assert.True(sortedPetNames.Count() == 3);
        }
    }
}
