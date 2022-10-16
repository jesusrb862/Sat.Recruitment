using Sat.Recruitment.Api.Dto;
using System.Threading.Tasks;

namespace Sat.Recruitment.Api.Repository
{
    public interface IUserRepository
    {
        Task<UserDTO> Create(UserDTO userDTO);
        Task<bool> UserExist(UserDTO userDTO);
    }
}
