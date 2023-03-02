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
                    submenu1();
                    break;
                case 2:
                    submenu2();
                    break;
                case 3:
                    submenu3();
                    break;  
                default:
                  
                    System.Console.Clear();
                    PrintWelcomeScreen();
                    break;
            }
        }

  

        public void submenu1()
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
                Wydarzenia wydarzenia = new Wydarzenia(Convert.ToChar(keyInfo.KeyChar.ToString()));
            }
            catch
            {
                System.Console.Clear();
                submenu1();
            }
         
        }

        public void submenu2()
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
                    Ulubione ulubione = new Ulubione(Convert.ToChar(keyInfo.KeyChar.ToString()));
                }
                catch
                {
                    System.Console.Clear();
                    submenu2();
                }

        }
        public void submenu3()
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
                Konfiguracja konfiguracja = new Konfiguracja(Convert.ToChar(keyInfo.KeyChar.ToString()));
            }
            catch
            {
                System.Console.Clear();
                submenu3();
            }

        }
    }
}


   
   

