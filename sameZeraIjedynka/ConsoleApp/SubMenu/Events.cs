using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    
    public class Events
    {
        public string Title { get; set; }

        public string Date { get; set; }

        public string Organizer { get; set; }

        public string Type { get; set; }

        public Events(string title, string date, string organizer, string type)
        {
            Title = title;
            Date = date;
            Organizer = organizer;
            Type = type;
        }

        public Events()
        {
        }

        protected static object Where(Func<object, bool> value)
        {
            throw new NotImplementedException();
        }


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
            Console.WriteLine("Event list");
            Console.Read();
        }
        public void DateFilter()
        {
            Console.Clear();
            Console.WriteLine("Filter by date");
            Console.Read();
        }
        public void EventFinder()
        {
            Console.Clear();
            Console.WriteLine("Event search");
            Console.Read();
        }

    }
}
