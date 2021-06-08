namespace JustMuesli.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UsedMuesli")]
    public partial class UsedMuesli
    {
        public int Id { get; set; }

        public int CreatedMuesliId { get; set; }

        public int MuesliId { get; set; }

        public virtual CreatedMuesli CreatedMuesli { get; set; }

        public virtual Muesli Muesli { get; set; }
    }
}
