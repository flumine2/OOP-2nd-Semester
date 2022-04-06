using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab_2.dto;
using LibraryFor2ndLab;

namespace Lab_2.Converters
{
    class CustomerConverter
    {
        public static Customer ConvertToModel(CustomerDTO customerDTO) => new(customerDTO.Service, customerDTO.Adress);

        public static CustomerDTO ConvertToDTO(Customer customer) => new(customer.Service, customer.Adress);
    }
}
