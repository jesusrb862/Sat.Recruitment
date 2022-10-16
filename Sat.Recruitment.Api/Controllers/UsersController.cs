using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sat.Recruitment.Api.BusinessLogic;
using Sat.Recruitment.Api.Constant;
using Sat.Recruitment.Api.Dto;
using Sat.Recruitment.Api.Responses;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Sat.Recruitment.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public partial class UsersController : ControllerBase
    {
        private readonly IBLUser _blUsers;
        public UsersController(IBLUser blUsers)
        {
            _blUsers = blUsers;
        }

        [HttpPost]
        [Route("/create-user")]
        public async Task<Result> CreateUser(UserDTO userDTO)
        {            
            try
            {                                 
                await _blUsers.CreateUser(userDTO);
                Debug.WriteLine(Constants.USER_CREATED_MSG);
            }
            catch (Exception ex)
            {              
               return new Result()
               {
                    IsSuccess = false,
                    Errors = ex.Message
               };
            }
            return new Result()
            {
                IsSuccess = true,
                Errors = Constants.USER_CREATED_MSG
            };         
        }        
    }    
}
