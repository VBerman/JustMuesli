namespace JustMuesli.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Muesli")]
    public partial class Muesli
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Muesli()
        {
            MuesliIngredient = new HashSet<MuesliIngredient>();
            UsedMuesli = new HashSet<UsedMuesli>();
        }

        [Required]
        [StringLength(50)]
        public string NameDE { get; set; }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string NameEN { get; set; }

        public double Protein { get; set; }

        public double Carbohydrates { get; set; }

        public double Fat { get; set; }

        public int TypeId { get; set; }

        public int PortionSize { get; set; }

        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        public virtual Type Type { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MuesliIngredient> MuesliIngredient { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UsedMuesli> UsedMuesli { get; set; }

        public int sad { get; set; }
    }
}
