using static SameZeraIJedynka.Helpers.Enums.TargetEnum;

namespace SameZeraIJedynka.Models
{
    public class EventModel
    {
        public int? Id { get; set; }

        public string? Name { get; set; }
        public DateTime? Date { get; set; }
        public string? Organizer { get; set; }
        public string? Place { get; set; }
        public int? Price { get; set; }
        public int? Capacity { get; set; }
        public Target? Target { get; set; }
        public bool? IsFavourite { get; set; }
    }
}
