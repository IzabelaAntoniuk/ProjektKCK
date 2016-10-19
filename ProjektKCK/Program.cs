using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektKCK
{
    class Program
    {
        static int Menu(string[] inArray)
        {
            for (int i = 0; i < inArray.Length; i++)
            {
                if (i == selectedItem)
                {//This section is what highlights the selected item
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine("-" + inArray[i]);
                    Console.ResetColor();
                }
                else
                {//this section is what prints unselected items
                    Console.WriteLine("-" + inArray[i]);
                }
            }

            bottomOffset = Console.CursorTop;
        }

            static void Main(string[] args)
        {
        }
    }
}
