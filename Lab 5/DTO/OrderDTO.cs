using System;

namespace Lab_2.dto
{
    class OrderDTO
    {
        public PerformerDTO Performer;
        public CustomerDTO Customer;
        public DateTime OrderCreationTime;
        public int Price;

        public OrderDTO(PerformerDTO performer, CustomerDTO customer, DateTime orderCreationTime, int price)
        {
            Performer = performer;
            Customer = customer;
            OrderCreationTime = orderCreationTime;
            Price = price;
        }
    }
}
