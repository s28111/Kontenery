using System;
using System.Collections.Generic;
using ObslugaKontenerow.Properties;

namespace ObslugaKontenerow
{
    public class Kontenerowiec
    { 
        List<Kontener> kontenery; 
        double maksymalnaPredkosc;
        int pojemnosc;
        double maksWagaKontenerow;

        public Kontenerowiec(double maksymalnaPredkosc, int pojemnosc, double maksWagaKontenerow)
        {
            this.maksymalnaPredkosc = maksymalnaPredkosc;
            this.pojemnosc = pojemnosc;
            this.maksWagaKontenerow = maksWagaKontenerow;
            kontenery = new List<Kontener>();
        }

        public void ZaladujNaStatek(Kontener kontener)
        {
            if (kontenery.Count + 1 > pojemnosc)
            {
                Console.WriteLine("Kontenerowiec ma juz maksymalna liczbe kontenerow.");
            }else if (ZliczWage() + kontener.masa_ladunku + kontener.waga_wlasna > maksWagaKontenerow)
            {
                Console.WriteLine("Przekroczono wage kontenerow na Kontenerowcu");
            }
            else
            {
                kontenery.Add(kontener);
            }
        }

        public void ZaladujNaStatek(List<Kontener> konteneryDoDodania)
        {
            foreach (Kontener kontener in konteneryDoDodania)
            {
                if (kontenery.Count + 1 > pojemnosc)
                {
                    Console.WriteLine("Kontenerowiec ma juz maksymalna liczbe kontenerow. Nie dodano kontenera: " + kontener.numer_seryjny);
                }else if (ZliczWage() + kontener.masa_ladunku + kontener.waga_wlasna > maksWagaKontenerow)
                {
                    Console.WriteLine("Przekroczono wage kontenerow na Kontenerowcu. Nie dodano kontenera: " + kontener.numer_seryjny);
                }
                else
                {
                    kontenery.Add(kontener);
                }
            }
        }

        private double ZliczWage()
        {
            double waga = 0;
            foreach (Kontener kontener in kontenery)
            {
                waga += kontener.waga_wlasna + kontener.masa_ladunku;
            }
            return waga;
        }

        public void OpisStatku()
        {
            foreach (Kontener kontener in kontenery)
            {
                if (kontener is KontenerChlodniczy)
                {
                    Console.WriteLine((KontenerChlodniczy)kontener + "\n");
                }else if (kontener is KontenerNaPłyn)
                {
                    Console.WriteLine((KontenerNaPłyn)kontener + "\n");
                }else if (kontener is KontenerNaGaz)
                {
                    Console.WriteLine((KontenerNaGaz)kontener + "\n");
                }
            }
        }

        public static void TransferShipToship(Kontenerowiec kontenerowiec1, Kontenerowiec kontenerowiec2,
            String numerKontenera)
        {
            Kontener kontenerDoTransferu = null;
            foreach (Kontener kontener in kontenerowiec1.kontenery)
            {
                if (kontener.numer_seryjny.Equals(numerKontenera))
                {
                    kontenerDoTransferu = kontener;
                }
            }
            kontenerowiec1.kontenery.Remove(kontenerDoTransferu);
            kontenerowiec2.ZaladujNaStatek(kontenerDoTransferu);
        }

        public void UsunKontener(String numerKontenera)
        {
            Kontener kontenerDoUsuniecia = null;
            foreach (Kontener kontener in kontenery)
            {
                if (kontener.numer_seryjny.Equals(numerKontenera))
                {
                    kontenerDoUsuniecia = kontener;
                }
            }
            kontenery.Remove(kontenerDoUsuniecia);
        }

        public void ZastapKontener(String numerKontenera, Kontener nowyKontener)
        {
            Kontener kontenerDoZastapienia = null;
            foreach (Kontener kontener in kontenery)
            {
                if (kontener.numer_seryjny.Equals(numerKontenera))
                {
                    kontenerDoZastapienia = kontener;
                }
            }
            kontenery.Remove(kontenerDoZastapienia);
            ZaladujNaStatek(nowyKontener);
        }
    }
}