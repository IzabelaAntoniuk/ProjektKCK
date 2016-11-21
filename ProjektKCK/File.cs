using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace ProjektKCK
{
    public class File
    {
        List<User> profile;

        public File()
        {
        }

        public List<User> listaProfili()
        {
            try
            {
                profile = new List<User>();
                using (StreamReader loadFileUser = new StreamReader("Profile.txt"))
                {
                    string line;
                    while ((line = loadFileUser.ReadLine()) != null)
                    {
                        User us = JsonConvert.DeserializeObject<User>(line);
                        profile.Add(us);
                    }
                    loadFileUser.Close();
                }
            }
            catch (System.IO.FileNotFoundException)
            {
                profile = new List<User>();
            }
            Console.SetCursorPosition(0, 20);

            foreach (User us in profile)
            {
                Console.WriteLine(us.imie);
            }
            return profile;
        }

        public User wczytywaniePlikuProfile(string log, string has)
        {
            User us = new User();
            using (StreamReader loadFileUser = new StreamReader("Profile.txt"))
            {
                string line;
                while ((line = loadFileUser.ReadLine()) != null)
                {
                    User load = JsonConvert.DeserializeObject<User>(line);

                    if (load.login == log && load.haslo == has)
                    {

                        us.imie = load.imie;
                        us.nazwisko = load.nazwisko;
                        us.waga = load.waga;
                        us.wzrost = load.wzrost;
                        us.dataUr = load.dataUr;
                        us.aktywnosc = load.aktywnosc;
                        us.login = load.login;
                        us.haslo = load.haslo;
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

        public void zapisywaniePliku(List<User> profileList)
        {
            using (StreamWriter openFile = new StreamWriter("Profile.txt"))
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
