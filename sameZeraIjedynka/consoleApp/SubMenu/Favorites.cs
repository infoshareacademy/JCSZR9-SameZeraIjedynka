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
            var favoriteEvent = new vFavorite();
            var userInput = Console.ReadLine();

            _selection = Selection;
            while (true)
            {
                
                switch (_selection)
                {
                    case 'a':
                        Console.Clear();
                        Console.WriteLine("Add or remove");
                        Console.WriteLine("Enter event details: title, date, organizer, type.");
                        var title = Console.ReadLine();
                        var date = Console.ReadLine();
                        var organizer = Console.ReadLine();
                        var type = Console.ReadLine();

                        var newEvent = new vFavorite(title, date, organizer, type);

                        favoriteEvent.AddFavorite(newEvent);
                        break;
                    case 'b':

                        Console.Clear();
                        Console.WriteLine("Display the event");
                        favoriteEvent.DisplayAllFavoriteEvents();
                        break;
                    case 'c':
                        Console.Clear();
                        Console.WriteLine("Enter the search phrase");
                        var searchEvent = Console.ReadLine();
                        favoriteEvent.DisplayMatchingEvents(searchEvent);
                        break;
                    case 'd':
                        Console.WriteLine("Enter the title of the event you want to delete: ");
                        var deletedEvent = Console.ReadLine();
                        favoriteEvent.RemoveFavorite(deletedEvent);
                        break;
                    case 'x':
                        return;
                    default:
                        Console.WriteLine("Operation unavailable");
                        break;

                }
                Console.WriteLine("Select the operation you want to perform again");
                Menu.FavoritesEvents();


            }
        }
       
    }
}
