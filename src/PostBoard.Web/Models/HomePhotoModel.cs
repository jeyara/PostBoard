using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PostBoard.Framework.Common;

namespace PostBoard.Web.Models
{
    public class HomePhotoModel : IBoardPhoto
    {
        private IList<string> _hashTags;
        private Dictionary<string, string> _attributes;

        public HomePhotoModel()
        {
            _hashTags = new List<string>();
            _attributes = new Dictionary<string, string>();
        }

        #region IBoardPhoto Members

        public int Id { get; set; }

        public string Caption { get; set; }

        public string Title { get; set; }

        public string StampSizeUrl { get; set; }

        public string FullSizeUrl { get; set; }

        public string AltText { get; set; }

        public IList<string> HashTags
        {
            get
            {
                return _hashTags;
            }
            set
            {
                _hashTags = value;
            }
        }

        public Dictionary<string, string> Attributes
        {
            get
            {
                return _attributes;
            }
            set
            {
                _attributes = value;
            }
        }

        #endregion
    }
}