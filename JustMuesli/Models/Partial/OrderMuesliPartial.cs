using JustMuesli.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace JustMuesli.Models
{
    partial class OrderMuesli : ObservableObject
    {
        [NotMapped]
        private bool? size;
        [NotMapped]
        public bool? Size
        {
            get { return size ?? false; }
            set
            {
                size = value;
                OnPropertyChanged();
                ChangeData();
            }
        }   
        [NotMapped]
        private int quantity;
        [NotMapped]
        public int Quantity
        {
            get { return quantity; }
            set
            {
                quantity = value;
                OnPropertyChanged();
                ChangeData();
            }
        }

        public void ChangeData()
        {
            OnPropertyChanged("Total");
            Order.OnPropertyChanged("OnlyPrice");
            Order.CalculateAll();
        }
        [NotMapped]
        public string QuantityString
        {
            get { return Quantity.ToString(); }
            set
            {

                try
                {
                    Quantity = int.Parse(value);
                }
                catch (Exception)
                {

                }

                OnPropertyChanged();
            }
        }
        //5


        [NotMapped]
        public decimal Total
        {
            get
            {
                var startPrice = CreatedMuesli.Price;
                if (Size == true)
                {
                    startPrice *= 4;
                }
                startPrice *= Quantity;

                
                
                return startPrice;
            }

        }

        

    }
}
