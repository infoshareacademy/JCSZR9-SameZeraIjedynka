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
            using (var reader = new StreamReader("C:\\Users\\staci\\Desktop\\C#\\AppTestowa\\AppTestowa\\EventsList.csv"))
            
                using (var csv = new CsvReader(reader, System.Globalization.CultureInfo.CurrentCulture))
                {
                    csv.Read();
                    csv.ReadHeader();
                    var events = csv.GetRecords<Event>();
                    //foreach (var oneEvent in events)
                    //{
                    //    Console.WriteLine(oneEvent.Name);

                    //}
                    return events.ToList();
                }

        }
    }



}




