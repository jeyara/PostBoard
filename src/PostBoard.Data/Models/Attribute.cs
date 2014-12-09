using System.Collections.Generic;
using PostBoard.Data.Repository;

namespace PostBoard.Data.Models
{
    public class Attribute : BaseEntity
    {
        private ICollection<ImageAttribute> _ImageAttributes;

        public string Name { get; set; }

        public string Description { get; set; }

        public string Type { get; set; }

        public bool HasMultiValue { get; set; }

        public virtual ICollection<ImageAttribute> ImageAttributes
        {
            get { return _ImageAttributes ?? (_ImageAttributes = new List<ImageAttribute>()); }
            protected set { _ImageAttributes = value; }
        }


    }
}
