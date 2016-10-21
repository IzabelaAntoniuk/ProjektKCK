using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektKCK
{
    public class User
    {
        public string imie { get; set; }
        public string nazwisko { get; set; }
        public string haslo { get; set; }
        public string login { get; set; }
        public string dataUr { get; set; }
        public int rok { get; set; }
        public int miesiac { get; set; }
        public string waga { get; set; }
        public float waga2 { get; set; }
        public float wzrost { get; set; }
        public float aktywnosc { get; set; }

        public User()
        {
        }
        public void zarejestrujProfil()
        {
            User us = new User();
            Console.WriteLine("Rejestracja nowego użytkownika");
            Console.WriteLine("------------------------------------");

            try
            {
                Console.Write("Waga:");
                // us.waga = Convert.ToInt32(Console.ReadLine());
                us.waga = Console.ReadLine();
                us.waga2 = float.Parse(waga);
                if (us.waga.Length <= 0 )
                {
                    do
                    {

                        Console.WriteLine("Pole wymagane");
                        Console.Write("Waga: ");
                        //us.waga = Convert.ToString(Console.ReadLine());
                    } while (us.waga.Length <= 0);
                }

                Console.Write("Imie:");
                us.imie = Console.ReadLine();
                if (us.imie.Length <= 0)
                {
                    do
                    {

                        Console.WriteLine("Pole wymagane");
                        Console.Write("Imie: ");
                        us.imie = Console.ReadLine();
                    } while (us.imie.Length <= 0);
                }

                Console.Write("Nazwisko:");
                us.nazwisko = Console.ReadLine();
                if (us.nazwisko.Length <= 0)
                {
                    do
                    {
                        Console.WriteLine("Pole wymagane");
                        Console.Write("Nazwisko: ");
                        us.nazwisko = Console.ReadLine();
                    } while (us.nazwisko.Length <= 0);
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
                    do
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
                    } while (us.haslo.Length <= 0);
                }
                Console.Write("\nLogin:");
                us.login = Console.ReadLine();
                if (us.login.Length <= 0)
                {
                    do
                    {

                        Console.WriteLine("Pole wymagane");
                        Console.Write("Login: ");
                        us.login = Console.ReadLine();
                    } while (us.login.Length <= 0);
                }

                //Console.Write("Data urodzenia: to trzeba rozkminic");

                


            }
            catch (FormatException)
            {
                Console.WriteLine("Wprowadziles zle dane");
            }

        }
        public void zalogujProfil()
        {


            try
            {
                User us = new ProjektKCK.User();
                Console.WriteLine("LOGOWANIE UŻYTKOWNIKA");
                Console.WriteLine("------------------------------------");

                Console.Write("Login: ");
                us.login = Console.ReadLine();
                if (us.login.Length <= 0)
                {
                    do
                    {
                        Console.WriteLine("Login nieprawidlowy");
                        Console.Write("Login: ");
                        us.login = Console.ReadLine();
                    } while (us.login.Length <= 0);


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
                    while (us.haslo.Length <= 0 && keyInfo.Key != ConsoleKey.Enter);

                    if (us.haslo.Length <= 0)
                    {
                        do
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
                        } while (us.haslo.Length <= 0);
                    }
                
                
            }
            catch (FormatException)
            {
                Console.WriteLine("Wprowadziles zle dane");
            }
        }
    }
}
