using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektKCK
{
    public class User
    {
        public string login { get; set; }
        public string haslo { get; set; }
        public string imie { get; set; }
        public string nazwisko { get; set; }
        public string dataUr { get; set; }
        public float waga { get; set; }
        public float wzrost { get; set; }
        public float aktywnosc { get; set; }

        public User()
        {
        }
        public User(string login, string haslo)
        {
            this.login = login;
            this.haslo = haslo;
            
        }
    }
}
