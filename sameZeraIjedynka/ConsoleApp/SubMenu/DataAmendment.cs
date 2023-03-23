using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using BusinessCase.Controllers;
using BusinessCase.Model;
using static System.IO.Directory;

namespace ConsoleApp.SubMenu
{
     
    public class DataAmendment
    {
        


        public void CollectData()
        {
            var events = EventManager.GetEvents();
            DisplayEvents(events);
          
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


        public void returnFunction()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n Press any key to return.");
            Console.ReadKey(true);
            Console.Clear();
        }
    }
}
