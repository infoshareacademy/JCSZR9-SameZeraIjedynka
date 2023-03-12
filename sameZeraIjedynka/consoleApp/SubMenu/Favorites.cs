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
                        AddEvent();
                        break;
                    case 'b':
                        FavoriteDisplay();
                        break;
                    case 'c':
                        SearchEvent();
                        break;
                    case 'd':
                        RemoveEvent();
                        break;
                    case 'x':
                        return;
                    default:
                        Console.WriteLine("Operation unavailable");
                        break;

                }
            }
           
        }
        public void AddEvent()
        {
            
            Console.Clear();
            Console.WriteLine("Add or remove");
            Console.WriteLine("Enter event details: title, date, organizer, type.");
            var title = Console.ReadLine();
            var date = Console.ReadLine();
            var organizer = Console.ReadLine();
            var type = Console.ReadLine();

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
        public void SearchEvent()
        {
            var favoriteEvent = new vFavorite();
            System.Console.Clear();
            Console.WriteLine("Enter the search phrase");
            var searchEvent = Console.ReadLine();
            favoriteEvent.DisplayMatchingEvents(searchEvent);
        }
        public void RemoveEvent()
        {

            var favoriteEvent = new vFavorite();
            Console.WriteLine("Enter the title of the event you want to delete: ");
            var deletedEvent = Console.ReadLine();
            favoriteEvent.RemoveFavorite(deletedEvent);
        }

    }
}
