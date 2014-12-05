namespace PostBoard.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ImageAttribute")]
    public partial class ImageAttribute
    {
        public int Id { get; set; }

        public int ImageId { get; set; }

        public int AttributeId { get; set; }

        [Required]
        [StringLength(500)]
        public string Value { get; set; }

        public virtual Attribute Attribute { get; set; }

        public virtual Image Image { get; set; }
    }
}
