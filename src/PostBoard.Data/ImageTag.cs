namespace PostBoard.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ImageTag")]
    public partial class ImageTag
    {
        public int Id { get; set; }

        public int ImageId { get; set; }

        public int TagId { get; set; }

        public virtual Image Image { get; set; }

        public virtual Tag Tag { get; set; }
    }
}
