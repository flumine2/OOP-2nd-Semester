﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryFor2ndLab;

namespace Lab_2.Utilities
{
    class CustomerUtility
    {
        public static Customer GetRandomCustomerModel(Random random)
        {
            string[] adress = new string[] {"692 NW 22nd Ln Okeechobee, Florida(FL)",
            "3961 Laurel Run Columbia, Pennsylvania(PA)",
            "1108 Park Ave #1R Hoboken, New Jersey(NJ)",
            "6 Sauls Ct Okatie, South Carolina(SC)",
            "932 Lincoln St Portsmouth, Virginia(VA)",
            "1306 SW 5th Ave Battle Ground, Washington(WA)",
            "379 Colonial Ave Marco Island, Florida(FL)",
            "1100 12th St Mc Kees Rocks, Pennsylvania(PA)",
            "34555 W 85th Ter De Soto, Kansas(KS)"};

            return new((Service) random.Next(0,5), adress[random.Next(0, adress.Length)]);
        }
    }
}