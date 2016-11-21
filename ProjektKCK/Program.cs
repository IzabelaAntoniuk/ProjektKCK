using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using Console = Colorful.Console;


namespace ProjektKCK
{
    //public User us;
    public class Program
    {
        //public File file;
        static List<User> glownyProfile = new List<User>();
        //public User us;

        static int Menu(string[] inArray, int selectedItem)//bottomOffset)
        {
            bool loopComplete = false;
            int topOffset = Console.CursorTop;
            int bottomOffset = 0;
            // int selectedItem = 0;
            ConsoleKeyInfo kb;

            Console.CursorVisible = false;

            //this will resise the console if the amount of elements in the list are too big
            if ((inArray.Length) > Console.WindowHeight)
            {
                throw new Exception("Too many items in the array to display");
            }

            /**
             * Drawing phase
             * */
            while (!loopComplete)
            {//This for loop prints the array out

                for (int i = 0; i < inArray.Length; i++)
                {
                    if (i == selectedItem)
                    {//This section is what highlights the selected item
                        Console.BackgroundColor = Color.Cyan;
                        Console.ForegroundColor = Color.Black;
                        Console.WriteLine("-" + inArray[i]);
                        Console.ResetColor();
                    }
                    else
                    {//this section is what prints unselected items
                        Console.WriteLine("-" + inArray[i]);
                    }
                }

                bottomOffset = Console.CursorTop;

                /*
                 * User input phase
                 * */

                kb = Console.ReadKey(true); //read the keyboard

                switch (kb.Key)
                { //react to input
                    case ConsoleKey.UpArrow:
                        if (selectedItem > 0)
                        {
                            selectedItem--;
                        }
                        else
                        {
                            selectedItem = (inArray.Length - 1);
                        }
                        break;

                    case ConsoleKey.DownArrow:
                        if (selectedItem < (inArray.Length - 1))
                        {
                            selectedItem++;
                        }
                        else
                        {
                            selectedItem = 0;
                        }
                        break;

                    case ConsoleKey.Enter:
                        loopComplete = true;
                        break;
                }
                //Reset the cursor to the top of the screen
                Console.SetCursorPosition(0, topOffset);
            }
            //set the cursor just after the menu so that the program can continue after the menu
            Console.SetCursorPosition(0, bottomOffset);

            Console.CursorVisible = true;
            return selectedItem;
        }

        static void Animation()
        {

            Image image = Image.FromFile(@"E:\Iza\Studia\Semestr V\KCK\Projekt1\loader.gif");
            FrameDimension dimension = new FrameDimension(
                               image.FrameDimensionsList[0]);
            int frameCount = image.GetFrameCount(dimension);
            StringBuilder sb;

            // Remember cursor position
            //int left = Console.WindowLeft, top = Console.WindowTop;

            char[] chars = { '#', '#', '@', '%', '=', '+',
                         '*', ':', '-', '.', ' ' };
            int czas = 15;
            for (int i = 0; czas > 0; i = (i + 1) % frameCount)
            {
                sb = new StringBuilder();
                image.SelectActiveFrame(dimension, i);

                for (int h = 0; h < image.Height; h++)
                {
                    for (int w = 0; w < image.Width; w++)
                    {
                        Color cl = ((Bitmap)image).GetPixel(w, h);
                        int gray = (cl.R + cl.G + cl.B) / 3;
                        int index = (gray * (chars.Length - 1)) / 255;

                        sb.Append(chars[index]);
                    }
                    sb.Append('\n');
                }

                Console.SetCursorPosition(0, 3);
                Console.Write(sb.ToString(), Color.FromArgb(211, 126, 201));
                czas--;

                System.Threading.Thread.Sleep(100);
            }

            Console.Clear();
        }

        static string[] wypelnijMenuGlowne()
        {
            string[] tab = new string[3];
            tab[0] = "Zaloguj sie";
            tab[1] = "Zarejestruj sie";
            tab[2] = "Zakończ";
            return tab;
        }

        static string[] wypelnijProfil()
        {
            string[] tab = new string[10];
            tab[0] = "Dodaj posiłek";
            tab[1] = "Dodaj trening";
            tab[2] = "Dodaj wagę";
            tab[3] = "Obejrzyj posiłki";
            tab[4] = "Obejrzyj treningi";
            tab[5] = "Statystyki";
            tab[5] = "Kalkulatory";
            tab[6] = "Zobacz swój profil";
            tab[7] = "Ustawienia";
            tab[8] = "Wyloguj";
            tab[9] = "Zakończ";
            return tab;
        }

        public static void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }

        public static void ClearLine(int x, int y, int lines)
        {
            for (int i = y; i <= lines; i++)
            {
                Console.SetCursorPosition(x, i);
                Console.Write(new string(' ', Console.WindowWidth));
                Console.SetCursorPosition(x, i);
                Console.CursorVisible = false;
            }
        }

        static int Decyzja(int x, int y)
        {
            int dec = 0;
            Console.SetCursorPosition(x, y);
            Console.WriteLine("Wciśnij 'e' aby edytować");
            Console.WriteLine("lub dowolny klawisz aby zakończyć...");
            ConsoleKeyInfo k;
            k = Console.ReadKey(true);
            if (k.Key != ConsoleKey.E)
                dec = 1;
            else if (k.Key == ConsoleKey.E)
                dec = 2;
            return dec;
        }

        static void Main(string[] args)
        {
            Console.Title = "Projekt KCK";
            Console.WriteLine();
            Console.WriteLine("Proczę czekać, trwa ładowanie...");
            // Animation();

            string[] tabMenuGlowne = wypelnijMenuGlowne();
            string[] tabMenuProfil = wypelnijProfil();

            Kalkulator kal = new Kalkulator();
            User us = new User();
            us.uzupelnijListe();

            while (true)
            {
                Console.SetCursorPosition(20, 0);
                Console.WriteLine();

                Console.WriteAscii("WITAJ", Color.FromArgb(211, 126, 201));


                int selected = Menu(tabMenuGlowne, 0);
                switch (selected)
                {
                    case 0:
                        Console.Clear();
                        us.zalogujProfil();
                        Console.SetCursorPosition(0, 8);
                        Console.WriteLine("\nZalogowano jako " + us.login);
                        Console.ReadKey();
                        while (true)
                        {
                            Console.Clear();
                            Console.WriteLine();
                            us.wyswietlPasek();
                            tabMenuProfil = wypelnijProfil();
                            Console.SetCursorPosition(0, 3);
                            selected = Menu(tabMenuProfil, selected);
                            switch (selected)
                            {
                                case 0:
                                    break;
                                case 1:
                                    break;
                                case 2:
                                    us.edytujWage();
                                    break;
                                case 3:
                                    break;
                                case 4:
                                    break;
                                case 5:
                                    Console.Clear();
                                    kal.mojeBMI(us);
                                    kal.zapotrzebowanieKCAL(us);
                                    Console.ReadKey();
                                    break;
                                case 6:

                                    us.wyswietlProfil();
                                    int dezycja = Decyzja(0, 25);
                                    if (dezycja == 1)
                                    {
                                        break;
                                    }
                                    else if (dezycja == 2)
                                    {
                                        ClearLine(0, 24, 27);
                                        Console.SetCursorPosition(10, 17);
                                        us.edytujProfil();
                                    }
                                    break;
                                case 7:
                                    us.wyswietlLoginHaslo();
                                    dezycja = Decyzja(0, 21);
                                    if (dezycja == 1)
                                    {
                                        break;
                                    }
                                    else if (dezycja == 2)
                                    {
                                        ClearLine(0, 21, 25);
                                        Console.SetCursorPosition(10, 17);
                                        us.edytujLoginHaslo();
                                    }
                                    break;
                                case 8:
                                    Console.Clear();
                                    break;
                                case 9:
                                    return;
                                default:
                                    break;
                            }
                            if (selected == 8)
                                break;
                        }
                        break;
                    case 1:
                        Console.Clear();
                        us.zarejestrujProfil();
                        break;
                    case 2:
                        return;
                }
            }
        }
    }
}
