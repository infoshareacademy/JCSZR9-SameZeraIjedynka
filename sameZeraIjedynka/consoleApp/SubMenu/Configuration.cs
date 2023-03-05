using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Console.SubMenu
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
            System.Console.WriteLine("Lista wszystkich wydarzen");
            System.Console.Read();
        }
        public void Sort()
        {
            System.Console.Clear();
            System.Console.WriteLine("Filtrowanie po dacie");
            System.Console.Read();
        }
        public void Format()
        {
            System.Console.Clear();
            System.Console.WriteLine("Wyszukiwanie wydarzen");
            System.Console.Read();
        }

    }
}
