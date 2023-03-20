using BusinessCase.Helpers;
using BusinessCase.Models;
using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Environment;

namespace BusinessCase.Managers
{
    public static class ConfigurationManager
    {

        private static readonly string _originPath = DirectoryHelper.StepThroughDirectories(CurrentDirectory);
        private static readonly string _filename = "Configuration.csv";
        private static readonly string _fullPath = Path.Combine(_originPath, _filename);
        public static List<ConfigurationModel> GetConfiguration()
        {
            CultureInfo.CurrentUICulture = new CultureInfo("en-US", false);

            using var reader = new StreamReader(_fullPath);
            using var csv = new CsvReader(reader, CultureInfo.CurrentUICulture);

            /*        var options = new TypeConverterOptions { Formats = new[] { "dd/MM/yyyy" } };
                    csv.Context.TypeConverterOptionsCache.AddOptions<DateTime>(options);*/

            csv.Read();
            csv.ReadHeader();
            var configuration = csv.GetRecords<ConfigurationModel>().ToList();
            return configuration.ToList();
        }

        public static void SetConfiguration(OrderBy orderBy, OrderType orderType)
        {
            ConfigurationModel configuration = new ConfigurationModel(orderBy, orderType);
            List<ConfigurationModel> configurationList = new List<ConfigurationModel>() { configuration };

            CultureInfo.CurrentUICulture = new CultureInfo("en-US", false);
            var csvConfig = new CsvConfiguration(CultureInfo.CurrentUICulture)
            {
                HasHeaderRecord = true,
                Delimiter = ",",
                Encoding = Encoding.UTF8
            };

            using (var writer = new StreamWriter(_fullPath))
            using (var csvWriter = new CsvWriter(writer, csvConfig))
            {
                csvWriter.WriteHeader<ConfigurationModel>();
                csvWriter.NextRecord();
                csvWriter.WriteRecords(configurationList);
            }
        }


    }
}
