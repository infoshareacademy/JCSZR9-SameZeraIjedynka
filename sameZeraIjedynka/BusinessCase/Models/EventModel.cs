﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessCase.Model
{

    public enum Target
    {
        kids,
        adults,
        grandpas,
        all
    }
    public class EventModel
    {
        // TODO: czy ten konstruktor jest potrzebny przy ulubionych?
        public EventModel(int Id, string Name, DateTime Date, string Organizer, string Place, int Price, int Capacity, Target Target, bool IsFavourite)
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
        public Target Target { get; set; }
        public bool IsFavourite { get; set; }

        public override string ToString()
        {
            return $"#{Id} {Name} \n " +
                        $"\t{Price}$ {Date} {Place}\n" +
                        $"\tCapacity: {Capacity}\n" +
                        $"\tOrganizer: {Organizer}\n" +
                        $"\tTarget: {Target}";
        }

    }
}
