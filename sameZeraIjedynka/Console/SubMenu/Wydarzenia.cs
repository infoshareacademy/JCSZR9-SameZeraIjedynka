using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Console.SubMenu
{
    
    public class Wydarzenia
    {
        private char _selection { get; set; }

        public Wydarzenia(char Selection)
        {
            _selection = Selection;

            switch (_selection)
            {
                case 'a':
                    ListaWszystkichWydarzen();
                    break;
                case 'b':
                    FiltrowaniePoDacie();
                    break;
                case 'c':
                    WyszukiwanieWydarzen();
                    break;
                default:
                    break;
            }
        }

        public void ListaWszystkichWydarzen()
        {
            System.Console.Clear();
            System.Console.WriteLine("Lista wszystkich wydarzen");
            System.Console.Read();
        }
        public void FiltrowaniePoDacie()
        {
            System.Console.Clear();
            System.Console.WriteLine("Filtrowanie po dacie");
            System.Console.Read();
        }
        public void WyszukiwanieWydarzen()
        {
            System.Console.Clear();
            System.Console.WriteLine("Wyszukiwanie wydarzen");
            System.Console.Read();
        }

    }
}
