using System;
using PetStoreAPI;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace PetStoreTests
{
    public class LinqUnitTests
    {
        /// <summary>
        /// GIVEN a list of 3 pet names,
        /// WHEN that list is forward alphabetically (A - Z) sorted,
        /// THEN the output should be a reversed sorted list (Z - A).
        /// </summary>
        [Fact]
        public void LINQ_Valid_PetNameList()
        {
            var pets = new List<PetName>();
            var query = new PetQuery();

            var names = new[]
            {
                new PetName {Name = "AAA"},
                new PetName {Name = "OOO"},
                new PetName {Name = "ZZZ"}
            };

            pets.AddRange(names);

            var sortedPetNames = query.ReverseSortPetNames(pets);

            // Testing the reverse alphabetical sort; The entry "ZZZ" should be the first item in the list.
            Assert.True(sortedPetNames.First() == "ZZZ");
        }

        /// <summary>
        /// GIVEN A list of Null pet names,
        /// WHEN passed in,
        /// Then an empty list is returned.
        /// </summary>
        [Fact]
        public void LINQ_Null_PetNameList()
        {
            var pets = new List<PetName>();
            var query = new PetQuery();

            var names = new[]
            {
                new PetName {Name = null},
                new PetName {Name = null},
                new PetName {Name = null}
            };

            pets.AddRange(names);

            var sortedPetNames = query.ReverseSortPetNames(pets).ToList();

            Assert.False(sortedPetNames.Any());
        }

        /// <summary>
        /// GIVEN a List of white space pet names,
        /// WHEN passed in,
        /// THEN return the same list of white space pet names.
        /// </summary>
        [Fact]
        public void LINQ_WhiteSpace_PetNameList()
        {
            var pets = new List<PetName>();
            var query = new PetQuery();

            var names = new[]
            {
                new PetName {Name = "   "},
                new PetName {Name = "   "},
                new PetName {Name = "   "}
            };

            pets.AddRange(names);

            var sortedPetNames = query.ReverseSortPetNames(pets).ToList();
            Assert.True(sortedPetNames.Any());
        }

        /// <summary>
        /// GIVEN a null list,
        /// WHEN passed in,
        /// THEN expect a Null exception error to be thrown.
        /// </summary>
        [Fact]
        public void LINQ_Null_List()
        {
            var query = new PetQuery();
            Assert.Throws<ArgumentNullException>(() => query.ReverseSortPetNames(null));
        }

        /// <summary>
        /// GIVEN a list of half Null and valid entries,
        /// WHEN passed in,
        /// THEN return a list of 3 entries reverse sorted.
        /// </summary>
        [Fact]
        public void LINQ_MixedList_NullValid()
        {
            var pets = new List<PetName>();
            var query = new PetQuery();

            var names = new[]
            {
                new PetName {Name = "AAA"},
                new PetName {Name = "OOO"},
                new PetName {Name = "ZZZ"},
                new PetName {Name = null},
                new PetName {Name = null},
                new PetName {Name = null}
            };
            pets.AddRange(names);

            var sortedPetNames = query.ReverseSortPetNames(pets).ToList();
            Assert.True(sortedPetNames.Count == 3 && sortedPetNames.First() == "ZZZ");

        }

        /// <summary>
        /// GIVEN a list of half empty and valid pets,
        /// WHEN passed in,
        /// THEN return a list of 6 entries.
        /// </summary>
        [Fact]
        public void LINQ_MixedList_WhiteSpaceValid()
        {
            var pets = new List<PetName>();
            var query = new PetQuery();

            var names = new[]
            {
                new PetName {Name = "AAA"},
                new PetName {Name = "OOO"},
                new PetName {Name = "ZZZ"},
                new PetName {Name = "   "},
                new PetName {Name = "   "},
                new PetName {Name = "   "}
            };

            pets.AddRange(names);

            var sortedPetNames = query.ReverseSortPetNames(pets).ToList();

            Assert.True(sortedPetNames.Count == 6);
        }

        /// <summary>
        /// GIVEN a list of half empty and null pets,
        /// WHEN passed in,
        /// THEN return 3 entries.
        /// </summary>
        [Fact]
        public void LINQ_MixedList_WhiteSpaceNull()
        {
            var pets = new List<PetName>();
            var query = new PetQuery();

            var names = new[]
            {
                new PetName {Name = null},
                new PetName {Name = null},
                new PetName {Name = null},
                new PetName {Name = "   "},
                new PetName {Name = "   "},
                new PetName {Name = "   "}
            };

            pets.AddRange(names);

            var sortedPetNames = query.ReverseSortPetNames(pets).ToList();

            Assert.True(sortedPetNames.Count == 3);
        }
    }
}
