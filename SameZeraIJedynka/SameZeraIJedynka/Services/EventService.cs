using SameZeraIJedynka.Models;


namespace SameZeraIJedynka.Services
{
    public class EventService
    {

        // provisional list of events, delete after enabling database
        private static List<EventModel> _events = new List<EventModel>
        {
            new EventModel
            {
                  Id = 1,
                  Name = "Event1",
                  Date = new DateTime(2023,10,12),
                  Organizer = "Organizer1",
                  Place = "Gdansk, Zielona 23",
                  Price = 0,
                  Capacity = 100,
                  Target = Helpers.Enums.TargetEnum.Target.kids,
                  IsFavourite = true
            },
            new EventModel
            {
                  Id = 2,
                  Name = "Event2",
                  Date = new DateTime(2024,09,22),
                  Organizer = "Organizer2",
                  Place = "Gdynia, Zielona 31",
                  Price = 10,
                  Capacity = 1200,
                  Target = Helpers.Enums.TargetEnum.Target.all,
                  IsFavourite = false
            },
            new EventModel
            {
                  Id = 3,
                  Name = "Event3",
                  Date = new DateTime(2023,05,22),
                  Organizer = "Organizer3",
                  Place = "Gdańsk, Czerwona 1",
                  Price = 0,
                  Capacity = 200,
                  Target = Helpers.Enums.TargetEnum.Target.all,
                  IsFavourite = false
            },
            new EventModel
            {
                  Id = 4,
                  Name = "Event4",
                  Date = new DateTime(2023,05,05),
                  Organizer = "Organizer4",
                  Place = "Sopot, Zolta 5",
                  Price = 0,
                  Capacity = 40,
                  Target = Helpers.Enums.TargetEnum.Target.all,
                  IsFavourite = true
            },
            new EventModel
            {
                  Id = 4,
                  Name = "Event5",
                  Date = new DateTime(2023,08,12),
                  Organizer = "Organizer5",
                  Place = "Gdansk, Czerwona 123",
                  Price = 100,
                  Capacity = 70,
                  Target = Helpers.Enums.TargetEnum.Target.grandpas,
                  IsFavourite = false
            },
            new EventModel
            {
                  Id = 4,
                  Name = "Event6",
                  Date = new DateTime(2023,07,05),
                  Organizer = "Organizer4",
                  Place = "Gdansk, Niebieska 20",
                  Price = 10,
                  Capacity = 700,
                  Target = Helpers.Enums.TargetEnum.Target.adults,
                  IsFavourite = false
            }
        };

        // return all events
        public List<EventModel> isFavorite()
        {
            return _events.Where(m => m.IsFavourite == true).ToList();
        }

        public List<EventModel> allEvents()
        {
            return _events;
        }

        public EventModel GetById(int id)
        {
            return _events.FirstOrDefault(m => m.Id == id);
        }


        public void Update(EventModel model,int id)
        {
            var events = GetById(id);
            events.IsFavourite= model.IsFavourite;
            
        }
   
    }
}
