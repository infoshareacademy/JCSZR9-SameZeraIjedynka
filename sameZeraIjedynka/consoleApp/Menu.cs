using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using Console.SubMenu;

namespace Console
{
    public class Menu
    {
       
    private int MenuPomocnicze { get; set; } 
    private ConsoleKeyInfo keyInfo;
    


        public void PrintWelcomeScreen()
        {
            ;
            System.Console.ForegroundColor = ConsoleColor.Yellow;
            System.Console.WriteLine("===============================================\n" +
                                     "||           WYBIERZ GLOWY KATALOG:          ||\n" +
                                     "||                                           ||\n" +
                                     "|| (poprzez wybranie z klawiatury 1,2,lub 3) ||\n" +
                                     "||                                           ||\n" +
                                     "||     1) Wyswietl wszystkie wydarzenia.     ||\n" +
                                     "||               2) Ulubione.                ||\n" +
                                     "||             3) Konfiguracja.              ||\n" +
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

  

        public void DisplayAllEvents()
        {
            // WYDARZENIA
            System.Console.ForegroundColor = ConsoleColor.Yellow;
            System.Console.Clear();
            System.Console.WriteLine("======================================================\n" +
                                     "||                  WYBIERZ PODMENU                 ||\n" +
                                     "||                                                  ||\n" +
                                     "|| a) Lista wszystkich wydarzen.                    ||\n" +
                                     "|| b) Filtrowanie po dacie, organizatorze.          ||\n" +
                                     "|| c) Wyszukiwanie wydarzen.                        ||\n" +
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
            // ULUBIONE
                System.Console.ForegroundColor = ConsoleColor.Yellow;
                System.Console.Clear();
                System.Console.WriteLine("======================================================\n" +
                                         "||                  WYBIERZ PODMENU                 ||\n" +
                                         "||                                                  ||\n" +
                                         "|| a) Dodanie / skasowanie wydarzenia z ulubionych. ||\n" +
                                         "|| b) Wywietlanie ulubionych.                       ||\n" +
                                         "|| c) Pokazywanie najbliszego w czasie...           ||\n" +
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
            // KONFIGURACJA
            System.Console.ForegroundColor = ConsoleColor.Yellow;
            System.Console.Clear();
            System.Console.WriteLine("======================================================\n" +
                                     "||                  WYBIERZ PODMENU                 ||\n" +
                                     "||                                                  ||\n" +
                                     "|| a) Adowanie / zmiana konfiguracji.               ||\n" +
                                     "|| b) Moliwo ustalenia sortowania...                ||\n" +
                                     "|| c) Format wywietlanej daty.                      ||\n" +
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


   
   

