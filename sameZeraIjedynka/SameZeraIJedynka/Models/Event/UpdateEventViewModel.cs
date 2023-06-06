using SameZeraIjedynka.Database.Entities;

namespace SameZeraIJedynka.Models.Event
{
    public class UpdateEventViewModel
    {
        public int EventId { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Organizer { get; set; }
        public string Place { get; set; }
        public int Price { get; set; }
        public int Capacity { get; set; }

        public TargetEnum Target { get; set; }
    }
}
