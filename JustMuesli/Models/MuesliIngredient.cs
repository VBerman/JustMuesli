namespace JustMuesli.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MuesliIngredient")]
    public partial class MuesliIngredient
    {
        public int Id { get; set; }

        public int IngredientId { get; set; }

        public int MuesliId { get; set; }

        public virtual Ingredient Ingredient { get; set; }

        public virtual Muesli Muesli { get; set; }
    }
}
