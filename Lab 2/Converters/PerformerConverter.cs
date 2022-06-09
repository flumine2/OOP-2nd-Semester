using Lab_2.dto;
using LibraryFor2ndLab.DTO;

namespace Lab_2.Converters
{
    class PerformerConverter
    {
        public static Performer ConvertToModel(PerformerDTO performerDTO)
        {
            return new(performerDTO.Id,
                performerDTO.Name,
                performerDTO.Surname,
                performerDTO.BirthDate,
                UserConverter.ConvertToModel(performerDTO.User));
        }

        public static PerformerDTO ConvertToDTO(Performer performer)
        {
            return new(performer.Id,
                performer.Name,
                performer.Surname,
                performer.BirthDate,
                UserConverter.ConvertToDTO(performer.User));
        }
    }
}
