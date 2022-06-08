using Lab_2.dto;
using LibraryFor2ndLab;
using LibraryFor2ndLab.DTO;

namespace Lab_2.Converters
{
    class PerformerConverter
    {
        public static Performer ConvertToModel(PerformerDTO performerDTO)
        {
            return new(performerDTO.Name, performerDTO.Surname, performerDTO.BirthDate);
        }

        public static PerformerDTO ConvertToDTO(Performer performer)
        {
            return new(performer.Name, performer.Surname, performer.BirthDate);
        }

    }
}
