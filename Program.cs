using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadatak1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BotanickaBasta basta = new BotanickaBasta("Botanicka bas", 100, 10);

            // Dodavanje biljaka
            basta.dodajbiljku(new SaksijskaBiljka("Ruza", true, 2, 1, 5));
            basta.dodajbiljku(new SaksijskaBiljka("Ljiljan", false, 3, 2, 8));
            basta.dodajbiljku(new SaksijskaBiljka("Orhideja", true, 1, 0.5, 12));
            basta.dodajbiljku(new StablastaBiljka("Jelka", true, 5, DateTime.Today));
            basta.dodajbiljku(new StablastaBiljka("Bor", true, 6, DateTime.Today.AddDays(10)));
            basta.dodajbiljku(new StablastaBiljka("Javor", true, 4, DateTime.Today.AddDays(20)));


            basta.BinarniUpis("basta.bin");


            BotanickaBasta novabasta = new BotanickaBasta("", 0, 0);
            novabasta.BinarnoCitanje("basta.bin");

            novabasta.print();
            Console.WriteLine(" ");

            novabasta.IzbaciVisak();
            novabasta.print(); 
            Console.WriteLine(" ");

            novabasta.sortirajpovodi();
            novabasta.print();

            try
            {
                novabasta.proveriRaznovrsnost();
                Console.WriteLine("Raznovrsnost biljaka je u redu.");
            }
            catch (NedovoljnaRaznovrsost ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
