using System;
using System.Security.Policy;

namespace ObslugaKontenerow.Properties
{
    public class KontenerChlodniczy : Kontener
    {
        string rodzajProduktu; 
        double temperatura;
        public KontenerChlodniczy(double masa_ladunku, double wysokosc, double waga_wlasna, double glebokosc, double maks_ladownosc, string rodzajProduktu) : base(masa_ladunku, wysokosc, waga_wlasna, glebokosc, maks_ladownosc)
        {
            this.rodzajProduktu = rodzajProduktu;
            rodzaj = "C";
            numer_seryjny = "KON-" + rodzaj + "-" + liczba;
            UstawTemperatute();
        }

        public void Zaladuj(double masa, string rodzajProduktu)
        {
            if (this.rodzajProduktu.Equals(rodzajProduktu) || this.rodzajProduktu.Equals(""))
            {
                base.Zaladuj(masa);
                this.rodzajProduktu = rodzajProduktu;
            }
           
        }

        public override void Oproznij()
        {
            base.Oproznij();
            rodzajProduktu = "";
        }

        public void UstawTemperatute()
        {
            switch (rodzajProduktu)
            {
                case "Bananas":
                    temperatura = 13.3;
                    break;
                case "Chocolate":
                    temperatura = 18;
                    break;
                case "Fish":
                    temperatura = 2;
                    break;
                case "Meat":
                    temperatura = -15;
                    break;
                case "Ice cream":
                    temperatura = -18;
                    break;
                case "Frozen pizza":
                    temperatura = -30;
                    break;
                case "Cheese":
                    temperatura = 7.2;
                    break;
                case "Sausages":
                    temperatura = 5;
                    break;
                case "Butter":
                    temperatura = 20.5;
                    break;
                case "Eggs":
                    temperatura = 19;
                    break;
            }
        }

        public override string ToString()
        {
            return base.ToString() + "\nRodzaj produktu: " + rodzajProduktu + "\nTemperatura" + temperatura;
        }
    }
}