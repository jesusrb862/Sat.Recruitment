using System.ComponentModel.DataAnnotations;

namespace Sat.Recruitment.Api.Data.Models
{
    public class User
    {
     
        public string Name { get; set; }      
        public string Email { get; set; }       
        public string Address { get; set; }      
        public string Phone { get; set; }        
        public string UserType { get; set; }
        public decimal Money { get; set; }    
    }
}
