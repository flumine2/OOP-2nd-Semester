using System;

namespace Lab_2.DTO
{
    class PerformerDTO
    {
        public long Id;
        public string Name;
        public string Surname;
        public DateTime BirthDate;
        public UserDTO User;

        public PerformerDTO(long id, string name, string surname, DateTime birthDate, UserDTO user)
        {
            Id = id;
            Name = name;
            Surname = surname;
            BirthDate = birthDate;
            User = user;
        }
    }
}
