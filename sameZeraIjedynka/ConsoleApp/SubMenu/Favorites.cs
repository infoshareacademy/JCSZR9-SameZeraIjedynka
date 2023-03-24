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
                        Console.WriteLine("Enter the name of the event you want to add or remove to your favourites:");
                        string name = Console.ReadLine();

                        var selectedEvent = EventManager.GetEvents().FirstOrDefault(e => e.Name.Contains(name));
                        if (selectedEvent != null)
                        {
                            Console.WriteLine($"If you want to add an event '{selectedEvent.Name}' to your favourites press Y.");
                            Console.WriteLine($"If you want to remove an event '{selectedEvent.Name}' from your favourites press N.");
                            ConsoleKeyInfo key = Console.ReadKey();
                            if (key.KeyChar == 'Y')
                            {
                                selectedEvent.IsFavourite = true;
                                Console.WriteLine($"Event '{selectedEvent.Name}' added to your favourites.");
                            }
                            else if (key.KeyChar == 'N')
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

                        Events.DisplayEvents(fav);


                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\n Press any key to return.");
                        Console.ReadKey(true);
                        Console.Clear();
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

    }
}
