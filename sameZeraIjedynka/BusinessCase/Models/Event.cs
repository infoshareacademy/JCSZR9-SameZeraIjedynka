using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessCase.Model
{

    public enum TargetEnum
    {
        kids,
        adults,
        grandpas,
        all
    }
    public class Event
    {
        public Event(int Id, string Name, DateTime Date, string Organizer, string Place, int Price, int Capacity, TargetEnum Target, bool IsFavourite)
        {
            this.Id = Id;
            this.Name = Name;
            this.Date = Date;
            this.Organizer = Organizer;
            this.Place = Place;
            this.Price = Price;
            this.Capacity = Capacity;
            this.Target = Target;
            this.IsFavourite = IsFavourite;
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime Date { get; set; }
        public string? Organizer { get; set; }
        public string? Place { get; set; }
        public int Price { get; set; }
        public int Capacity { get; set; }
        public TargetEnum Target { get; set; }
        public bool IsFavourite { get; set; }
    }
}
