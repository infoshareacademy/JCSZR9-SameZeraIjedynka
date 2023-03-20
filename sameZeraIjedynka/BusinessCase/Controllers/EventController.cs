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
<<<<<<< HEAD

namespace BusinessCase.Controllers
{
    public class EventController
=======
using CsvHelper.TypeConversion;

namespace BusinessCase.Controllers
{
    public static class EventController
>>>>>>> origin/Piotr-Olesinski
    {
        private static readonly string _path = GetParent(GetParent(GetParent(GetParent(CurrentDirectory)
                .ToString()).ToString()).ToString()).ToString() + @"\BusinessCase\Storage\";
        private static readonly string _filename = "EventsList.csv";

        private static readonly string _fullPath = Path.Combine(_path, _filename);

        public static List<Event> GetEvents()
        {
<<<<<<< HEAD
            using var reader = new StreamReader(_fullPath);
            CultureInfo.CurrentUICulture = new CultureInfo("en-US", false);
            using var csv = new CsvReader(reader, CultureInfo.CurrentCulture);
=======
            CultureInfo.CurrentUICulture = new CultureInfo("en-US", false);

            using var reader = new StreamReader(_fullPath);
            using var csv = new CsvReader(reader, CultureInfo.CurrentUICulture);

/*        var options = new TypeConverterOptions { Formats = new[] { "dd/MM/yyyy" } };
        csv.Context.TypeConverterOptionsCache.AddOptions<DateTime>(options);*/
            
>>>>>>> origin/Piotr-Olesinski
            csv.Read();
            csv.ReadHeader();
            var events = csv.GetRecords<Event>();
            return events.ToList();
        }
    }
}
