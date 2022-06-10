using LibraryFor2ndLab.Models;

namespace LibraryFor2ndLab.DTO
{
    public class CustomerDTO
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
