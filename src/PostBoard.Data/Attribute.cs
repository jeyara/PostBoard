namespace PostBoard.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Attribute")]
    public partial class Attribute
    {
        public Attribute()
        {
            ImageAttributes = new HashSet<ImageAttribute>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(250)]
        public string Description { get; set; }

        [Required]
        [StringLength(20)]
        public string Type { get; set; }

        public bool HasMultiValue { get; set; }

        public virtual ICollection<ImageAttribute> ImageAttributes { get; set; }
    }
}
