using System;
using System.Text.Json;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text.Json;
using CsvHelper;

namespace ConsoleApp
{
    //public class GetEventsList
    //{
    //    public static List<> EventsList { get; set; } = GetList<EventsList>("EventsList.json");

    //    public static List<T> GetList(string EventsList)
    //    {
    //        var filePath = Path.GetFullPath(EventsList);
    //        string itemsSerialized = File.ReadAllText(filePath, Encoding.UTF8);

    //        return JsonSerializer.Deserialize <T>> (itemsSerialized) ?? new List<>();
    //    }

    //}
    public static class GetEvents
    {


        public static void ReadCsv()
        {
            using (var reader = new StreamReader("C:\\Users\\staci\\Desktop\\C#\\AppTestowa\\AppTestowa\\EventsList.csv"))
            
                using (var csv = new CsvReader(reader, System.Globalization.CultureInfo.CurrentCulture))
                {
                    csv.Read();
                    csv.ReadHeader();
                    var events = csv.GetRecords<Event>();
                    foreach (var oneEvent in events)
                    {
                        Console.WriteLine(oneEvent.Name);

                    }
                }
            


            //ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            ///*  
            // * Points to a folder named ExcelFiles under bin\Debug in this case  
            // */
            //var filePath = FileUtil.GetFileInfo(_excelBaseFolder, "Customers.xlsx").FullName;
            //FileInfo existingFile = new(filePath);
            //using ExcelPackage package = new(existingFile);

            //var dataTable = ExcelPackageToDataTable(package);

            //// uses json.net NuGet package  
            //string jsonString = JsonConvert.SerializeObject(dataTable, Formatting.Indented);
            //// write to json in the bin\Debug folder  
            //File.WriteAllText("Exported1.json", jsonString);


        }
    }



}




