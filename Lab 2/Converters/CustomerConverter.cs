using Lab_2.dto;
using LibraryFor2ndLab;
using LibraryFor2ndLab.DTO;

namespace Lab_2.Converters
{
    class CustomerConverter
    {
        public static Customer ConvertToModel(CustomerDTO customerDTO) => new(customerDTO.Service, customerDTO.Adress);

        public static CustomerDTO ConvertToDTO(Customer customer) => new(customer.Service, customer.Adress);
    }
}
