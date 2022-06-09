using Lab_2.dto;
using LibraryFor2ndLab;

namespace Lab_2.Converters
{
    class UserConverter
    {
        public static User ConvertToModel(UserDTO userDTO)
        {
            return new(userDTO.Id,
                userDTO.Username,
                userDTO.Email,
                userDTO.Phone,
                userDTO.Password,
                userDTO.Role);
        }

        public static UserDTO ConvertToDTO(User user)
        {
            return new(user.Id,
                user.Username,
                user.Email,
                user.Phone,
                user.Password,
                user.Role);
        }
    }
}
