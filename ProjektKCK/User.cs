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
        public int dziennie { get; set; }
        public int zuzyte { get; set; }

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
                Console.Write("Imie: ");
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

                Console.Write("Nazwisko: ");
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

                Console.WriteLine("Płeć: ");
                Console.WriteLine("1- kobieta\n2- mężczyzna");
                us.plec = Console.ReadLine();
                if (us.plec.Length <= 0 || int.Parse(us.plec) <= 0)
                {
                    do
                    {
                        Console.WriteLine("Pole wymagane. Wybierz płeć");
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
                        Console.WriteLine("Aktywność fizyczna: ");
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
            string log;
            string pass;
            try
            {
                User us = new ProjektKCK.User();
                Console.WriteLine("LOGOWANIE UŻYTKOWNIKA");
                Console.WriteLine("------------------------------------");


                Console.Write("Login: ");
                // us.login = Console.ReadLine();
                log = Console.ReadLine();
                if (log.Length <= 0)
                {
                    do
                    {
                        Console.WriteLine("Login nieprawidlowy");
                        Console.Write("Login: ");
                        log = Console.ReadLine();
                    } while (log.Length <= 0);


                }
                Console.Write("Hasło: ");
                pass = "";
                ConsoleKeyInfo keyInfo;
                do
                {
                    keyInfo = Console.ReadKey(true);
                    // Skip if Backspace or Enter is Pressed
                    if (keyInfo.Key != ConsoleKey.Backspace && keyInfo.Key != ConsoleKey.Enter)
                    {
                        pass += keyInfo.KeyChar;
                        Console.Write("*");
                    }
                    else
                    {
                        if (keyInfo.Key == ConsoleKey.Backspace && us.haslo.Length > 0)
                        {
                            // Remove last charcter if Backspace is Pressed
                            pass = pass.Substring(0, (pass.Length - 1));
                            Console.Write("\b \b");
                        }
                    }
                }
                // Stops Getting Password Once Enter is Pressed
                while (keyInfo.Key != ConsoleKey.Enter);

                if (pass.Length <= 0)
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
                                pass += keyInfo.KeyChar;
                                Console.Write("*");
                            }
                            else
                            {
                                if (keyInfo.Key == ConsoleKey.Backspace && pass.Length > 0)
                                {
                                    pass = us.haslo.Substring(0, (pass.Length - 1));
                                    Console.Write("\b \b");
                                }
                            }
                        }
                        while (keyInfo.Key != ConsoleKey.Enter);
                    } while (pass.Length <= 0);
                }

                StreamReader loadFileUser = new StreamReader("Profile.txt");

                string line;
                while ((line = loadFileUser.ReadLine()) != null)
                {
                    User load = JsonConvert.DeserializeObject<User>(line);
                    //Console.WriteLine("\ndodalem na liste i wczytalem z pliku");
                    if (load.login == log && load.haslo == pass)
                    {
                        this.imie = load.imie;
                        this.nazwisko = load.nazwisko;
                        Console.WriteLine("\nZalogowano jako " + load.login);
                        Console.WriteLine("zamykam plik");
                        loadFileUser.Close();
                        Console.ReadKey();
                        break;
                    }
                    //else Console.WriteLine("Sprobuj jeszcze raz!");
                }
                

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

        public void wyswietlPasek()
        {
            int progress = 600;
            int total = 1200;
            //draw empty progress bar
            Console.CursorLeft = 0;
            Console.Write("["); //start
            Console.CursorLeft = 32;
            Console.Write("]"); //end
            Console.CursorLeft = 1;
            float onechunk = 30.0f / total;

            //draw filled part
            int position = 1;
            for (int i = 0; i < onechunk * progress; i++)
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.CursorLeft = position++;
                Console.Write(" ");
            }

            //draw unfilled part
            for (int i = position; i <= 31; i++)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.CursorLeft = position++;
                Console.Write(" ");
            }

            //draw totals
            Console.CursorLeft = 35;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(progress.ToString() + " of " + total.ToString() + "    "); //blanks at the end remove any excess
            
        }

        public void wyswietlProfil()
        {
            Console.WriteLine("Imie: " + imie);
            Console.WriteLine("Nazwisko: " + nazwisko);
            Console.WriteLine("Data urodzenia: " + dataUr);
            Console.WriteLine("Waga: " + waga);
            Console.WriteLine("Wzrost: " + wzrost);
            Console.WriteLine("Aktywność: " + aktywnosc);
            //   { "file":null,"imie":"Iza","nazwisko":"Ant","haslo":"moje","login":"Iza","dataUr":null,
            //"rok":0,"miesiac":0,"waga":"60","wzrost":"175","aktywnosc":"1","plec":"1"}
           // Console.ReadKey(ConsoleKey.Enter);
           /* ConsoleKeyInfo keyInfo;
            keyInfo = Console.ReadKey(true);
            if (keyInfo.Key == ConsoleKey.Enter)
                Console.Clear();*/
        }

        public void edytujProfil()
        {
            Console.SetCursorPosition(20, 15);
            Console.Write("Edytuj imie: ");
            this.imie = Console.ReadLine();
            Console.SetCursorPosition(20, 16);
            Console.Write("Edytuj nazwisko: ");
            this.nazwisko = Console.ReadLine();
            Console.SetCursorPosition(20, 17);
            Console.Write("Edytuj datę urodzenia: ");
            this.dataUr = Console.ReadLine();
            Console.SetCursorPosition(20, 18);
            Console.Write("Edytuj waga: ");
            this.waga = Console.ReadLine();
            Console.SetCursorPosition(20, 19);
            Console.Write("Edytuj wzrost: ");
            this.wzrost = Console.ReadLine();
            Console.SetCursorPosition(20, 20);
            Console.Write("Edytuj aktywność: ");
            this.aktywnosc = Console.ReadLine();
            //   { "file":null,"imie":"Iza","nazwisko":"Ant","haslo":"moje","login":"Iza","dataUr":null,
            //"rok":0,"miesiac":0,"waga":"60","wzrost":"175","aktywnosc":"1","plec":"1"}
            // Console.ReadKey(ConsoleKey.Enter);
            /* ConsoleKeyInfo keyInfo;
             keyInfo = Console.ReadKey(true);
             if (keyInfo.Key == ConsoleKey.Enter)
                 Console.Clear();*/
        }
    }
}
