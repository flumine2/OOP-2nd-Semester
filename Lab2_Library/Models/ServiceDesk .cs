using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace LibraryFor2ndLab.Models
{
    public class ServiceDesk : Entity, ICloneable, IComparable
    {
        public ServiceDesk(string deskName) : base()
        {
            DeskName = deskName;
            OrdersList = new ObservableCollection<Order>();
        }

        public ServiceDesk(long id, string deskName, ObservableCollection<Order> ordersList) : base(id)
        {
            DeskName = deskName;
            OrdersList = ordersList;
        }

        [Required]
        public string DeskName { get; set; }

        [Required]
        public ObservableCollection<Order> OrdersList { get; private set; }

        public void AddNewOrder(Order order)
        {
            OrdersList.Add(order);
        }

        public object Clone() => new ServiceDesk(Id ,DeskName, new ObservableCollection<Order>(OrdersList.Select(x => x.Clone() as Order)));

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
            string str = $"Id: {Id};" + "\n" + $"Service desk name: {DeskName};" + "\n" + "Orders:" + "\n";
            for (int i = 0; i < OrdersList.Count; i++)
            {
                str += OrdersList[i].ToString();
                str += "\n\n";
            }
            return str;
        }
    }
}
