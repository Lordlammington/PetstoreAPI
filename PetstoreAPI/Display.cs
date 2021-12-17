using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PetStoreAPI
{
    class Display : IDisplay
    {
        //I Regret Nothing
        public void Title()
        {
            Console.WriteLine(@"  ____  _____ _____ ____ _____ ___  ____  _____      _    ____ ___ ");
            Console.WriteLine(@" |  _ \| ____|_   _/ ___|_   _/ _ \|  _ \| ____|    / \  |  _ \_ _|");
            Console.WriteLine(@" | |_) |  _|   | | \___ \ | || | | | |_) |  _|     / _ \ | |_) | | ");
            Console.WriteLine(@" |  __/| |___  | |  ___) || || |_| |  _ <| |___   / ___ \|  __/| | ");
            Console.WriteLine(@" |_|   |_____| |_| |____/ |_| \___/|_| \_\_____| /_/   \_\_|  |___|");
        }
    }
}
