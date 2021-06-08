using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace JustMuesli.Models
{
    public partial class DB : DbContext
    {
        public DB()
            : base("name=DB1")
        {
        }

        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<CreatedMuesli> CreatedMuesli { get; set; }
        public virtual DbSet<Ingredient> Ingredient { get; set; }
        public virtual DbSet<Muesli> Muesli { get; set; }
        public virtual DbSet<MuesliIngredient> MuesliIngredient { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderMuesli> OrderMuesli { get; set; }
        public virtual DbSet<Type> Type { get; set; }
        public virtual DbSet<UsedMuesli> UsedMuesli { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CreatedMuesli>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<CreatedMuesli>()
                .HasMany(e => e.OrderMuesli)
                .WithRequired(e => e.CreatedMuesli)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CreatedMuesli>()
                .HasMany(e => e.UsedMuesli)
                .WithRequired(e => e.CreatedMuesli)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Ingredient>()
                .HasMany(e => e.MuesliIngredient)
                .WithRequired(e => e.Ingredient)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Muesli>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Muesli>()
                .HasMany(e => e.MuesliIngredient)
                .WithRequired(e => e.Muesli)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Muesli>()
                .HasMany(e => e.UsedMuesli)
                .WithRequired(e => e.Muesli)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Order>()
                .Property(e => e.Shipping)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Order>()
                .Property(e => e.Taxes)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.OrderMuesli)
                .WithRequired(e => e.Order)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Type>()
                .HasMany(e => e.Muesli)
                .WithRequired(e => e.Type)
                .WillCascadeOnDelete(false);
        }
    }
}
