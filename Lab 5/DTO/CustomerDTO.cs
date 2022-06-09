using LibraryFor2ndLab;
using LibraryFor2ndLab.Models;

namespace Lab_2.dto
{
    class CustomerDTO
    {
        public long Id;
        public Service Service;
        public string Adress;
        public User User;

        public CustomerDTO(long id, Service service, string adress, User user)
        {
            Id = id;
            Service = service;
            Adress = adress;
            User = user;
        }
    }
}
