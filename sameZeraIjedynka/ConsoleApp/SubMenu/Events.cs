using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using BusinessCase.Controllers;
using BusinessCase.Model;
using static System.IO.Directory;

namespace ConsoleApp
{
    
    public static class Events
    {
        private static char Selection { get; set; }

        public static void Main(char Selection)
        {
            Events.Selection = Selection;

            switch (Events.Selection)
            {
                case 'a':
                    EventList();
                    break;
                case 'b':
                    DateFilter();
                    break;
                case 'c':
                    EventFinder();
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

        public static void DisplayEvents(List<EventModel> events)
        {
            if (events.Count > 0)
                foreach (var item in events)
                {
                    if (item.IsFavourite)
                        Console.ForegroundColor = ConsoleColor.Green;

                    Console.WriteLine(item);

                    if (item.IsFavourite)
                        Console.ForegroundColor = ConsoleColor.Gray;
                }
            else
                Console.WriteLine("No events found");
        }

        private static void EventList()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("--------- Events list ---------\n");

            var events = EventManager.GetEvents();
            DisplayEvents(events);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n Press any key to return.");
            Console.ReadKey(true);
            Console.Clear();
        }

        private static void DateFilter()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("--------- Filter by date ---------\n");

            CultureInfo.CurrentUICulture = new CultureInfo("en-US", false);

            Console.WriteLine("Input start date (in MM/DD/YYYY format):");
            DateTime startDate = DateTime.ParseExact(Console.ReadLine(), 
                "MM/dd/yyyy", 
                CultureInfo.CurrentUICulture);

            Console.WriteLine("Input end date (in MM/DD/YYYY format):");
            DateTime endDate = DateTime.ParseExact(Console.ReadLine(), 
                "MM/dd/yyyy", 
                CultureInfo.CurrentUICulture);

            var events = EventManager.GetEvents(startDate, endDate);
            Console.WriteLine();
            DisplayEvents(events);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n Press any key to return.");
            Console.ReadKey(true);
            Console.Clear();
        }

        private static void EventFinder()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("--------- Event search ---------\n");

            Console.WriteLine("Input pattern:");
            var searchPattern = Console.ReadLine() ?? string.Empty;

            var events = EventManager.GetEvents(searchPattern);
            Console.WriteLine();
            DisplayEvents(events);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n Press any key to return.");
            Console.ReadKey(true);
            Console.Clear();
        }

    }
}
