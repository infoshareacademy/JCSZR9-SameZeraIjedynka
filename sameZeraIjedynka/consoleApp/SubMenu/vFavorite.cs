using BusinessCase.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class vFavorite : EventModel

    {
        public vFavorite(int Id, string Name, DateTime Date, string Organizer, string Place, int Price, int Capacity, Target Target, bool IsFavourite) 
            : base(Id, Name, Date, Organizer, Place, Price, Capacity, Target, IsFavourite)
        {
        }

        public List<vFavorite> Favorites { get; set; } = new List<vFavorite>();

        public void AddFavorite(vFavorite favorite)
        {
            Favorites.Add(favorite);
        }
        
        public void RemoveFavorite(vFavorite favorite)
        {
            Favorites.Remove(favorite);
        }

        private void DisplayEventDitails(vFavorite favorite)
        {

            //System.Console.WriteLine($"Event: {favorite.Title}, {favorite.Date}, {favorite.Organizer}, {favorite.Type}.");
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
            var matchingEvent = Favorites.Where(c => c.Name.Contains(searchEvent)).ToList();

            foreach(var favorite in matchingEvent)
            {
                DisplayEventDitails(favorite);
            }
        }

       
    }

   
}
