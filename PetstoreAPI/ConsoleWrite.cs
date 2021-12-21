using System;
using System.Collections.Generic;

namespace PetStoreAPI
{
    public class ConsoleWrite : IConsoleWrite
    {
        /// <summary>
        /// Prints out some wicked cool ASCII art (I used a generator).
        /// </summary>
        public void PrintOutToConsole(IEnumerable<string> petList)
        {
            if (petList == null) throw new ArgumentNullException(nameof(petList));

            WriteTitle();

            foreach (var petName in petList)
            {
                Console.WriteLine(petName);
            }

        }

        private static void WriteTitle()
        {
            Console.WriteLine(@"  ____  _____ _____ ____ _____ ___  ____  _____      _    ____ ___ ");
            Console.WriteLine(@" |  _ \| ____|_   _/ ___|_   _/ _ \|  _ \| ____|    / \  |  _ \_ _|");
            Console.WriteLine(@" | |_) |  _|   | | \___ \ | || | | | |_) |  _|     / _ \ | |_) | | ");
            Console.WriteLine(@" |  __/| |___  | |  ___) || || |_| |  _ <| |___   / ___ \|  __/| | ");
            Console.WriteLine(@" |_|   |_____| |_| |____/ |_| \___/|_| \_\_____| /_/   \_\_|  |___|");
        }


    }
}
