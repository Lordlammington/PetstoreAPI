using System;
using PetStoreAPI;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace PetStoreTests
{
    public class LINQUnitTests
    {
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

            var first = sortedPetNames.First();
            var last = Pets.Last().Name;


            Assert.True(first == last);
        }

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

        [Fact]
        public void LINQ_Empty_PetNameList()
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

        [Fact]
        public void LINQ_Null_List()
        {
            List<PetName> pets = null;
            PetQuery query = new PetQuery();

            Assert.Throws<ArgumentNullException>(() => query.ReverseSortPetNames(pets));
        }

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
        [Fact]
        public void LINQ_MixedList_EmptyValid()
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

            Assert.True(sortedPetNames.Any());
        }

        [Fact]
        public void LINQ_MixedList_EmptyNull()
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
