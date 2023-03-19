using System;
using System.Text.Json;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text.Json;
using CsvHelper;


namespace ConsoleApp
{

    public static class GetEvents
    {


        public static List<Event> ReadCsv()
        {
            using (var reader = new StreamReader("C:\\Users\\staci\\source\\repos\\JCSZR9-SameZeraIjedynka\\sameZeraIjedynka\\consoleApp\\GetList\\EventsList.csv"))
            
                using (var csv = new CsvReader(reader, System.Globalization.CultureInfo.InvariantCulture))
                {
                    csv.Read();
                    csv.ReadHeader();
                    var events = csv.GetRecords<Event>();
                foreach (var oneevent in events)
                {
                    Console.WriteLine($"{oneevent.Name}, {oneevent.Price}");

                }
                return events.ToList();
                }

        }
    }



}




