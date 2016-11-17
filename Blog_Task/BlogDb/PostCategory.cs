namespace Blog_Task.BlogDb
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PostCategory")]
    public partial class PostCategory
    {
        public int Id { get; set; }

        public int? CategoryId { get; set; }

        public int? PostId { get; set; }

        public virtual Category Category { get; set; }

        public virtual Post Post { get; set; }
    }
}
