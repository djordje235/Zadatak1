using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadatak1
{
    internal class SaksijskaBiljka : Biljka
    {
        private double kolicinadjubriva; // u kg
        private double cenapokg;   // djubriva

        public SaksijskaBiljka() : base() { }
        
        public SaksijskaBiljka(string naziv,bool jednogodisnja, double kolicinavode, double kolicinadjubriva, double cenapokg) : base(naziv, jednogodisnja, kolicinavode)
        {
            this.kolicinadjubriva = kolicinadjubriva;
            this.cenapokg = cenapokg;
        }

        public override double cenaOdrzavanja()
        {
            double vcena;
            vcena = kolicinavode * 10 + kolicinadjubriva + cenapokg;
            if (jednogodisnja)
            {
                return vcena * 1.1;
            }
            else
            {
                return vcena;
            }
        }

        public override void UpisiUBinarni(BinaryWriter bw)
        {
            bw.Write("P"); // pot-saksija
            base.UpisiUBinarni(bw);
            bw.Write(kolicinadjubriva);
            bw.Write(cenapokg);

        }

        public override void CitajIzBinarni(BinaryReader br)
        {
            base.CitajIzBinarni(br);
            kolicinadjubriva = br.ReadDouble();
            cenapokg = br.ReadDouble();

        }

    }
}
