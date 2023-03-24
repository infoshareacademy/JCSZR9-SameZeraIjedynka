using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using BusinessCase.Controllers;
using BusinessCase.Model;
using ConsoleApp;
using ConsoleApp.SubMenu;

namespace ConsoleApp
{
    public class Menu
    {
       
    private int HelperMenu { get; set; } // TODO: do usunięcia?
    private ConsoleKeyInfo keyInfo;
    


        public void PrintWelcomeScreen()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("===============================================\n" +
                                     "||           Select from Main Menu:          ||\n" +
                                     "||                                           ||\n" +
                                     "||   ( press key 1, to 5, or 0 for EXIT )    ||\n" +
                                     "||                                           ||\n" +
                                     "||           1) Display all event.           ||\n" +
                                     "||               2) Favorite.                ||\n" +
                                     "||             3) Configuration.             ||\n" +
                                     "||               4) Data entry.              ||\n" +
                                     "||             5) Data amendment.            ||\n" +
                                     "===============================================");
            keyInfo = Console.ReadKey(true);
            try
            {
                MenuCall(Convert.ToInt16(keyInfo.KeyChar.ToString()));
            }
            catch
            {
                Console.Clear();
                PrintWelcomeScreen();
            }

        }

        
      
        public void MenuCall(int selection)
        {
          
            switch (selection)
            {
                case 1:
                    DisplayAllEvents();
                    PrintWelcomeScreen();
                    break;
                case 2:
                    FavoritesEvents();
                    PrintWelcomeScreen();
                    break;
                case 3:
                    ConfigureEvent();
                    PrintWelcomeScreen();
                    break;
                case 4:
                    DataEntry();
                    PrintWelcomeScreen();
                    break;
                case 5:
                    DataAmendment();
                    PrintWelcomeScreen();
                    break;
                case 0:
                    Console.Clear();
                    Console.WriteLine("EXIT");
                    Environment.Exit(0);
                    break;
                default:
                    Console.Clear();
                    PrintWelcomeScreen();
                    break;
            }
        }

  

        public void DisplayAllEvents()
        {
            // Events
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Clear();
            Console.WriteLine("======================================================\n" +
                                     "||                  CHOOSE SUBMENU                  ||\n" +
                                     "||                                                  ||\n" +
                                     "||       ( press key a, b, c, or 0 for EXIT )       ||\n" +
                                     "||                                                  ||\n" +
                                     "|| a) All events list.                              ||\n" +
                                     "|| b) Filter events by date.                        ||\n" +
                                     "|| c) Search events.                                ||\n" +
                                     "======================================================");
                
            keyInfo = Console.ReadKey(true);
            try
            {
               Events events = new(Convert.ToChar(keyInfo.KeyChar.ToString()));
               
            }
            catch
            {
                Console.Clear();
                DisplayAllEvents();
            }
         
        }

        public void FavoritesEvents()
        {
            // Favorites
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Clear();
                Console.WriteLine("======================================================\n" +
                                         "||                  CHOOSE SUBMENU                  ||\n" +
                                         "||                                                  ||\n" +
                                         "|| a) Add favorite.                                 ||\n" +
                                         "|| b) Display favorite event.                       ||\n" +
                                         "|| c) Display next event.                           ||\n" +
                                         "======================================================");
                keyInfo = Console.ReadKey(true);
                try
                {
                    Favorites favorite = new Favorites(Convert.ToChar(keyInfo.KeyChar.ToString()));
                }
                catch
                {
                    Console.Clear();
                    FavoritesEvents();
                }

        }
        public void ConfigureEvent()
        {
            // Configuration
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Clear();
            Console.WriteLine("======================================================\n" +
                                     "||                   CHOOSE SUBMENU                 ||\n" +
                                     "||                                                  ||\n" +
                                     "|| a) Show configuration.                           ||\n" +
                                     "|| b) Configure sorting.                            ||\n" +
                                     "|| c) Date format.                                  ||\n" +
                                     "======================================================");
            keyInfo = Console.ReadKey(true);
            try
            {
                Configuration configuration = new Configuration(Convert.ToChar(keyInfo.KeyChar.ToString()));
            }
            catch
            {
                Console.Clear();
                ConfigureEvent();
            }

        }
        public void DataEntry()
        {
            DataEntry dataEntry = new DataEntry();
            Console.Clear();
            dataEntry.returnFunction();
        }

        public void DataAmendment()
        {
            DataAmendment dataAmendment = new DataAmendment();

            dataAmendment.CollectData();
            Console.ReadLine();
            Console.Clear();
            dataAmendment.returnFunction();
        }
    }
}


   
   

