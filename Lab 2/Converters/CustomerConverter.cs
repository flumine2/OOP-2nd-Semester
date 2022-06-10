using Lab_2.DTO;
using LibraryFor2ndLab.DTO;

namespace Lab_2.Converters
{
    class CustomerConverter
    {
        public static Customer ConvertToModel(CustomerDTO customerDTO)
        {
            return new(customerDTO.Id,
                customerDTO.Service,
                customerDTO.Adress,
                UserConverter.ConvertToModel(customerDTO.User));
        }

        public static CustomerDTO ConvertToDTO(Customer customer)
        {
            return new(customer.Id,
                customer.Service,
                customer.Adress,
                UserConverter.ConvertToDTO(customer.User));
        }
    }
}
