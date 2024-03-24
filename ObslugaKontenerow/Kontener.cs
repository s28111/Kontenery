using System;

namespace ObslugaKontenerow
{
    public class Kontener
    {
        public double masa_ladunku, wysokosc, waga_wlasna, glebokosc, maks_ladownosc;
        public string numer_seryjny, rodzaj;
        protected static int liczba = 0;
        

        public Kontener(double masa_ladunku, double wysokosc, double waga_wlasna, double glebokosc, double maks_ladownosc)
        {
            this.masa_ladunku = masa_ladunku;
            this.maks_ladownosc = masa_ladunku;
            this.wysokosc = wysokosc;
            this.waga_wlasna = waga_wlasna;
            this.glebokosc = glebokosc;
            this.maks_ladownosc = maks_ladownosc;
            liczba++;
            numer_seryjny = "KON-" + rodzaj + "-" + liczba;
            
        }

        public virtual void Oproznij()
        {
            masa_ladunku = 0;
        }

        public virtual void Zaladuj(double masa)
        {
            try
            {
                if (masa + masa_ladunku > maks_ladownosc)
                {
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

        public override string ToString()
        {
            return "Kontener: " + numer_seryjny + "\nMasa ładunku: " + masa_ladunku + "\nWysokosc: " + wysokosc + "\nWaga własna: " + waga_wlasna + "\nGłębokość: " + glebokosc + "\nMaksymalna ładowność: " + maks_ladownosc;
        }
    }
}