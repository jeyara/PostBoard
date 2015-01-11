using TurboDSLR.Data.Repository;

namespace TurboDSLR.Data.Models
{
    public partial class ImageTag : BaseEntity
    {
        public int Id { get; set; }

        public int ImageId { get; set; }

        public int TagId { get; set; }

        public virtual Image Image { get; set; }

        public virtual Tag Tag { get; set; }

    }
}
