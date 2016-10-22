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
        public List<User> glownyProfile = new List<User>();
        //public User us;

        static int Menu(string[] inArray)
        {
            bool loopComplete = false;
            int topOffset = Console.CursorTop;
            int bottomOffset = 0;
            int selectedItem = 0;
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

        static string[] wypelnijMenu()
        {
            string[] tab = new string[3];
            tab[0] = "Zaloguj sie";
            tab[1] = "Zarejestruj sie";
            tab[2] = "Zakończ";
            return tab;
        }

        static void Main(string[] args)
        {
            Console.Title = "Projekt KCK";
            Console.WriteLine();
            Console.WriteLine("Proczę czekać, trwa ładowanie...");
            Animation();
            
            Console.SetCursorPosition(20, 0);
            Console.WriteLine();

            Console.WriteAscii("WITAJ", Color.FromArgb(211, 126, 201));

            string[] tab = wypelnijMenu();

            User us = new ProjektKCK.User();
            File file = new File();

            int selected = Menu(tab);

            switch (selected)
            {
                case 0:
                    Console.Clear();
                    us.zalogujProfil();
                    break;
                case 1:
                    Console.Clear();
                    us.zarejestrujProfil();
                   // file.zapisywaniePlikuProfile(glownyProfile);
                    break;
                case 3:
                    // file.wczytywaniePlikuProfile();
                    break;
            }
          //  Console.ReadKey(true);



            //List<User> glownyProfile = new List<User>();


            //file.wczytywaniePlikuProfile();

            

        }
    }
}
