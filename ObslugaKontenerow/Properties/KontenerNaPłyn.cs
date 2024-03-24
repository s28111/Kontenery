using System;

namespace ObslugaKontenerow.Properties
{
    public class KontenerNaPłyn : Kontener, IHazardNotifier
    {
        private bool danger;
        
        public KontenerNaPłyn(double masa_ladunku, double wysokosc, double waga_wlasna, double glebokosc, double maks_ladownosc, bool danger) : base(masa_ladunku, wysokosc, waga_wlasna, glebokosc, maks_ladownosc)
        {
            this.danger = danger;
            rodzaj = "L";
            numer_seryjny = "KON-" + rodzaj + "-" + liczba;
        }
        public void HazardNotify()
        {
            Console.WriteLine("Próba wykonania niebezpiecznej operacji.");
        }
        
        public override void  Zaladuj(double masa)
        {
            try
            {
                if (danger == false)
                {
                    if (masa + masa_ladunku > 0.9*maks_ladownosc)
                    {
                        HazardNotify();
                        throw new OverfillException();
                        
                    }
                    else
                    {
                        masa_ladunku += masa;
                    } 
                }
                else
                {
                    if (masa + masa_ladunku > 0.5*maks_ladownosc)
                    {
                        HazardNotify();
                        throw new OverfillException();
                    }
                    else
                    {
                        masa_ladunku += masa;
                    }
                }
               
            }
            catch (OverfillException o)
            {
                Console.WriteLine(o.Message);
            }
            
        }

        public override string ToString()
        {
            return base.ToString() + "\nCzy przewożony ładunek jest niebezpieczny: " + danger;
        }
    }
}