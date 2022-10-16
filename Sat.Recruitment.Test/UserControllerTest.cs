using System;
using System.Dynamic;
using Microsoft.AspNetCore.Mvc;
using Sat.Recruitment.Api.BusinessLogic;
using Sat.Recruitment.Api.Controllers;
using Sat.Recruitment.Api.Data;
using Sat.Recruitment.Api.Dto;
using Sat.Recruitment.Api.Repository;
using Xunit;
using Sat.Recruitment.Api.Constant;
namespace Sat.Recruitment.Test
{
    [CollectionDefinition("Tests", DisableParallelization = true)]
    public class UserControllerTest
    {
        UserContext _context;
        UserRepository _userRepository;
        BLUser _blUser;
        public UserControllerTest()
        {
            _context = new UserContext();
            _userRepository = new UserRepository(_context);
            _blUser = new BLUser(_userRepository);
        }
        [Fact]
        public void Should_CreateUser() { 
            
            var userController = new UsersController(_blUser);

            var user = new UserDTO { 
                 Name = "Mike",
                 Email = "mike@gmail.com",
                 Address = "Av. Juan G",
                 Phone= "+349 1122354215",
                 UserType = "Normal",
                 Money=124
            };

            var result = userController.CreateUser(user).Result;
            Assert.Equal(true, result.IsSuccess);
            Assert.Equal("User Created", result.Errors);
        }

        [Fact]
        public void Should_GetDuplicatedError()
        {
            
            var userController = new UsersController(_blUser);
            var user = new UserDTO
            {
                Name = "Agustina",
                Email = "Agustina@gmail.com",
                Address = "Av. Juan G",
                Phone = "+349 1122354215",
                UserType = "Normal",
                Money = 124
            };
            var result = userController.CreateUser(user).Result;

            Assert.Equal(false, result.IsSuccess);
            Assert.Equal(Constants.USER_DUPLICATED_MSG, result.Errors);
        }
    }
}
