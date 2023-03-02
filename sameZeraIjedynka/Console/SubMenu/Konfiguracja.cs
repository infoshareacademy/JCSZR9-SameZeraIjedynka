using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Console.SubMenu
{
    public class Konfiguracja
    {
        private char _selection { get; set; }

        public Konfiguracja(char Selection)
        {
            _selection = Selection;

            switch (_selection)
            {
                case 'a':
                    Dodawanie();
                    break;
                case 'b':
                    Mailowanie();
                    break;
                case 'c':
                    FormatDaty();
                    break;
                default:
                    System.Console.Clear();
                    
                    break;
            }
        }

        public void Dodawanie()
        {
            System.Console.Clear();
            System.Console.WriteLine("Lista wszystkich wydarzen");
            System.Console.Read();
        }
        public void Mailowanie()
        {
            System.Console.Clear();
            System.Console.WriteLine("Filtrowanie po dacie");
            System.Console.Read();
        }
        public void FormatDaty()
        {
            System.Console.Clear();
            System.Console.WriteLine("Wyszukiwanie wydarzen");
            System.Console.Read();
        }

    }
}
