using Sat.Recruitment.Api.Data;
using Sat.Recruitment.Api.Data.Models;
using Sat.Recruitment.Api.Dto;
using System.Threading.Tasks;
using System.Linq;
using Sat.Recruitment.Api.Extensions;
namespace Sat.Recruitment.Api.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext _userContext;
        public UserRepository(UserContext context)
        {
            _userContext = context;
        }
        public async Task<UserDTO> Create(UserDTO userDTO)
        {

            var user = userDTO.MapToUser();
            _userContext.Users.Add(user);
            return await Task.FromResult(user.MapToUserDTO());
        }

        public async Task<bool> UserExist(UserDTO userDTO)
        {
            var userExist = _userContext.Users.Where(p => p.Name.ToUpper() == userDTO.Name.ToUpper()
             || p.Email.ToUpper() == userDTO.Email.ToUpper() ||
             p.Address.ToUpper() == userDTO.Address.ToUpper() ||
             p.Phone.ToUpper() == userDTO.Phone.ToUpper()).FirstOrDefault();

            return await Task.FromResult(userExist != null);
        }
    }
}
