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
                    System.Console.Clear();
                    
                    break;
            }
        }

        public void AddOrChange()
        {
            System.Console.Clear();
            System.Console.WriteLine("List of the events");
            System.Console.Read();
        }
        public void Sort()
        {
            System.Console.Clear();
            System.Console.WriteLine("Event filter");
            System.Console.Read();
        }
        public void Format()
        {
            System.Console.Clear();
            System.Console.WriteLine("Event search");
            System.Console.Read();
        }

    }
}
