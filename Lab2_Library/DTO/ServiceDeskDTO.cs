using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace LibraryFor2ndLab.DTO
{
    public class ServiceDeskDTO
    {
        public long Id;
        public string DeskName;
        public ObservableCollection<OrderDTO> OrdersList;

        public ServiceDeskDTO() { }

        public ServiceDeskDTO(long id, string deskName, ObservableCollection<OrderDTO> ordersList)
        {
            Id = id;
            DeskName = deskName;
            OrdersList = ordersList;
        }
    }
}
