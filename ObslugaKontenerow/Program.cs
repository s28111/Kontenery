using System;
using ObslugaKontenerow.Properties;

namespace ObslugaKontenerow
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Kontenerowiec kontenerowiec1 = new Kontenerowiec(30.0, 5, 5000);
            Kontenerowiec kontenerowiec2 = new Kontenerowiec(20.0, 3, 2000);

            KontenerNaPłyn kontenerNaPłyn = new KontenerNaPłyn(500, 30, 200, 40, 1000, true);
            KontenerChlodniczy kontenerChlodniczy = new KontenerChlodniczy(200, 10, 100, 20, 400, "Ice cream");
            KontenerNaGaz kontenerNaGaz = new KontenerNaGaz(150, 20, 100, 25, 300, 800);
            kontenerChlodniczy.Zaladuj(300);
            kontenerChlodniczy.Zaladuj(300,"Bananas");
            kontenerChlodniczy.Oproznij();
            kontenerChlodniczy.Zaladuj(300,"Bananas");
            kontenerowiec1.ZaladujNaStatek(kontenerChlodniczy);
            kontenerowiec1.ZaladujNaStatek(kontenerNaGaz);
            kontenerowiec1.ZaladujNaStatek(kontenerNaPłyn);
            kontenerowiec1.OpisStatku();
            Kontenerowiec.TransferShipToship(kontenerowiec1,kontenerowiec2,"KON-L-1");
            kontenerowiec1.OpisStatku();
            kontenerowiec2.OpisStatku();
            kontenerowiec2.UsunKontener("KON-L-1");
            kontenerowiec1.ZastapKontener("KON-L-1", kontenerChlodniczy);
            kontenerowiec1.OpisStatku();
            kontenerowiec2.OpisStatku();
            
        }
    }
}