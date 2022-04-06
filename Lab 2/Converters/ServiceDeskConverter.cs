using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab_2.dto;
using LibraryFor2ndLab;

namespace Lab_2.Converters
{
    class ServiceDeskConverter
    {
        public static ServiceDesk ConvertToModel(ServiceDeskDTO serviceDeskDTO)
        {
            return new(serviceDeskDTO.DeskName, 
                serviceDeskDTO.ordersList.Select(x => OrderConverter.ConvertToModel(x)).ToList());
        }

        public static ServiceDeskDTO ConvertToDTO(ServiceDesk serviceDesk)
        {
            return new(serviceDesk.DeskName,
                serviceDesk.OrdersList.Select(x => OrderConverter.ConvertToDTO(x)).ToList());
        }
    }
}
