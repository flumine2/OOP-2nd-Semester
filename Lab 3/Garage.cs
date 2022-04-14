using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3_Part_1
{
    class Garage
    {
        private List<Car> cars;

        public Garage()
        {
            cars = new List<Car>();
        }

        public void Add(string name)
        {
            cars.Add(new Car(name));
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < cars.Count; i++)
            {
                yield return cars[i];
            }
        }
    }
}
