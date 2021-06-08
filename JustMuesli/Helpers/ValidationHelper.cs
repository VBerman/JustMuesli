using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustMuesli.Helpers
{
    public class ValidationHelper
    {

        class MyClass
        {
        }
        public static string Validate<T>(T instance)
        {

            var resultList = new List<ValidationResult>();

            Validator.TryValidateObject(instance, new ValidationContext(instance), resultList, true);
            return string.Join("\n", resultList); 

        }
    }

    
}
