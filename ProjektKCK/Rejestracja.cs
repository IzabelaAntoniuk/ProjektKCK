using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektKCK
{
    public class Rejestracja
    {
        public Rejestracja()
        {

        }
        public void zarejestrujProfil()
        {
            User us = new User();
            Console.WriteLine("Rejestracja nowego użytkownika");
            Console.WriteLine("------------------------------------");
            
            try
            {
                Console.Write("Imie:");
                us.imie = Console.ReadLine();
                if (us.imie.Length <= 0)
                {
                    Console.WriteLine("Pole wymagane");
                    Console.Write("Imie: ");
                    us.imie = Console.ReadLine();
                }
                Console.Write("Nazwisko:");
                us.nazwisko = Console.ReadLine();
                if (us.nazwisko.Length <= 0)
                {
                    Console.WriteLine("Pole wymagane");
                    Console.Write("Nazwisko: ");
                    us.nazwisko = Console.ReadLine();
                }
                Console.Write("Hasło: ");
                us.haslo = "";
                ConsoleKeyInfo keyInfo;

                do
                {
                    keyInfo = Console.ReadKey(true);
                    // Skip if Backspace or Enter is Pressed
                    if (keyInfo.Key != ConsoleKey.Backspace && keyInfo.Key != ConsoleKey.Enter)
                    {
                        us.haslo += keyInfo.KeyChar;
                        Console.Write("*");
                    }
                    else
                    {
                        if (keyInfo.Key == ConsoleKey.Backspace && us.haslo.Length > 0)
                        {
                            // Remove last charcter if Backspace is Pressed
                            us.haslo = us.haslo.Substring(0, (us.haslo.Length - 1));
                            Console.Write("\b \b");
                        }
                    }
                }
                // Stops Getting Password Once Enter is Pressed
                while (keyInfo.Key != ConsoleKey.Enter);
                if (us.haslo.Length <= 0)
                {
                    Console.WriteLine("\nHaslo nieprawidlowe.");
                    Console.Write("Hasło: ");
                    do
                    {
                        keyInfo = Console.ReadKey(true);
                        // Skip if Backspace or Enter is Pressed
                        if (keyInfo.Key != ConsoleKey.Backspace && keyInfo.Key != ConsoleKey.Enter)
                        {
                            us.haslo += keyInfo.KeyChar;
                            Console.Write("*\n");
                        }
                        else
                        {
                            if (keyInfo.Key == ConsoleKey.Backspace && us.haslo.Length > 0)
                            {
                                // Remove last charcter if Backspace is Pressed
                                us.haslo = us.haslo.Substring(0, (us.haslo.Length - 1));
                                Console.Write("\b \b");
                            }
                        }
                    }
                    // Stops Getting Password Once Enter is Pressed
                    while (keyInfo.Key != ConsoleKey.Enter);
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Wprowadziles zle dane");
            }

        }
    }
}
