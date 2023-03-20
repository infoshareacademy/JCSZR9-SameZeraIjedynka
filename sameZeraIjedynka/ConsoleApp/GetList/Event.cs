using BusinessCase.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Event
    {
        private int id;
        private DateTime date;
        private TargetEnum target;

        public Event(int id, string name, DateTime date, string organizer, string place, int price, int capacity, TargetEnum target, bool isFavourite)
        {
            this.id = id;
            Name = name;
            this.date = date;
            Organizer = organizer;
            Place = place;
            Price = price;
            Capacity = capacity;
            this.target = target;
            IsFavourite = isFavourite;
        }

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
