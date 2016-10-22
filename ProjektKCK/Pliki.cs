using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace ProjektKCK
{
    public class Pliki
    {
        
        public Pliki()
        {

        }

        public void wczytywaniePlikuProfile()
        {
            using (StreamReader loadFileUser = new StreamReader("Profile.txt"))
            {
                string line;
                while ((line = loadFileUser.ReadLine()) != null)
                {
                    User load = JsonConvert.DeserializeObject<User>(line);
                    //Console.WriteLine("\ndodalem na liste i wczytalem z pliku");

                    /*if (us.login == load.login && us.haslo == load.haslo)
                    {
                        Console.WriteLine("\nZalogowano jako " + load.login);

                    }
                    else Console.WriteLine("\nSprobuj jeszcze raz!");*/
                }
                Console.WriteLine("zamykam plik");
                loadFileUser.Close();
            }
        }
        public void zapisywaniePlikuProfile(List<User> profileList)
        {
            StreamWriter openFile = new StreamWriter("Profile.txt",true);
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
