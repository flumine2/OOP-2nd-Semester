using LibraryFor2ndLab.Models.Person;
using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryFor2ndLab.Models
{
    public class Order : Entity, ICloneable, IComparable<Order>
    {
        public Order(Performer performer, Customer customer, DateTime orderCreationTime, int price) : base()
        {
            Performer = performer;
            Customer = customer;
            OrderCreationTime = orderCreationTime;
            Price = price;
        }

        public Order(long id, Performer performer, Customer customer, DateTime orderCreationTime, int price) : base(id)
        {
            Performer = performer;
            Customer = customer;
            OrderCreationTime = orderCreationTime;
            Price = price;
        }

        [Required]
        public Performer Performer { get; private set; }

        [Required]
        public Customer Customer { get; private set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime OrderCreationTime { get; set; }

        [Required]
        [Range(1, 100000)]
        public int Price { get; set; }

        public object Clone() => new Order(
            Id, 
            Performer.Clone() as Performer,
            Customer.Clone() as Customer,
            OrderCreationTime,
            Price);

        public int CompareTo(Order other)
        {
            if (other is null)
                throw new ArgumentException("Invalid parameter value");

            if (Performer.CompareTo(other.Performer) == 0)
            {
                if (Customer.CompareTo(other.Customer) == 0)
                {
                    if (OrderCreationTime.CompareTo(other.OrderCreationTime) == 0)
                        return Price.CompareTo(other.Price);
                    else
                        return OrderCreationTime.CompareTo(other.OrderCreationTime);
                }
                else
                    return Customer.CompareTo(other.Customer);
            }
            else
                return Performer.CompareTo(other.Performer);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (!(obj is Order order))
            {
                return false;
            }
            return Performer.Equals(order.Performer) &&
                Customer.Equals(order.Customer) &&
                OrderCreationTime == order.OrderCreationTime &&
                Price == order.Price;
        }

        public override int GetHashCode()
        {
            return Performer.GetHashCode() + Customer.GetHashCode() + OrderCreationTime.GetHashCode() + Price.GetHashCode();
        }

        public override string ToString()
        {
            return $"Id: {Id};" + "\n" +
                $"Performer: {Performer}" + "\n" +
                $"Customer: {Customer}" + "\n" +
                $"Creation time: {OrderCreationTime};" + "\n" +
                $"Price: {Price};";
        }
    }
}
