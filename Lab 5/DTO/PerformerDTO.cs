using System;

namespace Lab_2.dto
{
    class PerformerDTO
    {
        public long Id;
        public string Name;
        public string Surname;
        public DateTime BirthDate;

        public PerformerDTO(long id, string name, string surname, DateTime birthDate)
        {
            Id = id;
            Name = name;
            Surname = surname;
            BirthDate = birthDate;
        }
    }
}
