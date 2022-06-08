using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace LibraryFor2ndLab.DTO
{
    public class ServiceDesk : ICloneable, IComparable
    {
        [Required]
        private string deskName;

        [Required]
        private List<Order> ordersList;

        public string DeskName
        {
            get => deskName;
            private set
            {
                deskName = value;
            }
        }
        public List<Order> OrdersList
        {
            get => ordersList;
            private set { ordersList = value; }
        }

        public ServiceDesk(string deskName)
        {
            DeskName = deskName;
            OrdersList = new List<Order>();
        }

        public ServiceDesk(string deskName, List<Order> ordersList)
        {
            DeskName = deskName;
            this.OrdersList = ordersList;
        }

        public void AddNewOrder(Order order)
        {
            OrdersList.Add(order);
        }

        public object Clone() => new ServiceDesk(DeskName, OrdersList.Select(x => x.Clone() as Order).ToList());

        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            int hash = DeskName.GetHashCode();
            for (int i = 0; i < OrdersList.Count; i++)
            {
                hash += OrdersList[i].GetHashCode();
            }
            return hash;
        }

        public string ToShortString()
        {
            int totalPrice = 0;
            for (int i = 0; i < OrdersList.Count; i++)
            {
                totalPrice += OrdersList[i].Price;
            }
            return $"Service desk name: {DeskName}" + "\n" +
                $"Orders total price: {totalPrice}";
        }

        public override string ToString()
        {
            string str = $"Service desk name: {DeskName};" + "\n" + "Orders:" + "\n";
            for (int i = 0; i < OrdersList.Count; i++)
            {
                str += OrdersList[i].ToString();
            }
            return str;
        }
    }
}
