using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
