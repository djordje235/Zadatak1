using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadatak1
{
    internal class NedovoljnaRaznovrsost : Exception
    {
        public NedovoljnaRaznovrsost(string poruka) : base(poruka) { }
    }
}
