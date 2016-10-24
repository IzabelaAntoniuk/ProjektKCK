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
        public string rok { get; set; }
        public string miesiac { get; set; }
        public string dzien { get; set; }
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
        List<User> profileList = new List<User>();

        public int dziennie { get; set; }
        public int zuzyte { get; set; }

        public User()
        {
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
                Console.WriteLine("Data urodzenia:  ");
                Console.Write("Rok:  ");
                us.rok = Console.ReadLine();
                if (us.rok.Length <= 0 || int.Parse(us.rok) >= 2016 || int.Parse(us.rok) < 1899)
                {

                    do
                    {
                        Console.WriteLine("Wprowadź odpowiedni rok");
                        Console.Write("Rok: ");
                        us.rok = Console.ReadLine();
                    } while (us.rok.Length <= 0 || int.Parse(us.rok) >= 2016 || int.Parse(us.rok) < 1899);
                }

                Console.Write("Miesiąc:  ");
                us.miesiac = Console.ReadLine();
                if (us.miesiac.Length <= 0 || int.Parse(us.miesiac) > 12 || int.Parse(us.miesiac) < 1)
                {
                    do
                    {
                        Console.WriteLine("Wprowadź odpowiedni miesiąc");
                        Console.Write("Miesiąc:  ");
                        us.miesiac = Console.ReadLine();
                    } while (us.miesiac.Length <= 0 || int.Parse(us.miesiac) > 12 || int.Parse(us.miesiac) < 1);

                }
                Console.Write("Dzień:  ");
                us.dzien = Console.ReadLine();
                if (us.dzien.Length <= 0 || (int.Parse(us.dzien) > 32 || int.Parse(us.dzien) < 1))
                {
                    do
                    {
                        Console.WriteLine("Wprowadź odpowiedni dzień");
                        Console.Write("Dzień:  ");
                        us.dzien = Console.ReadLine();
                    } while (us.dzien.Length <= 0 || (int.Parse(us.dzien) > 32 || int.Parse(us.dzien) < 1));
                }

                us.dataUr = us.rok + "-" + us.miesiac + "-" + us.dzien;

                us.wiek = DateTime.Now.Year - int.Parse(us.rok);
                Console.WriteLine("Wiek: " + us.wiek);

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
                StreamReader loadFileUser = new StreamReader("Profile.txt");

                string line;
                while ((line = loadFileUser.ReadLine()) != null)
                {
                    User load1 = JsonConvert.DeserializeObject<User>(line);
                    //Console.WriteLine("\ndodalem na liste i wczytalem z pliku");
                    if (load1.login == us.login)
                    {
                        do
                        {
                            Console.WriteLine("Podany login już istnieje!");
                            Console.Write("Login: ");
                            us.login = Console.ReadLine();
                        } while (load1.login == us.login);
                        loadFileUser.Close();
                        break;
                    }
                }

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

                Console.WriteLine("Chce schudnąć(-)/przytyć tygodniowo (kg): ");
                us.kg = Console.ReadLine();
                if (us.kg.Length <= 0)
                {
                    do
                    {
                        Console.WriteLine("Pole wymagane. ");
                        Console.Write("Chce schudnąć(-)/przytyć tygodniowo(kg): ");
                        us.kg = Console.ReadLine();

                    } while (us.kg.Length <= 0);
                }

                Kalkulator kal = new Kalkulator();
                kal.mojeBMI(us);
                kal.zapotrzebowanieKCAL(us);
                profileList.Add(us);
                File load = new File(us.login, us.haslo);
                load.zapisywaniePlikuProfile(profileList);
                /*
                using (StreamWriter sr = new StreamWriter("Profile.txt",true))
                
                {
                    string savePName = us.imie + us.nazwisko + us.plec + us.haslo + us.login + us.waga + us.wzrost + us.aktywnosc+us.BMI+us.kg;
                    savePName = JsonConvert.SerializeObject(us);
                    sr.WriteLine(savePName);
                    sr.Close();

                }*/

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
                /*StreamReader loadFileUser1 = new StreamReader("Profile.txt");

                string line1;
                while ((line1 = loadFileUser1.ReadLine()) != null)
                {
                    User load = JsonConvert.DeserializeObject<User>(line1);
                    //Console.WriteLine("\ndodalem na liste i wczytalem z pliku");
                    if (log!=load.login)
                    {
                        do
                        {
                            Console.WriteLine("Nieprawidlowy login");
                            Console.Write("Login: ");
                            log = Console.ReadLine();
                        } while (load.login != log);
                        loadFileUser1.Close();
                        break;
                    }
                }*/
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
                File load = new File(log, pass);
                Console.SetCursorPosition(0, 16);
                us = load.wczytywaniePlikuProfile();
                this.imie = us.imie;
                this.nazwisko = us.nazwisko;
                this.waga = us.waga;
                this.wzrost = us.wzrost;
                this.dataUr = us.dataUr;
                this.plec = us.plec;
                this.wiek = us.wiek;
                this.aktywnosc = us.aktywnosc;
                this.BMI = us.BMI;
                this.kg = us.kg;
                this.CPM = us.CPM;
                this.newCPM = us.newCPM;
                /* StreamReader loadFileUser = new StreamReader("Profile.txt");

                 string line;
                 while ((line = loadFileUser.ReadLine()) != null)
                 {
                     User load = JsonConvert.DeserializeObject<User>(line);
                     //Console.WriteLine("\ndodalem na liste i wczytalem z pliku");
                     if (load.login == log && load.haslo == pass)
                     {
                         this.imie = load.imie;
                         this.nazwisko = load.nazwisko;
                         this.waga = load.waga;
                         this.wzrost = load.wzrost;
                         this.dataUr = load.dataUr;
                         this.plec = load.plec;
                         this.wiek = load.wiek;
                         this.aktywnosc = load.aktywnosc;
                         this.BMI = load.BMI;
                         this.kg = load.kg;
                         this.CPM = load.CPM;
                         this.newCPM = load.newCPM;

                         Console.WriteLine("\nZalogowano jako " + load.login);
                         loadFileUser.Close();
                         Console.ReadKey();
                         break;
                     }
                     //else Console.WriteLine("Sprobuj jeszcze raz!");
                 }*/


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
            Console.WriteLine("Imie: " + imie);
            Console.WriteLine("Nazwisko: " + nazwisko);
            Console.WriteLine("Data urodzenia: " + dataUr);
            Console.WriteLine("Wiek: " + wiek);
            Console.WriteLine("Płeć: " + plec);
            Console.WriteLine("Waga: " + waga);
            Console.WriteLine("Wzrost: " + wzrost);
            Console.WriteLine("Aktywność: " + aktywnosc);
            Console.WriteLine("Kg: " + kg);
            Console.WriteLine("BMI: " + BMI);
            Console.WriteLine("CPM: " + CPM);
            Console.WriteLine("Nowe CPM: " + newCPM);
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
            Console.SetCursorPosition(13, 15);
            Console.WriteLine("_______________________________", Color.DarkCyan);
            Console.SetCursorPosition(13, 23);
            Console.WriteLine("_______________________________", Color.DarkCyan);

            Console.SetCursorPosition(20, 17);
            Console.Write("Edytuj imie: ");
            this.imie = Console.ReadLine();
            Console.SetCursorPosition(20, 18);
            Console.Write("Edytuj nazwisko: ");
            this.nazwisko = Console.ReadLine();
            Console.SetCursorPosition(20, 19);
            Console.Write("Edytuj datę urodzenia: ");
            this.dataUr = Console.ReadLine();
            Console.SetCursorPosition(20, 20);
            Console.Write("Edytuj waga: ");
            this.waga = Console.ReadLine();
            Console.SetCursorPosition(20, 21);
            Console.Write("Edytuj wzrost: ");
            this.wzrost = Console.ReadLine();
            Console.SetCursorPosition(20, 22);
            Console.Write("Edytuj aktywność: ");
            this.aktywnosc = Console.ReadLine();


            Console.SetCursorPosition(20, 25);
            Console.WriteLine("Zaktualizowałeś dane");
            Console.SetCursorPosition(20, 26);
            Console.WriteLine("Wciśnij dowolny klawisz aby zakończyć...");
            Console.ReadKey();
        }

        public void edytujWage()
        {
            string wag = this.waga;
            Console.CursorVisible = false;
            Console.SetCursorPosition(25, 3);
            Console.WriteLine("_______________________________", Color.DarkCyan);
            Console.SetCursorPosition(25, 7);
            Console.WriteLine("_______________________________", Color.DarkCyan);

            Console.SetCursorPosition(25, 5);
            Console.WriteLine("Wpisz nową wagę:   kg");
            Console.SetCursorPosition(42, 5);
            this.waga = Console.ReadLine();


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
            Console.SetCursorPosition(13, 15);
            Console.WriteLine("________________________", Color.DarkCyan);
            Console.SetCursorPosition(13, 19);
            Console.WriteLine("________________________", Color.DarkCyan);

            Console.SetCursorPosition(17, 17);
            Console.Write("Edytuj login: ");
            this.login = Console.ReadLine();
            Console.SetCursorPosition(17, 18);
            Console.Write("Edytuj haslo: ");
            this.haslo = Console.ReadLine();


            Console.SetCursorPosition(17, 21);
            Console.WriteLine("Zaktualizowałeś dane");
            Console.SetCursorPosition(17, 22);
            Console.WriteLine("Wciśnij dowolny klawisz aby zakończyć...");
            Console.ReadKey();
        }
    }
}
