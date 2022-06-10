using System.Collections.Generic;

namespace Lab_2.DTO
{
    class ServiceDeskDTO
    {
        public long Id;
        public string DeskName;
        public List<OrderDTO> OrdersList;

        public ServiceDeskDTO() { }

        public ServiceDeskDTO(long id, string deskName, List<OrderDTO> ordersList)
        {
            Id = id;
            DeskName = deskName;
            OrdersList = ordersList;
        }
    }
}
