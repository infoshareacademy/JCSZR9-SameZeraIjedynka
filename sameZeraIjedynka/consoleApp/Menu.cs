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
       
    private int MenuPomocnicze { get; set; } 
    private ConsoleKeyInfo keyInfo;
    


        public void PrintWelcomeScreen()
        {
            Console.Clear();
<<<<<<< Updated upstream:sameZeraIjedynka/consoleApp/Menu.cs
            System.Console.ForegroundColor = ConsoleColor.Yellow;
            System.Console.WriteLine("===============================================\n" +
=======
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("===============================================\n" +
>>>>>>> Stashed changes:sameZeraIjedynka/ConsoleApp/Menu.cs
                                     "||           Select from Main Menu:          ||\n" +
                                     "||                                           ||\n" +
                                     "||   ( press key 1, 2, 3, or 0 for EXIT )    ||\n" +
                                     "||                                           ||\n" +
                                     "||           1) Display all event.           ||\n" +
                                     "||               2) Favorite.                ||\n" +
                                     "||             3) Configuration.             ||\n" +
                                     "===============================================");
            keyInfo = System.Console.ReadKey(true);
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
                case 0:
<<<<<<< Updated upstream:sameZeraIjedynka/consoleApp/Menu.cs
=======
                    Console.Clear();
                    Console.WriteLine("EXIT");
                    Environment.Exit(0);
                    break;
                default:
>>>>>>> Stashed changes:sameZeraIjedynka/ConsoleApp/Menu.cs
                    Console.Clear();
                    Console.WriteLine("EXIT");
                    Environment.Exit(0);
                    break;
                default:                 
                    System.Console.Clear();
                    PrintWelcomeScreen();
                    break;
            }
        }

  

        public void DisplayAllEvents()
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
            
            keyInfo = System.Console.ReadKey(true);
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

        public void FavoritesEvents()
        {
            // Favorites
                System.Console.ForegroundColor = ConsoleColor.Yellow;
                System.Console.Clear();
                System.Console.WriteLine("======================================================\n" +
                                         "||                  WYBIERZ PODMENU                 ||\n" +
                                         "||                                                  ||\n" +
                                         "|| a) Add favorite.                                 ||\n" +
                                         "|| b) Display favorite event.                       ||\n" +
                                         "|| c) Display next event.                           ||\n" +
                                         "======================================================");
                keyInfo = System.Console.ReadKey(true);
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
        public void ConfigureEvent()
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
            keyInfo = System.Console.ReadKey(true);
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


   
   

