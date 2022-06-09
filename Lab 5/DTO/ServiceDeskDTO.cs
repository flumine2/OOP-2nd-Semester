using System.Collections.Generic;

namespace Lab_2.dto
{
    class ServiceDeskDTO
    {
        public long Id;
        public string DeskName;
        public List<OrderDTO> ordersList;

        public ServiceDeskDTO() { }

        public ServiceDeskDTO(string deskName)
        {
            DeskName = deskName;
            ordersList = new List<OrderDTO>();
        }

        public ServiceDeskDTO(long id, string deskName, List<OrderDTO> ordersList)
        {
            Id = id;
            DeskName = deskName;
            this.ordersList = ordersList;
        }
    }
}
