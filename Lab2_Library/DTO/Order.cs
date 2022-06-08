using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryFor2ndLab.DTO
{
    public class Order : ICloneable, IComparable<Order>
    {
        [Required]
        private Performer performer;

        [Required]
        private Customer customer;

        [Required]
        [DataType(DataType.Date)]
        private DateTime orderCreationTime;

        [Required]
        [Range(1, 100000)]
        private int price;

        public Performer Performer
        {
            get => performer;
            private set
            {
                performer = value;
            }
        }
        public Customer Customer
        {
            get => customer;
            private set
            {
                customer = value;
            }
        }
        public DateTime OrderCreationTime
        {
            get => orderCreationTime;
            private set
            {
                orderCreationTime = value;
            }

        }
        public int Price
        {
            get => price;
            private set
            {
                price = value;
            }
        }

        public Order(Performer performer, Customer customer, DateTime orderCreationTime, int price)
        {
            this.performer = performer;
            this.customer = customer;
            this.orderCreationTime = orderCreationTime;
            this.price = price;
        }

        public object Clone() => new Order(Performer.Clone() as Performer,
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
            return $"Performer: {Performer}" + "\n" +
                $"Customer: {Customer}" + "\n" +
                $"Creation time: {OrderCreationTime};" + "\n" +
                $"Price: {Price};";
        }
    }
}
