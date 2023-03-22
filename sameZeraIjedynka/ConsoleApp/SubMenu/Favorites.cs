using BusinessCase.Model;
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
        private char Selection { get; set; }



        public Favorites(char Selection)
        {
            this.Selection = Selection;
           
            {
                switch (this.Selection)
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
                    case '0':
                        Console.Clear();
                        Console.WriteLine("EXIT");
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }
            }
           
        }
        public void AddOrRemove()
        {
            
            Console.Clear();
            Console.WriteLine("Add or remove");
            Console.WriteLine("Enter event details: title, date, organizer, type.");
            var id = int.Parse(Console.ReadLine());
            var name = Console.ReadLine();
            DateTime.TryParse(Console.ReadLine(), out var date);
            var organizer = Console.ReadLine();
            var place = Console.ReadLine();
            int.TryParse(Console.ReadLine(), out int price);
            var capacity = int.Parse(Console.ReadLine());
            Enum.TryParse(Console.ReadLine(), out Target target);
            bool.TryParse(Console.ReadLine(), out bool isFavourite);
 
            var newEvent = new vFavorite(id, name, date, organizer, place, price, capacity, target, isFavourite);

            //var favoriteEvent = new vFavorite();
            //favoriteEvent.AddFavorite(newEvent);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n Press any key to return.");
            Console.ReadKey(true);
            Console.Clear();
        }
        public void FavoriteDisplay()
        {
            //var favoriteEvent = new vFavorite();
            Console.Clear();
            Console.WriteLine("Display the event");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n Press any key to return.");
            Console.ReadKey(true);
            Console.Clear();
            //favoriteEvent.DisplayAllFavoriteEvents();
        }
        public void ShowNextEvent()
        {
            Console.Clear();
            Console.WriteLine("Display next event");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n Press any key to return.");
            Console.ReadKey(true);
            Console.Clear();
        }

    }
}
