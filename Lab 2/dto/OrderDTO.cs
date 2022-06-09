using System;

namespace Lab_2.dto
{
    class OrderDTO
    {
        public long Id;
        public PerformerDTO Performer;
        public CustomerDTO Customer;
        public DateTime OrderCreationTime;
        public int Price;

        public OrderDTO(long id, PerformerDTO performer, CustomerDTO customer, DateTime orderCreationTime, int price)
        {
            Id = id;
            Performer = performer;
            Customer = customer;
            OrderCreationTime = orderCreationTime;
            Price = price;
        }
    }
}
