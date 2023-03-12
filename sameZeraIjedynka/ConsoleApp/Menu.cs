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
    public class Menu
    {
       
    private int HelperMenu { get; set; } 
    private ConsoleKeyInfo keyInfo;
    


        public void PrintWelcomeScreen()
        {
            ;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("===============================================\n" +
                                     "||           Select from Main Menu:          ||\n" +
                                     "||                                           ||\n" +
                                     "||          ( press key 1, 2, or 3 )         ||\n" +
                                     "||                                           ||\n" +
                                     "||           1) Display all event.           ||\n" +
                                     "||               2) Favorite.                ||\n" +
                                     "||             3) Configuration.             ||\n" +
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
                    break;
                case 2:
                    FavoritesEvents();
                    break;
                case 3:
                    ConfigureEvent();
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
                                     "|| a) All event list.                               ||\n" +
                                     "|| b) Event filter by date.                         ||\n" +
                                     "|| c) Event search.                                 ||\n" +
                                     "======================================================");
                
            keyInfo = Console.ReadKey(true);
            try
            {
                Events events = new Events(Convert.ToChar(keyInfo.KeyChar.ToString()));
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
                                     "|| a) Add or config change.                         ||\n" +
                                     "|| b) Filter setup.                                 ||\n" +
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
    }
}


   
   

