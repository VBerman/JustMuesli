namespace JustMuesli.Models
{
    using JustMuesli.Helpers;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order")]
    public partial class Order : ObservableObject
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            OrderMuesli = new HashSet<OrderMuesli>();
        }

        public int Id { get; set; }

        public DateTime Time { get; set; }
        private decimal price;
        [Column(TypeName = "money")]
        public decimal Price
        {
            get
            {
                return price;
            }
            set
            {
                price = value;
                OnPropertyChanged();
            }
        }

        private decimal shipping;

        [Column(TypeName = "money")]
        public decimal Shipping
        {
            get
            {
                return shipping;
            }
            set
            {
                shipping = value;
                OnPropertyChanged();
            }
        }
        private decimal taxes;
        [Column(TypeName = "money")]
        public decimal Taxes
        {
            get
            {
                return taxes;
            }
            set
            {
                taxes = value;
                OnPropertyChanged();
            }
        }


        private ICollection<OrderMuesli> orderMuesli;
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderMuesli> OrderMuesli
        {
            get => orderMuesli;
            set
            {

                orderMuesli = value;
                OnPropertyChanged();
            }
        }
    }
}
