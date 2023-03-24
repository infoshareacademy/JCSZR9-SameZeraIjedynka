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
            AmendmentInterface(events);
        }

        public static void DisplayEvents(List<EventModel> events)
        {
            if (events.Count > 0)
                foreach (var item in events)
                {        
                    Console.WriteLine(item);
                }
            else
                Console.WriteLine("No events found");
        }

        public void AmendmentInterface(List<EventModel> events)
        {
            Console.WriteLine("\n Write name of the event you would like to edit:");
            string ?nameToBeAmend = Console.ReadLine();
            Console.WriteLine(events.FirstOrDefault(a=>a.Name.Contains(nameToBeAmend)));
            Console.WriteLine("\n Which parametre you would like to change: name, capacity, organiser ?");
            string ?parameter = Console.ReadLine();
            Console.WriteLine("\n What is new value of this parameter ?"); 
            string ?newValue = Console.ReadLine();
            Console.ReadLine();
            int index = events.FindIndex(a => a.Name.Contains(nameToBeAmend));
        
            switch (parameter)
            {
                case "name":
                    events[index].Name = newValue;
                    Console.WriteLine(events.FirstOrDefault(a => a.Name.Contains(nameToBeAmend)));
                    break;
                case "capacity":
                    events[index].Capacity = Convert.ToInt16(newValue);
                    Console.WriteLine(events.FirstOrDefault(a => a.Name.Contains(nameToBeAmend)));

                    break;
                case "organiser":
                    events[index].Organizer = newValue;
                    Console.WriteLine(events.FirstOrDefault(a => a.Name.Contains(nameToBeAmend)));
                    break;
              
                default:
                    break;

            }
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
