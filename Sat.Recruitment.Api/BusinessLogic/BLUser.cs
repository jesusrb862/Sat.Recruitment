using Sat.Recruitment.Api.Dto;
using System.Threading.Tasks;
using System;
using Sat.Recruitment.Api.Repository;
using Sat.Recruitment.Api.Constant;
namespace Sat.Recruitment.Api.BusinessLogic
{
    public class BLUser:IBLUser
    {
        readonly IUserRepository _userRepository;
        public BLUser(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<UserDTO> CreateUser(UserDTO userDTO)
        {
            if (userDTO.UserType.ToUpper() == Constants.USER_TYPE_NORMAL.ToUpper())
            {
                if (userDTO.Money > 100)
                {
                    var percentage = Convert.ToDecimal(0.12);
                    //If new user is normal and has more than USD100
                    var gif = userDTO.Money * percentage;
                    userDTO.Money = userDTO.Money + gif;
                }
                if (userDTO.Money > 10 && userDTO.Money < 100)  
                {                    
                        var percentage = Convert.ToDecimal(0.8);
                        var gif = userDTO.Money * percentage;
                        userDTO.Money = userDTO.Money + gif;                    
                }
            }
            if (userDTO.UserType.ToUpper() == Constants.USER_TYPE_SUPER_USER.ToUpper())
            {
                if (userDTO.Money > 100)
                {
                    var percentage = Convert.ToDecimal(0.20);
                    var gif = userDTO.Money * percentage;
                    userDTO.Money = userDTO.Money + gif;
                }
            }
            if (userDTO.UserType.ToUpper() == Constants.USER_TYPE_PREMIUM.ToUpper())
            {
                if (userDTO.Money > 100)
                {
                    var gif = userDTO.Money * 2;
                    userDTO.Money = userDTO.Money + gif;
                }
            }
            ////Normalize email
            if (userDTO.Email.IndexOf('@') >= 0)
            {
                var aux = userDTO.Email.Split(new char[] { '@' }, StringSplitOptions.RemoveEmptyEntries);
                var atIndex = aux[0].IndexOf("+", StringComparison.Ordinal);
                aux[0] = atIndex < 0 ? aux[0].Replace(".", "") : aux[0].Replace(".", "").Remove(atIndex);
                userDTO.Email = string.Join("@", new string[] { aux[0], aux[1] });
            }

            if (await _userRepository.UserExist(userDTO))
            {
                throw new Exception(Constants.USER_DUPLICATED_MSG);
            }
            return await _userRepository.Create(userDTO);
        }
    }
}
