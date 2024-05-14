using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadatak1
{
    internal class BotanickaBasta
    {
        private string naziv;
        private int brposetilaca;
        private double ulcena; // cena ulaznice
        private List<Biljka> basta;

        public BotanickaBasta(string naziv, int brposetilaca, double ulcena)
        {
            this.naziv = naziv;
            this.brposetilaca = brposetilaca;
            this.ulcena = ulcena;
            this.basta = new List<Biljka>();
        }

        public void dodajbiljku(Biljka biljka)
        {
            basta.Add(biljka);
        }

        public void sortirajpovodi()
        {
            basta.Sort();
        }

        public void proveriRaznovrsnost()
        {
            bool saksijske = false;
            bool stablaste = false;
            foreach (var biljka in basta)
            {
                if (biljka is SaksijskaBiljka)
                    saksijske = true;
                else if (biljka is StablastaBiljka)
                    stablaste = true;
            }
            if (!saksijske || !stablaste)
            {
                throw new NedovoljnaRaznovrsost("U basti manjka raznovrsnosti!");
            }
                
        }

        public void BinarniUpis(string fajl)
        {
            try
            {
                using (BinaryWriter upisi = new BinaryWriter(new FileStream(fajl, FileMode.Create))) 
                {
                    upisi.Write(basta.Count);
                    upisi.Write(naziv);
                    upisi.Write(brposetilaca);
                    upisi.Write(ulcena);
                    foreach(Biljka biljka in basta)
                    {
                        biljka.UpisiUBinarni(upisi);
                    }
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void BinarnoCitanje(string fajl)
        {
            try
            {
                using (BinaryReader citaj = new BinaryReader(new FileStream(fajl, FileMode.Open)))
                {
                    int duz = citaj.ReadInt32();
                    naziv = citaj.ReadString();
                    brposetilaca = citaj.ReadInt32();
                    ulcena = citaj.ReadDouble();
                    basta.Clear();

                    for (int i = 0; i < duz; i++)
                    {
                        char vrsta = citaj.ReadChar();
                        Biljka biljka;
                        if (vrsta == 'P')
                        {
                            biljka = new SaksijskaBiljka();
                        }
                        else
                        {
                            biljka = new StablastaBiljka();
                        }
                        biljka.CitajIzBinarni(citaj);
                        basta.Add(biljka);
                    }

                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void IzbaciVisak()
        {
            double ukupnitrosak = 0;
            foreach(Biljka biljka in basta)
            {
                ukupnitrosak += biljka.cenaOdrzavanja();
            }

            while (ukupnitrosak > brposetilaca * ulcena)
            {
                Biljka najskupljaBiljka = null;
                foreach (var biljka in basta)
                {
                    if (najskupljaBiljka == null || biljka.cenaOdrzavanja() > najskupljaBiljka.cenaOdrzavanja())
                    {
                        najskupljaBiljka = biljka;
                    }
                }
                basta.Remove(najskupljaBiljka);
                ukupnitrosak -= najskupljaBiljka.cenaOdrzavanja();
            }
        }

        public void print()
        {
            foreach (var stavka in basta)
            {
                stavka.prikaz();
            }
        }






    }
}
