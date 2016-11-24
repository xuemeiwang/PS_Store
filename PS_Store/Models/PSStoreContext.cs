namespace PS_Store.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class PSStoreContext : DbContext
    {
        public PSStoreContext()
            : base("name=PSStoreConnection")
        {
        }

        public virtual DbSet<Menu> Menus { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Menu>()
                .Property(e => e.Price)
                .HasPrecision(10, 2);
        }

        public System.Data.Entity.DbSet<PS_Store.Models.Soup> Soups { get; set; }

        public System.Data.Entity.DbSet<PS_Store.Models.Appetizer> Appetizers { get; set; }

        public System.Data.Entity.DbSet<PS_Store.Models.DimSum> DimSums { get; set; }

        public System.Data.Entity.DbSet<PS_Store.Models.Entree> Entrees { get; set; }

        public System.Data.Entity.DbSet<PS_Store.Models.Special> Specials { get; set; }
    }
}
