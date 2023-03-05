using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Console.SubMenu
{
    
    public class Events
    {
        private char _selection { get; set; }

        public Events(char Selection)
        {
            _selection = Selection;

            switch (_selection)
            {
                case 'a':
                    EventList();
                    break;
                case 'b':
                    DateFilter();
                    break;
                case 'c':
                    EventFinder();
                    break;
                default:
                    break;
            }
        }

        public void EventList()
        {
            System.Console.Clear();
            System.Console.WriteLine("Lista wszystkich wydarzen");
            System.Console.Read();
        }
        public void DateFilter()
        {
            System.Console.Clear();
            System.Console.WriteLine("Filtrowanie po dacie");
            System.Console.Read();
        }
        public void EventFinder()
        {
            System.Console.Clear();
            System.Console.WriteLine("Wyszukiwanie wydarzen");
            System.Console.Read();
        }

    }
}
