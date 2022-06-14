using LibraryFor2ndLab.DTO;
using LibraryFor2ndLab.Models;
using System.Collections.ObjectModel;
using System.Linq;

namespace LibraryFor2ndLab.Converters
{
    public class ServiceDeskConverter
    {
        public static ServiceDesk ConvertToModel(ServiceDeskDTO serviceDeskDTO)
        {
            return new ServiceDesk(serviceDeskDTO.Id,
                serviceDeskDTO.DeskName,
                new ObservableCollection<Order>(serviceDeskDTO.OrdersList.Select(x => OrderConverter.ConvertToModel(x))));
        }

        public static ServiceDeskDTO ConvertToDTO(ServiceDesk serviceDesk)
        {
            return new ServiceDeskDTO(serviceDesk.Id,
                serviceDesk.DeskName,
                new ObservableCollection<OrderDTO>(serviceDesk.OrdersList.Select(x => OrderConverter.ConvertToDTO(x))));
        }
    }
}
