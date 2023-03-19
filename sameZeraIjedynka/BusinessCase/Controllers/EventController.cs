using BusinessCase.Model;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.IO.Directory;
using static System.Environment;
using System.Globalization;

namespace BusinessCase.Controllers
{
    public class EventController
    {
        private static readonly string _path = GetParent(GetParent(GetParent(GetParent(CurrentDirectory)
                .ToString()).ToString()).ToString()).ToString() + @"\BusinessCase\Storage\";
        private static readonly string _filename = "EventsList.csv";

        private static readonly string _fullPath = Path.Combine(_path, _filename);

        public static List<Event> GetEvents()
        {
            using var reader = new StreamReader(_fullPath);
            CultureInfo.CurrentUICulture = new CultureInfo("en-US", false);
            using var csv = new CsvReader(reader, CultureInfo.CurrentCulture);
            csv.Read();
            csv.ReadHeader();
            var events = csv.GetRecords<Event>();
            return events.ToList();
        }
    }
}
