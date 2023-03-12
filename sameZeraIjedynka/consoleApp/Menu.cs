using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using ConsoleApp;

namespace ConsoleApp
{
    public static class Menu
    {
       
   
        public static void PrintWelcomeScreen()
        {
            ;
            System.Console.ForegroundColor = ConsoleColor.Yellow;
            System.Console.WriteLine("===============================================\n" +
                                     "||           Select from Main Menu:          ||\n" +
                                     "||                                           ||\n" +
                                     "||          ( press key 1, 2, or 3 )         ||\n" +
                                     "||                                           ||\n" +
                                     "||           1) Display all event.           ||\n" +
                                     "||               2) Favorite.                ||\n" +
                                     "||             3) Configuration.             ||\n" +
                                     "===============================================");
            var keyInfo = System.Console.ReadKey(true);
            try
            {
                MenuCall(Convert.ToInt16(keyInfo.KeyChar.ToString()));
            }
            catch
            {
                System.Console.Clear();
                PrintWelcomeScreen();
            }

        }

        
      
        public static void MenuCall(int selection)
        {
          
            switch (selection)
            {
                case 1:
                    DisplayAllEvents();
                    break;
                case 2:
                    FavoritesEvents();
                    break;
                case 3:
                    ConfigureEvent();
                    break;  
                default:
                  
                    System.Console.Clear();
                    PrintWelcomeScreen();
                    break;
            }
        }

  

        public static void DisplayAllEvents()
        {
            // Events
            System.Console.ForegroundColor = ConsoleColor.Yellow;
            System.Console.Clear();
            System.Console.WriteLine("======================================================\n" +
                                     "||                  WYBIERZ PODMENU                 ||\n" +
                                     "||                                                  ||\n" +
                                     "|| a) All event list.                               ||\n" +
                                     "|| b) Event filter by date.                         ||\n" +
                                     "|| c) Event search.                                 ||\n" +
                                     "======================================================");
            
            var keyInfo = System.Console.ReadKey(true);
            try
            {
                Events wydarzenia = new Events(Convert.ToChar(keyInfo.KeyChar.ToString()));
            }
            catch
            {
                System.Console.Clear();
                DisplayAllEvents();
            }
         
        }

        public static void FavoritesEvents()
        {
            // Favorites
                System.Console.ForegroundColor = ConsoleColor.Yellow;
                System.Console.Clear();
                System.Console.WriteLine("======================================================\n" +
                                         "||                  WYBIERZ PODMENU                 ||\n" +
                                         "||                                                  ||\n" +
                                         "|| a) Add favorite event.                           ||\n" +
                                         "|| b) Display favorite event.                       ||\n" +
                                         "|| c) Search for your favorite event.               ||\n" +
                                         "|| d) Remove favorite event.                        ||\n" +
                                         "|| e) Select x to exit.                             ||\n" +
                                         "======================================================");
               var keyInfo = System.Console.ReadKey(true);
                try
                {
                    Favorites ulubione = new Favorites(Convert.ToChar(keyInfo.KeyChar.ToString()));
                }
                catch
                {
                    System.Console.Clear();
                    FavoritesEvents();
                }

        }
        public static void ConfigureEvent()
        {
            // Configuration
            System.Console.ForegroundColor = ConsoleColor.Yellow;
            System.Console.Clear();
            System.Console.WriteLine("======================================================\n" +
                                     "||                  WYBIERZ PODMENU                 ||\n" +
                                     "||                                                  ||\n" +
                                     "|| a) Add or config change.                         ||\n" +
                                     "|| b) Filter setup.                                 ||\n" +
                                     "|| c) Date format.                                  ||\n" +
                                     "======================================================");
            var keyInfo = System.Console.ReadKey(true);
            try
            {
                Configuration konfiguracja = new Configuration(Convert.ToChar(keyInfo.KeyChar.ToString()));
            }
            catch
            {
                System.Console.Clear();
                ConfigureEvent();
            }

        }
    }
}


   
   

