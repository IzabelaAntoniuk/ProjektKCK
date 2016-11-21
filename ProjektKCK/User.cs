using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Console = Colorful.Console;
using System.Drawing;

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
        public int wiek { get; set; }
        public float BMI { get; set; }
        public float PPM { get; set; }
        public float CPM { get; set; }
        public float newCPM { get; set; }
        public string kg { get; set; }
        File file = new File();
        public int dziennie { get; set; }
        public int zuzyte { get; set; }
        List<User> profileList = new List<User>();

        public User()
        {

        }

        public void uzupelnijListe()
        {
            profileList = file.listaProfili();
        }

        public void zapiszListe()
        {
            file.zapisywaniePliku(profileList);
        }

        public void zarejestrujProfil()
        {
            User us = new User();

            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("______________________", Color.DarkCyan);

            Console.SetCursorPosition(0, 2);
            Console.WriteLine("LOGOWANIE UŻYTKOWNIKA");

            Console.SetCursorPosition(0, 3);
            Console.WriteLine("______________________", Color.DarkCyan);

            Console.SetCursorPosition(0, 6);

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

                Kalkulator kal = new Kalkulator();
                kal.mojeBMI(us);
                kal.zapotrzebowanieKCAL(us);
                profileList.Add(us);
                //File load = new File();
                //file.zapisywaniePlikuProfile(profileList);
                zapiszListe();
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
                User us = new User();

                Console.CursorVisible = false;
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("______________________", Color.DarkCyan);

                Console.SetCursorPosition(0, 2);
                Console.WriteLine("LOGOWANIE UŻYTKOWNIKA");

                Console.SetCursorPosition(0, 3);
                Console.WriteLine("______________________", Color.DarkCyan);

                Console.SetCursorPosition(0, 6);
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
                        if (keyInfo.Key == ConsoleKey.Backspace && pass.Length > 0)
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
                                    pass = pass.Substring(0, (pass.Length - 1));
                                    Console.Write("\b \b");
                                }
                            }
                        }
                        while (keyInfo.Key != ConsoleKey.Enter);
                    } while (pass.Length <= 0);
                }

                // File load = new File();
                Console.SetCursorPosition(0, 16);
                // us = load.wczytywaniePlikuProfile(log, pass);

                foreach (User use in profileList)
                {
                    if (use.login == log && use.haslo == pass)
                    {
                        this.imie = use.imie;
                        this.nazwisko = use.nazwisko;
                        this.waga = use.waga;
                        this.wzrost = use.wzrost;
                        this.dataUr = use.dataUr;
                        this.aktywnosc = use.aktywnosc;
                        this.login = use.login;
                        this.plec = use.plec;
                        this.haslo = use.haslo;
                        this.BMI = use.BMI;
                        this.kg = use.kg;
                        this.CPM = use.CPM;
                        this.newCPM = use.newCPM;
                    }
                }

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
                Console.BackgroundColor = Color.Green;
                Console.CursorLeft = position++;
                Console.Write(" ");
            }

            //draw unfilled part
            for (int i = position; i <= 31; i++)
            {
                Console.BackgroundColor = Color.Red;
                Console.CursorLeft = position++;
                Console.Write(" ");
            }

            //draw totals
            Console.CursorLeft = 35;
            Console.BackgroundColor = Color.Black;
            Console.Write(progress.ToString() + " of " + total.ToString() + "    "); //blanks at the end remove any excess

        }

        public void wyswietlProfil()
        {
            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 15);
            Console.WriteLine("______________________", Color.DarkCyan);
            Console.SetCursorPosition(0, 23);
            Console.WriteLine("______________________", Color.DarkCyan);

            Console.SetCursorPosition(0, 17);
            Console.WriteLine("Imie: " + imie);
            Console.WriteLine("Nazwisko: " + nazwisko);
            Console.WriteLine("Data urodzenia: " + dataUr);
            Console.WriteLine("Waga: " + waga);
            Console.WriteLine("Wzrost: " + wzrost);
            Console.WriteLine("Aktywność: " + aktywnosc);
        }

        public void edytujProfil()
        {
            Console.SetCursorPosition(13, 15);
            Console.WriteLine("_______________________________", Color.DarkCyan);
            Console.SetCursorPosition(13, 23);
            Console.WriteLine("_______________________________", Color.DarkCyan);


            foreach (User use in profileList)
            {
                if (use.login == login && use.haslo == haslo)
                {
                    Console.SetCursorPosition(20, 17);
                    Console.Write("Edytuj imie: ");
                    this.imie = Console.ReadLine();
                    use.imie = imie;

                    Console.SetCursorPosition(20, 18);
                    Console.Write("Edytuj nazwisko: ");
                    this.nazwisko = Console.ReadLine();
                    use.nazwisko = nazwisko;

                    Console.SetCursorPosition(20, 19);
                    Console.Write("Edytuj datę urodzenia: ");
                    this.dataUr = Console.ReadLine();
                    use.dataUr = dataUr;

                    Console.SetCursorPosition(20, 20);
                    Console.Write("Edytuj waga: ");
                    this.waga = Console.ReadLine();
                    use.waga = waga;

                    Console.SetCursorPosition(20, 21);
                    Console.Write("Edytuj wzrost: ");
                    this.wzrost = Console.ReadLine();
                    use.wzrost = wzrost;

                    Console.SetCursorPosition(20, 22);
                    Console.Write("Edytuj aktywność: ");
                    this.aktywnosc = Console.ReadLine();
                    use.aktywnosc = aktywnosc;
                }
            }

            zapiszListe();
            Console.SetCursorPosition(20, 25);
            Console.WriteLine("Zaktualizowałeś dane");
            Console.SetCursorPosition(20, 26);
            Console.WriteLine("Wciśnij dowolny klawisz aby zakończyć...");
            Console.ReadKey();
        }

        public void edytujWage()
        {
            string wag = this.waga;
            foreach (User use in profileList)
            {
                if (use.login == login && use.haslo == haslo)
                {
                    Console.CursorVisible = false;
                    Console.SetCursorPosition(25, 3);
                    Console.WriteLine("_______________________________", Color.DarkCyan);
                    Console.SetCursorPosition(25, 7);
                    Console.WriteLine("_______________________________", Color.DarkCyan);

                    Console.SetCursorPosition(25, 5);
                    Console.WriteLine("Wpisz nową wagę:   kg");
                    Console.SetCursorPosition(42, 5);
                    this.waga = Console.ReadLine();
                    use.waga = waga;
                }
            }

            zapiszListe();
            Console.SetCursorPosition(25, 6);
            Console.WriteLine("Zaktualizowałeś wagę z " + wag + " na " + this.waga);
            Console.SetCursorPosition(25, 9);
            Console.WriteLine("Wciśnij dowolny klawisz aby zakończyć...");
            Console.ReadKey();
        }

        public void wyswietlLoginHaslo()
        {
            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 15);
            Console.WriteLine("_________________", Color.DarkCyan);
            Console.SetCursorPosition(0, 19);
            Console.WriteLine("_________________", Color.DarkCyan);

            Console.SetCursorPosition(0, 17);
            Console.WriteLine("Login: " + login);
            Console.WriteLine("Hasło: " + haslo);
        }

        public void edytujLoginHaslo()
        {
            foreach (User use in profileList)
            {
                if (use.login == login && use.haslo == haslo)
                {
                    Console.SetCursorPosition(13, 15);
                    Console.WriteLine("________________________", Color.DarkCyan);
                    Console.SetCursorPosition(13, 19);
                    Console.WriteLine("________________________", Color.DarkCyan);

                    Console.SetCursorPosition(17, 17);
                    Console.Write("Edytuj login: ");
                    this.login = Console.ReadLine();
                    use.login = login;
                    Console.SetCursorPosition(17, 18);
                    Console.Write("Edytuj haslo: ");
                    this.haslo = Console.ReadLine();
                    use.haslo = haslo;
                }
            }

            zapiszListe();
            Console.SetCursorPosition(17, 21);
            Console.WriteLine("Zaktualizowałeś dane");
            Console.SetCursorPosition(17, 22);
            Console.WriteLine("Wciśnij dowolny klawisz aby zakończyć...");
            Console.ReadKey();
        }
    }
}
