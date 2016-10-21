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
        public File()
        {

        }

        public void wczytywaniePlikuProfile()
        {
            StreamReader loadFileUser = new StreamReader("Profile.txt");
            string line;
            while ((line = loadFileUser.ReadLine()) != null)
            {
                User load = JsonConvert.DeserializeObject<User>(line);             
                Console.WriteLine("dodalem na liste i wczytalem z pliku");
            }
            Console.WriteLine("zamykam plik");
            loadFileUser.Close();
        }
        public void zapisywaniePlikuProfile(List<User> profileList)
        {
            StreamWriter openFile = new StreamWriter("Profile.txt");
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
