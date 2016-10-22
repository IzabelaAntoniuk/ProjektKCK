using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ProjektKCK
{
    //public User us;
    public class Program
    {
        //public File file;
        public List<User> glownyProfile = new List<User>();
        //public User us;

        static void Main(string[] args)
        {
            User us = new ProjektKCK.User();
            File file = new File();
            List<User> glownyProfile = new List<User>();


        //file.wczytywaniePlikuProfile();

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
                    //file.zapisywaniePlikuProfile(glownyProfile);
                    break;
                case 3:
                    break;
            }
            Console.ReadKey(true);
                   
        }
    }
}
