using Sat.Recruitment.Api.Dto;
using System.Threading.Tasks;

namespace Sat.Recruitment.Api.BusinessLogic
{
    public interface IBLUser
    {
        Task<UserDTO> CreateUser(UserDTO userDTO);
    }
}
