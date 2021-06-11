using JustMuesli.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace JustMuesli.Models
{
    public class User
    {

        [Required]
        [MinLength(5)]
        public string Name { get; set; }

      
        [Required]
        [MinLength(5)]
        public string Address { get; set; }

        [MinLength(4)]
        [Required]
        
        [RegularExpression(@"\d\d\d\d", ErrorMessage = "4 digits")]
        
        public string Zip { get; set; }

        [MinLength(5)]
        [Required]
        
        public string City { get; set; }

        //add country
        public int Country { get; set; }

        [MinLength(10)]
        [Phone]
        [Required]
        public string Phone { get; set; }

        [EmailAddress]
        [Required]
        [RegularExpression(@"^.+@..+\.[a-z][a-z][a-z]?$")]
        public string Email { get; set; }

        public static User Load()
        {
            if (File.Exists(Environment.CurrentDirectory + @"\User.json"))
            {
                var stringUser = File.ReadAllText(Environment.CurrentDirectory + @"\User.json");
                try
                {

                    return JsonConvert.DeserializeObject<User>(stringUser);
                }
                    catch (Exception ex)
                {
                    return new User();
                    
                }
            }
            return new User();

        }

        public string Save()
        {
            var result = ValidationHelper.Validate<User>(this);

            if (result == "")
            {
                var stringUser = JsonConvert.SerializeObject(this);
                File.WriteAllText(Environment.CurrentDirectory + @"\User.json", stringUser);
                
            }


            return result;
        }




    }
}
