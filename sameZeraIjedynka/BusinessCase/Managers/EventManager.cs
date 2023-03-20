using BusinessCase.Model;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Environment;
using System.Globalization;
using CsvHelper.TypeConversion;
using BusinessCase.Helpers;
using BusinessCase.Models;
using BusinessCase.Managers;

namespace BusinessCase.Controllers
{
    public static class EventManager
    {

        private static readonly string _originPath = DirectoryHelper.StepThroughDirectories(CurrentDirectory);
        private static readonly string _filename = "EventsList.csv";
        private static readonly string _fullPath = Path.Combine(_originPath, _filename);
        
        public static List<EventModel> GetEvents()
        { 
            CultureInfo.CurrentUICulture = new CultureInfo("en-US", false);

            using var reader = new StreamReader(_fullPath);
            using var csv = new CsvReader(reader, CultureInfo.CurrentUICulture);

/*        var options = new TypeConverterOptions { Formats = new[] { "dd/MM/yyyy" } };
        csv.Context.TypeConverterOptionsCache.AddOptions<DateTime>(options);*/
            
            csv.Read();
            csv.ReadHeader();
            var events = ConfigurationHelper.SortEvents(csv.GetRecords<EventModel>());
            return events;
        }

        public static List<EventModel> GetEvents(string pattern)
        {
            CultureInfo.CurrentUICulture = new CultureInfo("en-US", false);

            using var reader = new StreamReader(_fullPath);
            using var csv = new CsvReader(reader, CultureInfo.CurrentUICulture);

            /*        var options = new TypeConverterOptions { Formats = new[] { "dd/MM/yyyy" } };
                    csv.Context.TypeConverterOptionsCache.AddOptions<DateTime>(options);*/

            csv.Read();
            csv.ReadHeader();
            var events = ConfigurationHelper.SortEvents(
                            csv.GetRecords<EventModel>().Where(e =>
                                (e.Name.Contains(pattern)) ||
                                (e.Place.Contains(pattern)) ||
                                (e.Organizer.Contains(pattern))));
            return events.ToList();
        }

        public static List<EventModel> GetEvents(DateTime startDate, DateTime endDate)
        {
            CultureInfo.CurrentUICulture = new CultureInfo("en-US", false);

            using var reader = new StreamReader(_fullPath);
            using var csv = new CsvReader(reader, CultureInfo.CurrentUICulture);

            /*        var options = new TypeConverterOptions { Formats = new[] { "dd/MM/yyyy" } };
                    csv.Context.TypeConverterOptionsCache.AddOptions<DateTime>(options);*/

            csv.Read();
            csv.ReadHeader();
            var events = ConfigurationHelper.SortEvents(
                            csv.GetRecords<EventModel>().Where(e =>
                                (e.Date >= startDate) &&
                                (e.Date <= endDate)).ToList());
            return events.ToList();
        }

    }
}
