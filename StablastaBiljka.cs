using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadatak1
{
    internal class StablastaBiljka : Biljka
    {
        private DateTime datum;

        public StablastaBiljka() : base() { }

        public StablastaBiljka(string naziv,  bool jednogodisnja, double kolicinavode, DateTime datum) : base(naziv, jednogodisnja, kolicinavode)
        {
            this.datum = datum;
        }

        public override double cenaOdrzavanja()
        {
            double vcena;
            vcena = kolicinavode * 100;
            if(datum == DateTime.Now)
            {
                return vcena + 2000;
            }
            else
            {
                return vcena;
            }
        }

        public override void UpisiUBinarni(BinaryWriter bw)
        {
            bw.Write("T"); //tree-stablo
            base.UpisiUBinarni(bw);
            bw.Write(datum.ToBinary());
        }

        public override void CitajIzBinarni(BinaryReader br)
        {
            base.CitajIzBinarni(br);
            datum = DateTime.FromBinary(br.ReadInt64());
        }

    }
}
