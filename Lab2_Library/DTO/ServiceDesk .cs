using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace LibraryFor2ndLab.DTO
{
    public class ServiceDesk : Entity, ICloneable, IComparable
    {
        [Required]
        private string _deskName;

        [Required]
        private List<Order> _ordersList;

        public string DeskName
        {
            get => _deskName;
            private set
            {
                _deskName = value;
            }
        }
        public List<Order> OrdersList
        {
            get => _ordersList;
            private set { _ordersList = value; }
        }

        public ServiceDesk(string deskName) : base()
        {
            DeskName = deskName;
            OrdersList = new List<Order>();
        }

        public ServiceDesk(long id, string deskName, List<Order> ordersList) : base(id)
        {
            DeskName = deskName;
            OrdersList = ordersList;
        }

        public void AddNewOrder(Order order)
        {
            OrdersList.Add(order);
        }

        public object Clone() => new ServiceDesk(Id ,DeskName, OrdersList.Select(x => x.Clone() as Order).ToList());

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
            string str = $"Id: {Id};" + "\n" + "Service desk name: {DeskName};" + "\n" + "Orders:" + "\n";
            for (int i = 0; i < OrdersList.Count; i++)
            {
                str += OrdersList[i].ToString();
                str += "\n\n";
            }
            return str;
        }
    }
}
