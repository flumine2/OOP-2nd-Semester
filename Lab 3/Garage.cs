using System.Collections;
using System.Collections.Generic;

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

        public void Add(string name, bool washed)
        {
            cars.Add(new Car(name, washed));
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
