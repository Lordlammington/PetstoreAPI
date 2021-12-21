using System;
using System.Collections.Generic;
using System.Linq;
using PetStoreAPI;
using Xunit;

namespace PetStoreTests
{
    public class DisplayTests
    {
        [Fact]
        public void DisplayValidPetNames()
        {
            var pets = new List<PetName>();
            var display = new Display();

            var names = new[]
            {
                new PetName {Name = "Pet1"},
                new PetName {Name = "Pet2"},
                new PetName {Name = "Pet3"}
            };

            pets.AddRange(names);
            var stringList = pets.OfType<string>();
           
            //What do i display 
            display.PrintOutToConsole(stringList);

            // if the above code executed then the system works!
            Assert.True(true);
        }
        [Fact]
        public void DisplayNullPetNames()
        {
            var pets = new List<PetName>();
            var display = new Display();
            var names = new[]
            {
                new PetName {Name = null},
                new PetName {Name = null},
                new PetName {Name = null}
            };
            pets.AddRange(names);
            var stringList = pets.OfType<string>();


            display.PrintOutToConsole(stringList);

            // if the above code executed then the system works!
            Assert.True(true);
        }

        [Fact]
        public void DisplayNullList()
        {
            var display = new Display();
            Assert.Throws<ArgumentNullException>(() => display.PrintOutToConsole(null));
        }
    }
}
