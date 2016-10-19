using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektKCK
{
    public class User
    {
        string login { get; set; }
        String haslo { get; set; }
        String imie { get; set; }
        public string nazwisko { get; set; }
        String dataUr { get; set; }
        float waga { get; set; }
        float wzrost { get; set; }
        float aktywnosc { get; set; }

        public User()
        {
        }
        public User(string login, string pSurname, string pBirthdate, string pGender, int pSize, int pHeight,
            float pWeight, string pActive, float pKilo)
        {
            this.login = login;
            
        }
    }
}
