using PostBoard.Data.Repository;

namespace PostBoard.Data.Models
{
    public partial class ImageAttribute : BaseEntity
    {
        public int ImageId { get; set; }

        public int AttributeId { get; set; }

        public string Value { get; set; }

        public virtual Attribute Attribute { get; set; }

        public virtual Image Image { get; set; }

    }
}
