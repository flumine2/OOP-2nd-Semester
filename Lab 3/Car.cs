using System;

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

        public Car(string name, bool washed)
        {
            this.name = name;
            this.washed = washed;
        }

        public void Wash()
        {
            Console.WriteLine(name + " is washed.");
            washed = true;
        }

        public override string ToString()
        {
            return "Name: " + name + ",\n" + "Is washed: " + washed.ToString();
        }
    }
}
