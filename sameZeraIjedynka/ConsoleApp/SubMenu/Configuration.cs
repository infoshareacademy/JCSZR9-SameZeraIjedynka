using BusinessCase.Managers;
using BusinessCase.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Configuration
    {
        private char _selection { get; set; }

        public Configuration(char Selection)
        {
            _selection = Selection;

            switch (_selection)
            {
                case 'a':
                    ShowConfiguration();
                    break;
                case 'b':
                    Sort();
                    break;
                case 'c':
                    Format();
                    break;
                case '0':
                    Console.Clear();
                    Console.WriteLine("EXIT");
                    Environment.Exit(0);
                    break;
                default:
                    Console.Clear();
                    
                    break;
            }
        }

        public static void DisplayConfiguration()
        {
            var configuration = ConfigurationManager.GetConfiguration();
                Console.ForegroundColor = ConsoleColor.Blue;

                Console.WriteLine("\nCurrent configuration");
                Console.WriteLine("-----------------------------------------------------");
                Console.WriteLine(configuration.FirstOrDefault()?.ToString() ?? string.Empty);
                Console.WriteLine("-----------------------------------------------------");

               
          
        }

        public void ShowConfiguration()
        {
            Console.Clear();
            DisplayConfiguration();
            Console.WriteLine("Press any key to return.");
            Console.ReadKey(true);
            Console.Clear();
        }

        public void Sort()
        {
            // default
            OrderBy orderBy = OrderBy.Id;
            OrderType orderType = OrderType.Ascending;

            Console.Clear();
            Console.WriteLine("--------- Sorting setup ---------");
            DisplayConfiguration();

            Console.WriteLine("\nInput category to order by: " +
                "\n 0. Id " +
                "\n 1. Name " +
                "\n 2. Date " +
                "\n 3. Price");
            if (int.TryParse(Console.ReadLine(), out int orderByNum))
                if (Enum.IsDefined(typeof(OrderBy), orderByNum))
                   orderBy = (OrderBy)orderByNum;
                else
                    Console.WriteLine($"Input not found -> setting to {OrderBy.Id}");
            else
                Console.WriteLine($"Input not found -> setting to {OrderBy.Id}");

            Console.WriteLine("\nInput order type: " +
                "\n 0. Ascending" +
                "\n 1. Descending");
            if (int.TryParse(Console.ReadLine(), out int orderTypeNum))
                if (Enum.IsDefined(typeof(OrderType), orderTypeNum))
                    orderType = (OrderType)orderTypeNum;
                else
                    Console.WriteLine($"Input not found -> setting to {OrderType.Ascending}");
            else
                Console.WriteLine($"Input not found -> setting to {OrderType.Ascending}");

            var currentDateFormat = (ConfigurationManager.GetConfiguration().FirstOrDefault())?.dateFormat ?? "m";

            ConfigurationManager.SetConfiguration(orderBy, orderType, currentDateFormat);

            DisplayConfiguration();
            Console.WriteLine("Press any key to return.");
            Console.ReadKey(true);
            Console.Clear();
        }

        public void Format()
        {
            string[] formats = { "d", "g", "r", "m" };

            Console.Clear();
            Console.WriteLine("--------- Datetime format setup ---------");
            DisplayConfiguration();

            var currentOrderBy = (ConfigurationManager.GetConfiguration().FirstOrDefault())?.orderBy ?? OrderBy.Id;

            var currentOrderType = (ConfigurationManager.GetConfiguration().FirstOrDefault())?.orderType ?? OrderType.Ascending;

            Console.WriteLine("\nInput desired date format: ");
            foreach (var format in formats)
                Console.WriteLine($" {format}. {DateTime.Now.ToString(format)}");

            string dateFormat = Console.ReadLine() ?? "m";
            if (!formats.Contains(dateFormat))
            {
                Console.WriteLine("Input not found -> setting to 'm'");
                dateFormat = "m";
            }

            ConfigurationManager.SetConfiguration(currentOrderBy, currentOrderType, dateFormat);

            DisplayConfiguration();
            Console.WriteLine("Press any key to return.");
            Console.ReadKey(true);
            Console.Clear();
        }

    }
}
