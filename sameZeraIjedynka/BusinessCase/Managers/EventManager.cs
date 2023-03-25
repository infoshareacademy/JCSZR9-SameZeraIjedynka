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

        private static readonly string _dateFormat = "MM/dd/yyyy";
        private static readonly TypeConverterOptions _options = new TypeConverterOptions { Formats = new[] { _dateFormat } };

        // get all events list
        public static List<EventModel> GetEvents()
        { 
            using var reader = new StreamReader(_fullPath);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
           
            csv.Context.TypeConverterOptionsCache.AddOptions<DateTime>(_options);
            csv.Read();
            
            csv.ReadHeader();
            var events = ConfigurationHelper.SortEvents(csv.GetRecords<EventModel>());
            return events; 
        }

    

        // get events list matching pattern
        public static List<EventModel> GetEvents(string pattern)
        {
            using var reader = new StreamReader(_fullPath);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

            csv.Read();
            csv.ReadHeader();
            var events = ConfigurationHelper.SortEvents(
                            csv.GetRecords<EventModel>().Where(e =>
                                (e.Name.IndexOf(pattern, StringComparison.OrdinalIgnoreCase) >= 0) ||
                                (e.Place.IndexOf(pattern, StringComparison.OrdinalIgnoreCase) >= 0) ||
                                (e.Organizer.IndexOf(pattern, StringComparison.OrdinalIgnoreCase) >= 0)));
            return events.ToList();
        }

        // get events list between dates
        public static List<EventModel> GetEvents(DateTime startDate, DateTime endDate)
        {
            using var reader = new StreamReader(_fullPath);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

            csv.Read();
            csv.ReadHeader();
            var events = ConfigurationHelper.SortEvents(
                            csv.GetRecords<EventModel>().Where(e =>
                                (e.Date >= startDate) &&
                                (e.Date <= endDate)).ToList());
            return events.ToList();
        }

        public static void WriteNewEvent(List<EventModel> events)
        {
            using var writer = new StreamWriter(_fullPath);
            using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
            csv.WriteRecords(events);
        
        }
    }
}
