using LibraryFor2ndLab;
using LibraryFor2ndLab.DTO;
using LibraryFor2ndLab.Models;
using System;

namespace Lab_2.Utilities
{
    class CustomerUtility
    {
        private static readonly string[] adress = new string[] {"692 NW 22nd Ln Okeechobee, Florida(FL)",
            "3961 Laurel Run Columbia, Pennsylvania(PA)",
            "1108 Park Ave #1R Hoboken, New Jersey(NJ)",
            "6 Sauls Ct Okatie, South Carolina(SC)",
            "932 Lincoln St Portsmouth, Virginia(VA)",
            "1306 SW 5th Ave Battle Ground, Washington(WA)",
            "379 Colonial Ave Marco Island, Florida(FL)",
            "1100 12th St Mc Kees Rocks, Pennsylvania(PA)",
            "34555 W 85th Ter De Soto, Kansas(KS)"};

        public static Customer GetRandomCustomerModel(Random random)
        {
            User user = UserUtility.GetRandomUserModel(random);

            return new((Service)random.Next(0, 5), adress[random.Next(0, adress.Length)], user);
        }

        public static Customer GetRandomCustomerModel(Random random, User user, Service service)
        {
            return new(service, adress[random.Next(0, adress.Length)], user);
        }
    }
}
