using BusinessCase.Managers;
using BusinessCase.Model;
using BusinessCase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessCase.Helpers
{
    public class ConfigurationHelper
    {
        public static List<EventModel> SortEvents(IEnumerable<EventModel> events)
        {
            List<ConfigurationModel> currentConfiguration = ConfigurationManager.GetConfiguration();
            List<EventModel> sortedEvents;

            var orderBy = (currentConfiguration.FirstOrDefault())?.orderBy ?? OrderBy.Id;
            var orderType = (currentConfiguration?.FirstOrDefault())?.orderType ?? OrderType.Ascending;
            // name
            if (orderBy.Equals(OrderBy.Name) && orderType.Equals(OrderType.Ascending))
                sortedEvents = events.OrderBy(x => x.Name).ToList();
            else if (orderBy.Equals(OrderBy.Name) && orderType.Equals(OrderType.Descending))
                sortedEvents = events.OrderByDescending(x => x.Name).ToList();
            // date
            else if (orderBy.Equals(OrderBy.Date) && orderType.Equals(OrderType.Ascending))
                sortedEvents = events.OrderBy(x => x.Date).ToList();
            else if (orderBy.Equals(OrderBy.Date) && orderType.Equals(OrderType.Descending))
                sortedEvents = events.OrderByDescending(x => x.Date).ToList();
            // price
            else if (orderBy.Equals(OrderBy.Price) && orderType.Equals(OrderType.Ascending))
                sortedEvents = events.OrderBy(x => x.Price).ToList();
            else if (orderBy.Equals(OrderBy.Price) && orderType.Equals(OrderType.Descending))
                sortedEvents = events.OrderByDescending(x => x.Price).ToList();
            // id
            else if (orderBy.Equals(OrderBy.Id) && orderType.Equals(OrderType.Descending))
                sortedEvents = events.OrderByDescending(x => x.Id).ToList();
            else
                sortedEvents = events.OrderBy(x => x.Id).ToList();

            return sortedEvents;
        }

        public static string GetDateFormat()
        {
            List<ConfigurationModel> currentConfiguration = ConfigurationManager.GetConfiguration();

            var dateFormat = (currentConfiguration.FirstOrDefault())?.dateFormat ?? "dd/MM/yyyy";

            return dateFormat;
        }

    }
}
