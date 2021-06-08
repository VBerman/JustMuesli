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
    partial class Muesli : INotifyPropertyChanged
    {
        [NotMapped]
        private int actualSize;
        [NotMapped]
        public int ActualSize
        {
            get { return PortionSize == 600 ? actualSize : PortionSize; }
            set
            {
                actualSize = value;
                NotifyPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public decimal ProteinCalculate { get => (decimal)((double)ActualSize / 100 * Protein * 4.1); }

        public decimal CarbohydrateCalculate { get => (decimal)((double)ActualSize / 100 * Carbohydrates * 4.1); }
        public decimal FatCalculate { get => (decimal)((double)ActualSize / 100 * Fat * 9.3); }
    }
}
