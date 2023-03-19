using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Event
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
        public string Organizer { get; set; }
        public string Place{ get; set; }
        public int Price { get; set; }
        public int Capacity { get; set; }
        public string Target { get; set; }
        public bool IsFavourite { get; set; }

    }
}
