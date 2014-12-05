namespace PostBoard.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ImageSchedule")]
    public partial class ImageSchedule
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int ImageId { get; set; }

        public DateTime StartDateUtc { get; set; }

        public DateTime? EndDateUtc { get; set; }

        public virtual Image Image { get; set; }
    }
}
