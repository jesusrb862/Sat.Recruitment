using Sat.Recruitment.Api.Data.Models;
using Sat.Recruitment.Api.Utils;
using System.Collections.Generic;
namespace Sat.Recruitment.Api.Data
{
    
    public class UserContext
    {
        public readonly List<User> Users = new List<User>();
        public UserContext()
        {
            if (Users.Count == 0)
            {
                SeedUsers();
            }            
        }
        private void SeedUsers()
        {
            var reader = FileUtil.ReadUsersFromFile();        

            while (reader.Peek() >= 0)
            {
                var line = reader.ReadLineAsync().Result;
                var user = new User
                {
                    Name = line.Split(',')[0].ToString(),
                    Email = line.Split(',')[1].ToString(),
                    Phone = line.Split(',')[2].ToString(),
                    Address = line.Split(',')[3].ToString(),
                    UserType = line.Split(',')[4].ToString(),
                    Money = decimal.Parse(line.Split(',')[5].ToString()),
                };
                Users.Add(user);
            }
            reader.Close();
        }
    }
}
