using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using BusinessCase.Controllers;
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
                default:
                    break;
            }
        }

        public void EventList()
        {
            Console.Clear();
            Console.WriteLine("--------- Events list ---------\n");

            var events = EventController.GetEvents();
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
            Console.Read();
        }
        public void DateFilter()
        {
            Console.Clear();
            Console.WriteLine("--------- Filter by date ---------");

            CultureInfo.CurrentUICulture = new CultureInfo("en-US", false);

            Console.WriteLine("\nInput start date:");
            DateTime startDate = DateTime.ParseExact(Console.ReadLine(), "MM/dd/yyyy", CultureInfo.CurrentUICulture);

            Console.WriteLine("\nInput end date:");
            DateTime endDate = DateTime.ParseExact(Console.ReadLine(), "MM/dd/yyyy", CultureInfo.CurrentUICulture);

            var events = EventController.GetEvents().Where(e => (e.Date >= startDate) && (e.Date <= endDate));
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

                Console.Read();
        }
        public void EventFinder()
        {
            Console.Clear();
            Console.WriteLine("--------- Event search ---------");
            Console.Read();
        }

    }
}
