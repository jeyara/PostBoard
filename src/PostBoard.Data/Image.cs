namespace PostBoard.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Image")]
    public partial class Image
    {
        public Image()
        {
            ImageAttributes = new HashSet<ImageAttribute>();
            ImageSchedules = new HashSet<ImageSchedule>();
            ImageTags = new HashSet<ImageTag>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(140)]
        public string Title { get; set; }

        [StringLength(1500)]
        public string Caption { get; set; }

        [Required]
        [StringLength(140)]
        public string AltText { get; set; }

        [Required]
        [StringLength(200)]
        public string FileName { get; set; }

        public DateTime AddedOnUtc { get; set; }

        public virtual ICollection<ImageAttribute> ImageAttributes { get; set; }

        public virtual ICollection<ImageSchedule> ImageSchedules { get; set; }

        public virtual ICollection<ImageTag> ImageTags { get; set; }
    }
}
