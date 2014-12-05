namespace PostBoard.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Tag")]
    public partial class Tag
    {
        public Tag()
        {
            ImageTags = new HashSet<ImageTag>();
            Tag1 = new HashSet<Tag>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public int ParentId { get; set; }

        public virtual ICollection<ImageTag> ImageTags { get; set; }

        public virtual ICollection<Tag> Tag1 { get; set; }

        public virtual Tag Tag2 { get; set; }
    }
}
