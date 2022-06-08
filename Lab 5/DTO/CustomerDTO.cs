using LibraryFor2ndLab;
using LibraryFor2ndLab.Models;

namespace Lab_2.dto
{
    class CustomerDTO
    {
        public Service Service;
        public string Adress;

        public CustomerDTO(Service service, string adress)
        {
            Service = service;
            Adress = adress;
        }
    }
}
