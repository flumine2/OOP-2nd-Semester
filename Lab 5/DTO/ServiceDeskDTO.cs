using System.Collections.Generic;

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
