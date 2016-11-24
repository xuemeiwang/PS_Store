namespace PS_Store.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Menu")]
    public partial class Menu
    {
        public int Id { get; set; }

        [StringLength(128)]
        public string Category { get; set; }

        [StringLength(256)]
        public string Name { get; set; }

        [StringLength(256)]
        public string ShortDescription { get; set; }

        [StringLength(512)]
        [ScaffoldColumn(false)]
        public string LongDescription { get; set; }

        [StringLength(128)]
        public string ThumbnailImage { get; set; }

        [StringLength(128)]
        public string FullImage { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Price { get; set; }
    }
}
