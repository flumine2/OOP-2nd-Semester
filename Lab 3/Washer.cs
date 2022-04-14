using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3_Part_1
{
    class Washer
    {
        public static void Wash(DelegWash delegWash)
        {
            delegWash();
        }
    }
}
