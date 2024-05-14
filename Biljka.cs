using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace zadatak1
{
  
    internal abstract class Biljka : IComparable<Biljka>
    {
        protected string naziv;
        protected bool jednogodisnja;
        protected double kolicinavode;

        public Biljka() { }

        public Biljka(string naziv, bool jednogodisnja, double kolicinavode)
        {
            this.naziv = naziv;
            this.jednogodisnja = jednogodisnja;
            this.kolicinavode = kolicinavode;
        }

        public abstract double cenaOdrzavanja();

        public virtual void UpisiUBinarni(BinaryWriter bw)
        {
            bw.Write(naziv);
            bw.Write(kolicinavode);
            bw.Write(jednogodisnja);
        }

        public virtual void CitajIzBinarni(BinaryReader br)
        {
            naziv = br.ReadString();
            kolicinavode = br.ReadDouble();
            jednogodisnja = br.ReadBoolean();
        }

        public int CompareTo(Biljka other)
        {
            if (this.kolicinavode< other.kolicinavode) return -1;
            if (this.kolicinavode > other.kolicinavode) { return 1; }
            return 0;
        }

        public double Kolicnavode
        {
            get { return Kolicnavode; }
        }
       

        public void prikaz()
        {
            Console.WriteLine("Naziv: " + naziv);
            Console.WriteLine("Tip: " + jednogodisnja);
            Console.WriteLine("kolicinavode: " + kolicinavode);
        }

    }
}
