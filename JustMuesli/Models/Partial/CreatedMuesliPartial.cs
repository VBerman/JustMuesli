using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace JustMuesli.Models
{
    partial class CreatedMuesli 
    {

        public decimal CalculatePrice
        {
            get
            {
                decimal price = 0;
                var weightPortion = 0;
                Muesli baseItem = null;
                foreach (var item in UsedMuesli)
                {
                    if (item.Muesli?.PortionSize == 600)
                    {
                        baseItem = item.Muesli;
                    }
                    else
                    {
                        weightPortion += item.Muesli?.PortionSize ?? 0;

                        price += item.Muesli?.Price ?? 0;

                    }
                }
                if (baseItem != null)
                {
                    price += (baseItem.PortionSize - weightPortion) * 100 / baseItem.PortionSize * baseItem.Price / 100;

                }

                return price;
            }
        }

    }
}
