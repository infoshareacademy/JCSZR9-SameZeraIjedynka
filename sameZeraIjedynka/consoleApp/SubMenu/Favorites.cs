using BusinessCase.Controllers;
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
                        Console.WriteLine("Enter the name of the event you want to add to your favourites:");
                        string name = Console.ReadLine();

                        var selectedEvent = EventManager.GetEvents().FirstOrDefault(e => e.Name.Contains(name));
                        if (selectedEvent != null)
                        {
                            Console.WriteLine($"Do you want to add an event '{selectedEvent.Name}' to your favourites? (y/n)");
                            ConsoleKeyInfo key = Console.ReadKey();
                            if (key.KeyChar == 'y')
                            {
                                selectedEvent.IsFavourite = true;
                                Console.WriteLine($"Event '{selectedEvent.Name}' added to your favourites.");
                            }
                            else if (key.KeyChar == 'n')
                            {
                                selectedEvent.IsFavourite = false;
                                Console.WriteLine($"Event '{selectedEvent.Name}' deleted from your favourites.");
                            }
                            else
                            {
                                Console.WriteLine("Unavailable move.");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Can't find event '{name}'.");
                        }

                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\n Press any key to return.");
                        Console.ReadKey(true);
                        Console.Clear();

                        break;
                    case 'b':
                        var fav = EventManager.GetEvents().Where(f => f.IsFavourite == true).ToList();
                        foreach (var a in fav)
                        {
                            Events.DisplayEvents(fav);

                            Console.Read();
                        }
                        break;
                    case 'c':
                        Console.WriteLine("Enter the search phrase");
                        var searchPharse = Console.ReadLine() ?? string.Empty;

                        var search = EventManager.GetEvents(searchPharse);
                        Console.WriteLine();
                        Events.DisplayEvents(search);

                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\n Press any key to return.");
                        Console.ReadKey(true);
                        Console.Clear();
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
        //public void AddOrRemove()
        //{
            
        //    Console.Clear();
        //    Console.WriteLine("Add or remove");
        //    Console.WriteLine("Enter event details: title, date, organizer, type.");
        //    var id = int.Parse(Console.ReadLine());
        //    var name = Console.ReadLine();
        //    DateTime.TryParse(Console.ReadLine(), out var date);
        //    var organizer = Console.ReadLine();
        //    var place = Console.ReadLine();
        //    int.TryParse(Console.ReadLine(), out int price);
        //    var capacity = int.Parse(Console.ReadLine());
        //    Enum.TryParse(Console.ReadLine(), out Target target);
        //    bool.TryParse(Console.ReadLine(), out bool isFavourite);
 
        //    var newEvent = new vFavorite(id, name, date, organizer, place, price, capacity, target, isFavourite);

        //    //var favoriteEvent = new vFavorite();
        //    //favoriteEvent.AddFavorite(newEvent);

        //    Console.ForegroundColor = ConsoleColor.Yellow;
        //    Console.WriteLine("\n Press any key to return.");
        //    Console.ReadKey(true);
        //    Console.Clear();
        //}
        //public void FavoriteDisplay()
        //{
        //    //var favoriteEvent = new vFavorite();
        //    Console.Clear();
        //    Console.WriteLine("Display the event");

        //    Console.ForegroundColor = ConsoleColor.Yellow;
        //    Console.WriteLine("\n Press any key to return.");
        //    Console.ReadKey(true);
        //    Console.Clear();
        //    //favoriteEvent.DisplayAllFavoriteEvents();
        //}
        //public void ShowNextEvent()
        //{
        //    Console.Clear();
        //    Console.WriteLine("Display next event");

        //    Console.ForegroundColor = ConsoleColor.Yellow;
        //    Console.WriteLine("\n Press any key to return.");
        //    Console.ReadKey(true);
        //    Console.Clear();
        //}

    }
}
