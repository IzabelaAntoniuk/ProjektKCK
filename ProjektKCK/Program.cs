using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektKCK
{
    //public User us;
    public class Program
    {
        public User us = new User();
        static void Main(string[] args)
        {
            
            //Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine("Password Masking Console Application");
            Console.WriteLine("------------------------------------");
            Console.Write("Login: ");
            
            string username = Console.ReadLine();
            string password = "";
            Console.Write("Hasło: ");
            ConsoleKeyInfo keyInfo;

            do
            {
                keyInfo = Console.ReadKey(true);
                // Skip if Backspace or Enter is Pressed
                if (keyInfo.Key != ConsoleKey.Backspace && keyInfo.Key != ConsoleKey.Enter)
                {
                    password += keyInfo.KeyChar;
                    Console.Write("*");
                }
                else
                {
                    if (keyInfo.Key == ConsoleKey.Backspace && password.Length > 0)
                    {
                        // Remove last charcter if Backspace is Pressed
                        password = password.Substring(0, (password.Length - 1));
                        Console.Write("\b \b");
                    }
                }
            }
            // Stops Getting Password Once Enter is Pressed
            while (keyInfo.Key != ConsoleKey.Enter);
            Console.WriteLine();
            Console.WriteLine("---------------------------");
            Console.WriteLine("Welcome " + username + ",");
            Console.WriteLine("Your Password is : " + password);
        }
    }
}
