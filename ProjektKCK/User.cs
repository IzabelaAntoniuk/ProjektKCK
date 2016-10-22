using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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
        public string wzrost { get; set; }
        public string aktywnosc { get; set; }
        public string plec { get; set; }
        public File file;
        public User()
        {
        }
        public void zarejestrujProfil()
        {
            User us = new User();
            List<User> profileList = new List<User>();
            File newFile=new File();
            file = newFile;
            
            //List<User> profileList;
            Console.WriteLine("Rejestracja nowego użytkownika");
            Console.WriteLine("------------------------------------");

            try
            {
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

                Console.WriteLine("Płeć:");
                Console.WriteLine("1- kobieta\n2- mężczyzna");
                us.plec = Console.ReadLine();
                if (us.plec.Length <= 0 || int.Parse(us.plec) <= 0)
                {
                    do
                    {
                        Console.WriteLine("Pole wymagane. Wybierz płęć");
                        Console.WriteLine("Płeć:");
                        Console.WriteLine("1- kobieta\n2- mężczyzna");
                        us.plec = Console.ReadLine();
                    } while (us.plec.Length <= 0 || int.Parse(us.plec) <= 0);
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
                            if (keyInfo.Key != ConsoleKey.Backspace && keyInfo.Key != ConsoleKey.Enter)
                            {
                                us.haslo += keyInfo.KeyChar;
                                Console.Write("*");
                            }
                            else
                            {
                                if (keyInfo.Key == ConsoleKey.Backspace && us.haslo.Length > 0)
                                {
                                    us.haslo = us.haslo.Substring(0, (us.haslo.Length - 1));
                                    Console.Write("\b \b");
                                }
                            }
                        }
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
                Console.Write("Waga (kg):");
                us.waga = Console.ReadLine();
                if (us.waga.Length <= 0 || float.Parse(us.waga) <= 0)
                {
                    do
                    {
                        Console.WriteLine("Pole wymagane. Wprowadź właściwą wagę.");
                        Console.Write("Waga (kg): ");
                        us.waga = Console.ReadLine();
                    } while (us.waga.Length <= 0 || float.Parse(us.waga) <= 0);
                }

                Console.Write("Wzrost (cm):");
                us.wzrost = Console.ReadLine();
                if (us.wzrost.Length <= 0 || float.Parse(us.wzrost) <= 0)
                {
                    do
                    {
                        Console.WriteLine("Pole wymagane. Wprowadź właściwy wzrost.");
                        Console.Write("Wzrost (cm): ");
                        us.wzrost = Console.ReadLine();
                    } while (us.wzrost.Length <= 0 || float.Parse(us.wzrost) <= 0);
                }

                Console.WriteLine("Aktywność fizyczna:");
                Console.WriteLine("1- znikoma\n2- bardzo mala\n3- umiarkowana\n4- duża\n5- bardzo duża");
                us.aktywnosc = Console.ReadLine();
                if (us.aktywnosc.Length <= 0 || int.Parse(us.aktywnosc) <= 0)
                {
                    do
                    {
                        Console.WriteLine("Pole wymagane. Wybierz aktywność");
                        Console.WriteLine("Aktywność fizyczna:");
                        Console.WriteLine("1- znikoma\n2- bardzo mala\n3- umiarkowana\n4- duża\n5- bardzo duża");
                        us.aktywnosc = Console.ReadLine();
                    } while (us.aktywnosc.Length <= 0 || int.Parse(us.aktywnosc) <= 0);
                }

                //newFile.zapisywaniePlikuProfile(profileList);
                using (StreamWriter sr = new StreamWriter("Profile.txt",true))
                
                {

                    /*sr.Write(us.imie);
                    sr.Write(us.nazwisko);
                    sr.Write(us.plec);
                   sr.Write(us.haslo);
                     sr.Write(us.login);
                     sr.Write(us.waga);
                     sr.Write(us.wzrost);
                     sr.Write(us.aktywnosc);*/
                    string savePName = us.imie + us.nazwisko + us.plec + us.haslo + us.login + us.waga + us.wzrost + us.aktywnosc;
                    savePName = JsonConvert.SerializeObject(us);
                    sr.WriteLine(savePName);
                    sr.Close();

                }

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
                            if (keyInfo.Key != ConsoleKey.Backspace && keyInfo.Key != ConsoleKey.Enter)
                            {
                                us.haslo += keyInfo.KeyChar;
                                Console.Write("*");
                            }
                            else
                            {
                                if (keyInfo.Key == ConsoleKey.Backspace && us.haslo.Length > 0)
                                {
                                    us.haslo = us.haslo.Substring(0, (us.haslo.Length - 1));
                                    Console.Write("\b \b");
                                }
                            }
                        }
                        while (keyInfo.Key != ConsoleKey.Enter);
                    } while (us.haslo.Length <= 0);
                }
                StreamReader loadFileUser = new StreamReader("Profile.txt");
                
                    string line;
                    while ((line = loadFileUser.ReadLine()) != null)
                    {
                        User load = JsonConvert.DeserializeObject<User>(line);
                    //Console.WriteLine("\ndodalem na liste i wczytalem z pliku");
                    
                        if (load.login== us.login && load.haslo== us.haslo)
                        {
                            Console.WriteLine("\nZalogowano jako "+load.login);

                        }
                        else Console.WriteLine("Sprobuj jeszcze raz!");
                    }

                    Console.WriteLine("zamykam plik");
                    loadFileUser.Close();
                
                /*string log, has;
                using (StreamReader sr = new StreamReader("Profile.txt"))
                {
                     log = sr.ReadLine();
                     has = sr.ReadLine();
                }
                if (us.login == log && us.haslo == has)
                {
                    Console.WriteLine("\nzalogowano jako lol");

                }
                else Console.WriteLine("Sprobuj jeszcze raz!");*/

            }
            catch (FormatException)
            {
                Console.WriteLine("Wprowadziles zle dane");
            }
        }
    }
}
