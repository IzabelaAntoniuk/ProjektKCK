using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ProjektKCK
{
    public class File : User
    {
        public File(string login, string password)
        {
            this.login = login;
            this.haslo = password;
        }

        public User wczytywaniePlikuProfile()
        {
            User us = new User();
            using (StreamReader loadFileUser = new StreamReader("Profile.txt"))
            {
                string line;
                while ((line = loadFileUser.ReadLine()) != null)
                {
                    User load = JsonConvert.DeserializeObject<User>(line);

                    if (load.login == login && load.haslo == haslo)
                    {

                        us.imie = load.imie;
                        us.nazwisko = load.nazwisko;
                        us.waga = load.waga;
                        us.wzrost = load.wzrost;
                        us.dataUr = load.dataUr;
                        us.aktywnosc = load.aktywnosc;
                        us.login = load.login;
                        us.haslo = load.haslo;
                        us.plec = load.plec;
                        us.wiek = load.wiek;
                        us.BMI = load.BMI;
                        us.kg = load.kg;
                        us.CPM = load.CPM;
                        us.newCPM = load.newCPM;
                        break;
                    }
                }
                loadFileUser.Close();
            }
            return us;
        }

        public void zapisywaniePlikuProfile(List<User> profileList)
        {
            using (StreamWriter openFile = new StreamWriter("Profile.txt", true))
            {
                if (profileList.Count > 0)
                {
                    foreach (User us in profileList)
                    {
                        string savePName = us.imie + us.nazwisko + us.plec + us.haslo + us.login + us.waga + us.wzrost + us.aktywnosc;
                        savePName = JsonConvert.SerializeObject(us);
                        openFile.WriteLine(savePName);
                    }
                }
                openFile.Close();
            }
        }
    }
}
