using LibraryFor2ndLab.DTO;
using LibraryFor2ndLab.Models.Person;

namespace LibraryFor2ndLab.Converters
{
    public class PerformerConverter
    {
        public static Performer ConvertToModel(PerformerDTO performerDTO)
        {
            return new Performer(performerDTO.Id,
                performerDTO.Name,
                performerDTO.Surname,
                performerDTO.BirthDate);
        }

        public static PerformerDTO ConvertToDTO(Performer performer)
        {
            return new PerformerDTO(performer.Id,
                performer.Name,
                performer.Surname,
                performer.BirthDate);
        }
    }
}
