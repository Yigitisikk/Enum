using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enum
{
    internal class Bolme : Islem , DoubleInterface
    {
        public double DoubleIslemYap(int sayi1, int sayi2)
        {
            return (double)sayi1 / sayi2;
        }

        public int IslemYap(int sayi1, int sayi2)
        {
            return sayi1 / sayi2;
        }
    }
}
