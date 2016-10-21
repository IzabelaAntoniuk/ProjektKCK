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
        //public User us;
        static void Main(string[] args)
        {
            User us = new ProjektKCK.User();
            
           
            Console.Write("Zaloguj sie na konto \n");
            Console.WriteLine("Nie masz konta? Zarejestruj sie!");
            int z = Convert.ToInt32(Console.ReadLine());

            switch (z)
            {
                case 1:
                    
                    us.zalogujProfil();
                    break;
                case 2:
                    us.zarejestrujProfil();
                    break;
            }
            Console.ReadKey(true);
                   
        }
    }
}
