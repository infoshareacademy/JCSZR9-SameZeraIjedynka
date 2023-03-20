using BusinessCase.Managers;
using BusinessCase.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
                    AddOrChange();
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
            foreach (var item in configuration)
            {
                Console.ForegroundColor = ConsoleColor.Blue;

                Console.WriteLine("\nCurrent configuration");
                Console.WriteLine("------------------------------");
                Console.WriteLine(item);
                Console.WriteLine("------------------------------\n");

                Console.ForegroundColor = ConsoleColor.Yellow;
            }
        }

        public void AddOrChange()
        {
            Console.Clear();
            Console.WriteLine("List of the events");
            Console.ReadKey(true);
        }
        public void Sort()
        {
            Console.Clear();
            Console.WriteLine("--------- Sorting setup ---------");
            DisplayConfiguration();

            Console.WriteLine("Input category to order by ( Id / Name / Date / Price ):");
            Enum.TryParse(Console.ReadLine(), out OrderBy orderBy);

            Console.WriteLine("Input order type ( Ascending / Descending )");
            Enum.TryParse(Console.ReadLine(), out OrderType orderType);

            ConfigurationManager.SetConfiguration(orderBy, orderType);

            DisplayConfiguration();
            Console.ReadKey(true);
        }
        public void Format()
        {
            Console.Clear();
            Console.WriteLine("Event search");
            Console.ReadKey(true);
        }

    }
}
