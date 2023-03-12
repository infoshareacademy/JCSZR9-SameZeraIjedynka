using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Favorites
    {
        private char _selection { get; set; }



        public Favorites(char Selection)
        {
            _selection = Selection;
           
            {
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
           
        }
        public void AddOrRemove()
        {
            
            System.Console.Clear();
            System.Console.WriteLine("Add or remove");
            System.Console.WriteLine("Enter event details: title, date, organizer, type.");
            var title = System.Console.ReadLine();
            var date = System.Console.ReadLine();
            var organizer = System.Console.ReadLine();
            var type = System.Console.ReadLine();

            var newEvent = new vFavorite(title, date, organizer, type);

            var favoriteEvent = new vFavorite();
            favoriteEvent.AddFavorite(newEvent);
        }
        public void FavoriteDisplay()
        {
            var favoriteEvent = new vFavorite();
            System.Console.Clear();
            System.Console.WriteLine("Display the event");
            favoriteEvent.DisplayAllFavoriteEvents();
        }
        public void ShowNextEvent()
        {
            System.Console.Clear();
            System.Console.WriteLine("Display next event");
            System.Console.Read();
        }

    }
}
