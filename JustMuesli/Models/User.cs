using JustMuesli.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustMuesli.Models
{
    public class User
    {
        [DataType(DataType.Text)]
        [Required]
        [MinLength(5)]
        public string Name { get; set; }

        [DataType(DataType.Text)]
        [Required]
        [MinLength(5)]
        public string Address { get; set; }

        [MinLength(4)]
        [Required]
        public string Zip { get; set; }

        [MinLength(5)]
        [Required]
        [DataType(DataType.Text)]
        public string City { get; set; }

        //add country
        public int Country { get; set; }

        [MinLength(10)]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [EmailAddress(ErrorMessage = "validate email address")]
        [Required]
        public string Email { get; set; }

        public static User Load()
        {
            return new User();
            
        }

        public string Save()
        {
            var result = ValidationHelper.Validate<User>(this);
            return result;
        }



        
    }
}
