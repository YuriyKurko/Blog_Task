namespace Blog_Task.BlogDb
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Category")]
    public partial class Category
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Category()
        {
            PostCategories = new HashSet<PostCategory>();
        }

        public int Id { get; set; }

        [Index(IsUnique = true)]
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public int? BlogId { get; set; }

        public virtual Blog Blog { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PostCategory> PostCategories { get; set; }
    }
}
