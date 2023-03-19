using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Configuration
    {
        private char _selection { get; set; }

        public Configuration(char Selection)
        {
            _selection = Selection;

            switch (_selection)
            {
                case 'a':
                    AddOrChange();
                    break;
                case 'b':
                    Sort();
                    break;
                case 'c':
                    Format();
                    break;
                default:
                    Console.Clear();
                    
                    break;
            }
        }

        public void AddOrChange()
        {
            Console.Clear();
            Console.WriteLine("List of the events");
            Console.Read();
        }
        public void Sort()
        {
            Console.Clear();
            Console.WriteLine("Event filter");
            Console.Read();
        }
        public void Format()
        {
            Console.Clear();
            Console.WriteLine("Event search");
            Console.Read();
        }

    }
}
