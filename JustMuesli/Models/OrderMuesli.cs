namespace JustMuesli.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrderMuesli")]
    public partial class OrderMuesli
    {
        public int Id { get; set; }

        public int CreatedMuesliId { get; set; }

        public int OrderId { get; set; }

        public virtual CreatedMuesli CreatedMuesli { get; set; }

        public virtual Order Order { get; set; }
    }
}
