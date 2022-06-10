using LibraryFor2ndLab.DTO;
using LibraryFor2ndLab.Models.Person;

namespace LibraryFor2ndLab.Converters
{
    public class UserConverter
    {
        public static User ConvertToModel(UserDTO userDTO)
        {
            return new User(userDTO.Id,
                userDTO.Username,
                userDTO.Email,
                userDTO.Phone,
                userDTO.Password,
                userDTO.Role);
        }

        public static UserDTO ConvertToDTO(User user)
        {
            return new UserDTO(user.Id,
                user.Username,
                user.Email,
                user.Phone,
                user.Password,
                user.Role);
        }
    }
}
