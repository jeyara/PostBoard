using System.Collections.Generic;
using PostBoard.Data.Repository;

namespace PostBoard.Data.Models
{
    public partial class Tag : BaseEntity
    {
        private ICollection<ImageTag> _ImageTags { get; set; }

        private ICollection<Tag> _ChildrenTag { get; set; }

        public string Name { get; set; }

        public string SeoName { get; set; }

        public int ParentId { get; set; }

        public virtual ICollection<ImageTag> ImageTags
        {
            get { return _ImageTags ?? (_ImageTags = new List<ImageTag>()); }
            protected set { _ImageTags = value; }
        }

        public virtual ICollection<Tag> ChildCategories
        {
            get { return _ChildrenTag ?? (_ChildrenTag = new List<Tag>()); }
            protected set { _ChildrenTag = value; }
        }

        //public virtual Tag ParentTag { get; set; }

    }
}
