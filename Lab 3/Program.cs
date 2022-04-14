using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3_Part_1
{
    public delegate void DelegWash();

    //SharpWasher
    class Program
    {
        static void Main(string[] args)
        {
            Garage garage = new Garage();
            garage.Add("BMW");
            garage.Add("Volkswagen");
            garage.Add("Mercedes");
            garage.Add("Infinity");
            garage.Add("Kostya");

            foreach (Car car in garage)
            {
                DelegWash delegWash = car.Wash;
                Washer.Wash(delegWash);
            }
        }
    }
}
