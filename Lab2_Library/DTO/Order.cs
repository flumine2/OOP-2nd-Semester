using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryFor2ndLab.DTO
{
    public class Order : Entity, ICloneable, IComparable<Order>
    {
        [Required]
        private Performer _performer;

        [Required]
        private Customer _customer;

        [Required]
        [DataType(DataType.Date)]
        private DateTime _orderCreationTime;

        [Required]
        [Range(1, 100000)]
        private int _price;

        public Performer Performer
        {
            get => _performer;
            private set
            {
                _performer = value;
            }
        }
        public Customer Customer
        {
            get => _customer;
            private set
            {
                _customer = value;
            }
        }
        public DateTime OrderCreationTime
        {
            get => _orderCreationTime;
            private set
            {
                _orderCreationTime = value;
            }

        }
        public int Price
        {
            get => _price;
            private set
            {
                _price = value;
            }
        }

        public Order(Performer performer, Customer customer, DateTime orderCreationTime, int price) : base()
        {
            _performer = performer;
            _customer = customer;
            _orderCreationTime = orderCreationTime;
            _price = price;
        }

        public Order(long id, Performer performer, Customer customer, DateTime orderCreationTime, int price) : base(id)
        {
            _performer = performer;
            _customer = customer;
            _orderCreationTime = orderCreationTime;
            _price = price;
        }

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
