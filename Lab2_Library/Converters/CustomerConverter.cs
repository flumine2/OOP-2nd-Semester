using LibraryFor2ndLab.DTO;
using LibraryFor2ndLab.Models.Person;

namespace LibraryFor2ndLab.Converters
{
    public class CustomerConverter
    {
        public static Customer ConvertToModel(CustomerDTO customerDTO)
        {
            return new Customer(customerDTO.Id,
                customerDTO.Service,
                customerDTO.Adress);
        }

        public static CustomerDTO ConvertToDTO(Customer customer)
        {
            return new CustomerDTO(customer.Id,
                customer.Service,
                customer.Adress);
        }
    }
}
