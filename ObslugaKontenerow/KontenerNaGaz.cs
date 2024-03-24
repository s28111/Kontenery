using System;

namespace ObslugaKontenerow
{
    public class KontenerNaGaz : Kontener, IHazardNotifier
    {
        private double cisnienie;
        public KontenerNaGaz(double masa_ladunku, double wysokosc, double waga_wlasna, double glebokosc, double maks_ladownosc, double cisnienie) : base(masa_ladunku, wysokosc, waga_wlasna, glebokosc, maks_ladownosc)
        {
            this.cisnienie = cisnienie;
            rodzaj = "G";
            numer_seryjny = "KON-" + rodzaj + "-" + liczba;
        }

        public void HazardNotify()
        {
            Console.WriteLine("Próba wykonania niebezpiecznej operacji w kontenerze: " + numer_seryjny);
        }

        public override void Zaladuj(double masa)
        {
            try
            {
                if (masa + masa_ladunku >maks_ladownosc)
                    {
                        HazardNotify();
                        throw new OverfillException();
                    }
                    else
                    {
                        masa_ladunku += masa;
                    } 
            }
            catch (OverfillException o)
            {
                Console.WriteLine(o.Message);
            }
            
        }

        public override void Oproznij()
        {
            masa_ladunku *= 0.05;
        }

        public override string ToString()
        {
            return base.ToString() + "\nCiśnienie: " + cisnienie;
        }
    }
}