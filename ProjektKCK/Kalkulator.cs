using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektKCK
{
    
    public class Kalkulator
    {
        public float BMI { get; set; }
        public float PPM { get; set; }
        public float CPM { get; set; }
        public float newCPM { get; set; }
        public float waga { get; set; }
        public float wzrost { get; set; }
        public int wiek { get; set; }
        public int aktywnosc { get; set; }
        public int plec { get; set; }
        public float kilo { get; set; }

        private User us;

        public Kalkulator() { }
        public Kalkulator(User user)
        {
            this.us = user;
            this.waga =float.Parse(us.waga);
            this.wzrost = float.Parse(us.wzrost);
            this.wiek = us.wiek;
            this.aktywnosc = int.Parse(us.aktywnosc);
            this.plec = Int32.Parse(us.plec);
            this.kilo = float.Parse(us.kg);
            this.newCPM = us.newCPM;
            // this.BMI = us.BMI;
        }
        public void mojeBMI(User user)
        {
          
            user.BMI = ((float.Parse(user.waga) / (float.Parse(user.wzrost) * float.Parse(user.wzrost))) * 10000);

          if (user.BMI < 18.5)
            {
                Console.WriteLine("Twoje BMI = " + user.BMI + " Masz niedowage.");
            }
            else if (user.BMI > 18.5 && user.BMI < 24.9)
            {
                Console.WriteLine("Twoje BMI = " + user.BMI + ". Masz prawidlowa mase ciala.");
            }
            else if (user.BMI > 25 && user.BMI < 29.9)
            {
                Console.WriteLine("Twoje BMI = " + user.BMI + ". Masz nadwage.");
            }
            else if (user.BMI > 30 && user.BMI < 40)
            {
                Console.WriteLine("Twoje BMI = " + user.BMI + ". Jestes otyly.");
            }
            else
            {
                Console.WriteLine("Twoje BMI = " + user.BMI + ". Jestes bardzo otyly");
            }
        }
        public void zapotrzebowanieKCAL(User user)
        {

            if (Int32.Parse(user.plec)==1)
            {
                
                user.PPM = (float)(655.1 + (9.56 * (float.Parse(user.waga))) + (1.85 * (float.Parse(user.wzrost))) - (4.67 * (user.wiek)));
                if (user.wiek > 0 && user.wiek < 19)
                {
                    switch (Int32.Parse(user.aktywnosc))
                    {
                        case 1: user.CPM = user.PPM * 1; break;
                        case 2: user.CPM = (float)(user.PPM * 1.16); break;
                        case 3: user.CPM = (float)(user.PPM * 1.36); break;
                        case 4: user.CPM = (float)(user.PPM * 1.56); break;
                        case 5: user.CPM = (float)(user.PPM * 1.76); break;
                    }
                    Console.WriteLine("Twoje dzienne zapotrzebowanie kaloryczne wynosi " + user.CPM + "kcal dziennie.");
                   if (float.Parse(user.kg) > 0)
                    {
                        user.newCPM = (float)(user.CPM + (1000 * ((float.Parse(user.kg)))) / 7);
                        Console.WriteLine("Jezeli chcesz przytyc " + float.Parse(user.kg) + "kg tygodniowo nalezy jesc " + user.newCPM + "kcal dziennie.");
                    }
                    else if (float.Parse(user.kg) < 0)
                    {
                        user.newCPM = (float)(user.CPM + (1000 * (float.Parse(user.kg))) / 7);
                        Console.WriteLine("Jezeli chcesz schudnąć " + float.Parse(user.kg) + "kg tygodniowo nalezy jesc " + user.newCPM + "kcal dziennie.");
                    }
                    else
                    {
                        user.newCPM = user.CPM;
                        Console.WriteLine("Jezeli chcesz utrzymać swoją wagę powinieneś jeść " + user.newCPM + "kcal dziennie.");
                    }

                }
                else if (user.wiek >= 19)
                {
                    switch (Int32.Parse(user.aktywnosc))
                    {
                        case 1: user.CPM = user.PPM * 1; break;
                        case 2: user.CPM = (float)(user.PPM * 1.12); break;
                        case 3: user.CPM = (float)(user.PPM * 1.27); break;
                        case 4: user.CPM = (float)(user.PPM * 1.45); break;
                        case 5: user.CPM = (float)(user.PPM * 1.60); break;
                    }
                    Console.WriteLine("Twoje dzienne zapotrzebowanie kaloryczne wynosi " + user.CPM + "kcal dziennie.");

                    if (float.Parse(user.kg) > 0)
                    {
                        user.newCPM = (float)(user.CPM + (1000 * ((float.Parse(user.kg)))) / 7);
                        Console.WriteLine("Jezeli chcesz przytyc " + float.Parse(user.kg) + "kg tygodniowo nalezy jesc " + user.newCPM + "kcal dziennie.");
                    }
                    else if (float.Parse(user.kg) < 0)
                    {
                        user.newCPM = (float)(user.CPM + (1000 * (float.Parse(user.kg))) / 7);
                        Console.WriteLine("Jezeli chcesz schudnąć " + float.Parse(user.kg) + "kg tygodniowo nalezy jesc " + user.newCPM + "kcal dziennie.");
                    }
                    else
                    {
                        user.newCPM = user.CPM;
                        Console.WriteLine("Jezeli chcesz utrzymać swoją wagę powinieneś jeść " + user.newCPM + "kcal dziennie.");
                    }
                }
                else Console.WriteLine("Wiek musi byc wiekszy od 0.");

                
                }
                else
                {
                    user.PPM = (float)(66.5 + (13.75 * (float.Parse(user.waga))) + (5.003 * (float.Parse(user.wzrost))) - (6.755 * (user.wiek)));

                    if (user.wiek > 0 && user.wiek < 19)
                    {
                        switch (Int32.Parse(user.aktywnosc))
                        {
                            case 1: user.CPM = user.PPM * 1; break;
                            case 2: user.CPM = (float)(user.PPM * 1.13); break;
                            case 3: user.CPM = (float)(user.PPM * 1.26); break;
                            case 4: user.CPM = (float)(user.PPM * 1.42); break;
                            case 5: user.CPM = (float)(user.PPM * 1.66); break;
                        }
                        Console.WriteLine("Twoje dzienne zapotrzebowanie kaloryczne wynosi " + user.CPM + "kcal dziennie.");

                    if (float.Parse(user.kg) > 0)
                    {
                        user.newCPM = (float)(user.CPM + (1000 * ((float.Parse(user.kg)))) / 7);
                        Console.WriteLine("Jezeli chcesz przytyc " + float.Parse(user.kg) + "kg tygodniowo nalezy jesc " + user.newCPM + "kcal dziennie.");
                    }
                    else if (float.Parse(user.kg) < 0)
                    {
                        user.newCPM = (float)(user.CPM + (1000 * (float.Parse(user.kg))) / 7);
                        Console.WriteLine("Jezeli chcesz schudnąć " + float.Parse(user.kg) + "kg tygodniowo nalezy jesc " + user.newCPM + "kcal dziennie.");
                    }
                    else
                    {
                        user.newCPM = user.CPM;
                        Console.WriteLine("Jezeli chcesz utrzymać swoją wagę powinieneś jeść " + user.newCPM + "kcal dziennie.");
                    }
                }
                    else if (user.wiek >= 19)
                    {
                        switch (Int32.Parse(user.aktywnosc))
                        {
                            case 1: user.CPM = user.PPM * 1; break;
                            case 2: user.CPM = (float)(user.PPM * 1.12); break;
                            case 3: user.CPM = (float)(user.PPM * 1.25); break;
                            case 4: user.CPM = (float)(user.PPM * 1.48); break;
                            case 5: user.CPM = (float)(user.PPM * 1.57); break;
                        }
                        Console.WriteLine("Twoje dzienne zapotrzebowanie kaloryczne wynosi " + user.CPM + "kcal dziennie.");

                    if (float.Parse(user.kg) > 0)
                    {
                        user.newCPM = (float)(user.CPM + (1000 * ((float.Parse(user.kg)))) / 7);
                        Console.WriteLine("Jezeli chcesz przytyc " + float.Parse(user.kg) + "kg tygodniowo nalezy jesc " + user.newCPM + "kcal dziennie.");
                    }
                    else if (float.Parse(user.kg) < 0)
                    {
                        user.newCPM = (float)(user.CPM + (1000 * (float.Parse(user.kg))) / 7);
                        Console.WriteLine("Jezeli chcesz schudnąć " + float.Parse(user.kg) + "kg tygodniowo nalezy jesc " + user.newCPM + "kcal dziennie.");
                    }
                    else
                    {
                        user.newCPM = user.CPM;
                        Console.WriteLine("Jezeli chcesz utrzymać swoją wagę powinieneś jeść " + user.newCPM + "kcal dziennie.");
                    }

                }
                    else Console.WriteLine("Wiek musi byc wiekszy od 0");
                }
                
            }
        }
    }

