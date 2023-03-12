using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class vFavorite : Events 

    {
        public vFavorite(string title, string date, string organizer, string type) : base(title, date, organizer, type)
        {
        }

        public vFavorite()
        {
        }

        public List<vFavorite> Favorites { get; set; } = new List<vFavorite>();

        public void AddFavorite(vFavorite favorite)
        {
            Favorites.Add(favorite);
        }
        
        public void RemoveFavorite(string deletedEvent)
        {
            var eventToDelete = Favorites.RemoveAll(e => e.Title.Contains(deletedEvent));

            Console.WriteLine("The event has been deleted");
        }

        private void DisplayEventDitails(vFavorite favorite)
        {

            System.Console.WriteLine($"Event: {favorite.Title}, {favorite.Date}, {favorite.Organizer}, {favorite.Type}.");
        }

        public void DisplayAllFavoriteEvents()
        {
            foreach(var favorite in Favorites) 
            {
                DisplayEventDitails(favorite);
            }
        }

        public void DisplayMatchingEvents(string searchEvent)
        {
            var matchingEvent = Favorites.Where(c => c.Title.Contains(searchEvent)).ToList();

            foreach(var favorite in matchingEvent)
            {
                DisplayEventDitails(favorite);
            }
        }

       
    }

   
}
