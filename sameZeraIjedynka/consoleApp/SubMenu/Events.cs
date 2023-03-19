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
    
    public class Events
    {
        private char _selection { get; set; }

        public Events(char Selection)
        {
            _selection = Selection;

            switch (_selection)
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

        public static void DisplayEvents(List<Event> events)
        {
            if (events.Count > 0)
                foreach (var item in events)
                {
                    if (item.IsFavourite)
                        Console.ForegroundColor = ConsoleColor.Green;

                    Console.WriteLine($"#{item.Id} {item.Name} \n " +
                        $"\t{item.Price}$ {item.Date} {item.Place}\n" +
                        $"\tCapacity: {item.Capacity}\n" +
                        $"\tOrganizer: {item.Organizer}\n" +
                        $"\tTarget: {item.Target}");

                    if (item.IsFavourite)
                        Console.ForegroundColor = ConsoleColor.Yellow;
                }
            else
                Console.WriteLine("No events found");
        }

        private void EventList()
        {
            Console.Clear();
            Console.WriteLine("--------- Events list ---------\n");

            var events = EventController.GetEvents();
            DisplayEvents(events);

            Console.Read();
        }

        private void DateFilter()
        {
            Console.Clear();
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

            var events = EventController.GetEvents().Where(e => 
                (e.Date >= startDate) && 
                (e.Date <= endDate)).ToList();
            Console.Clear();
            Console.WriteLine("--------- Filter by date ---------\n");
            DisplayEvents(events);

            Console.Read();
        }

        private void EventFinder()
        {
            Console.Clear();
            Console.WriteLine("--------- Event search ---------\n");

            Console.WriteLine("Input pattern:");
            var searchPattern = Console.ReadLine();

            var events = EventController.GetEvents().Where(e => 
                (e.Name.Contains(searchPattern)) ||
                (e.Place.Contains(searchPattern)) ||
                (e.Organizer.Contains(searchPattern))).ToList();
            Console.Clear();
            Console.WriteLine("--------- Event search ---------\n");
            DisplayEvents(events);

            Console.Read();
        }

    }
}
