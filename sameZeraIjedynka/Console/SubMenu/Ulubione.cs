using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Console.SubMenu
{
    public class Ulubione
    {
        private char _selection { get; set; }

        public Ulubione(char Selection)
        {
            _selection = Selection;

            switch (_selection)
            {
                case 'a':
                    DodanieLubSkasowanie();
                    break;
                case 'b':
                    WyswietlenieUlubionych();
                    break;
                case 'c':
                    PokazNajblizsze();
                    break;
                default:
                    break;
            }
        }

        public void DodanieLubSkasowanie()
        {
            System.Console.Clear();
            System.Console.WriteLine("Dodanie lub skasowanie");
            System.Console.Read();
        }
        public void WyswietlenieUlubionych()
        {
            System.Console.Clear();
            System.Console.WriteLine("Wyswietlenie ulubionych");
            System.Console.Read();
        }
        public void PokazNajblizsze()
        {
            System.Console.Clear();
            System.Console.WriteLine("Pokaz najblizsze");
            System.Console.Read();
        }

    }
}
