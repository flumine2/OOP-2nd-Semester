using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2.dto
{
    class PerformerDTO
    {
        public string Name;
        public string Surname;
        public DateTime BirthDate;

        public PerformerDTO(string name, string surname, DateTime birthDate)
        {
            Name = name;
            Surname = surname;
            BirthDate = birthDate;
        }
    }
}
