using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2.dto
{
    class ServiceDeskDTO
    {
        public string DeskName;
        public List<OrderDTO> ordersList;

        public ServiceDeskDTO() { }

        public ServiceDeskDTO(string deskName)
        {
            DeskName = deskName;
            ordersList = new List<OrderDTO>();
        }

        public ServiceDeskDTO(string deskName, List<OrderDTO> ordersList)
        {
            DeskName = deskName;
            this.ordersList = ordersList;
        }
    }
}
