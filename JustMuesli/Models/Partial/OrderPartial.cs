using JustMuesli.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustMuesli.Models
{
    partial class Order : ObservableObject
    {
        
        public decimal OnlyPrice
        {
            get
            {
                
                return OrderMuesli.ToList().Sum(om => om.Total);

            }
        }

        public void CalculateAll()
        {
            User = User.Load();
            

            if (User.Country == 216)
            {
                Shipping = 6;
                Taxes = OnlyPrice / 100 * (decimal)2.5;
            }
            else
            {
                Shipping = 8;
                Taxes = 0;
            }
            if (OnlyPrice > 50)
            {
                Shipping = 0;
            }
            Price = OnlyPrice + Taxes + Shipping;
        }

        [NotMapped]
        public User User { get; set; }

    }
}