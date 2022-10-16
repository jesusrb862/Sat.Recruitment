using Sat.Recruitment.Api.Data.Models;
using Sat.Recruitment.Api.Dto;

namespace Sat.Recruitment.Api.Extensions
{
    public static class UserExtensions
    {
        public static User MapToUser(this UserDTO userDTO)
        {
            return new User
            {
                Address = userDTO.Address,
                Email = userDTO.Email,
                Money = userDTO.Money,
                Name = userDTO.Name,
                Phone = userDTO.Phone,
                UserType = userDTO.UserType,
            };
        }
        public static UserDTO MapToUserDTO(this User user)
        {
            return new UserDTO
            {
                Address = user.Address,
                Email = user.Email,
                Money = user.Money,
                Name = user.Name,
                Phone = user.Phone,
                UserType = user.UserType,
            };
        }
    }
}
