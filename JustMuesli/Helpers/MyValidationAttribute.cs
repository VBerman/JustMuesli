using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustMuesli.Helpers
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class MyValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is string)
            {
                var a = value as string;
                var number = 0;
                if (int.TryParse(a, out number))
                { return true; }
                else
                {

                    
                    this.ErrorMessage = "need number";
                }

            }
            return false;
        }

    }
}
