using LibraryFor2ndLab.Models;

namespace Lab_2.DTO
{
    class CustomerDTO
    {
        public long Id;
        public Service Service;
        public string Adress;
        public UserDTO User;

        public CustomerDTO(long id, Service service, string adress, UserDTO user)
        {
            Id = id;
            Service = service;
            Adress = adress;
            User = user;
        }
    }
}
