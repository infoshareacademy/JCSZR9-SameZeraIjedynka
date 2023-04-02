using static SameZeraIJedynka.Helpers.Enums.TargetEnum;

namespace SameZeraIJedynka.Models
{
    public class EventModel
    {
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
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Organizer { get; set; }
        public string Place { get; set; }
        public int Price { get; set; }
        public int Capacity { get; set; }
        public Target Target { get; set; }
        public bool IsFavourite { get; set; }
    }
}
