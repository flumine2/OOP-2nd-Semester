using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3_Part_1
{
    class Car
    {
        private string name;
        private bool washed;

        public Car(string name)
        {
            this.name = name;
        }

        public void Wash()
        {
            Console.WriteLine(name + " is washed.");
            washed = true;
        }
    }
}
