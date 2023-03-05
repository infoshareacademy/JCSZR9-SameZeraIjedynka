﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Console.SubMenu
{
    public class Favorites
    {
        private char _selection { get; set; }

        public Favorites(char Selection)
        {
            _selection = Selection;

            switch (_selection)
            {
                case 'a':
                    AddOrRemove();
                    break;
                case 'b':
                    FavoriteDisplay();
                    break;
                case 'c':
                    ShowNextEvent();
                    break;
                default:
                    break;
            }
        }

        public void AddOrRemove()
        {
            System.Console.Clear();
            System.Console.WriteLine("Dodanie lub skasowanie");
            System.Console.Read();
        }
        public void FavoriteDisplay()
        {
            System.Console.Clear();
            System.Console.WriteLine("Wyswietlenie ulubionych");
            System.Console.Read();
        }
        public void ShowNextEvent()
        {
            System.Console.Clear();
            System.Console.WriteLine("Pokaz najblizsze");
            System.Console.Read();
        }

    }
}
