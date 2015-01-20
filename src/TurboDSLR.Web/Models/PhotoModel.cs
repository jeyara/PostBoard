using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TurboDSLR.Framework.Common;

namespace TurboDSLR.Web.Models
{
    public class PhotoModel : BaseEntityModel
    {
        public PhotoModel()
        {
            HashTags = new List<string>();
            ExifData = new ExifModel();
        }

        #region IBoardPhoto Members

        public string Caption { get; set; }

        public string Title { get; set; }

        public string StampSizeUrl { get; set; }

        public string FullSizeUrl { get; set; }

        public string AltText { get; set; }

        public ExifModel ExifData { get; set; }

        public IList<string> HashTags { get; set; }

        #endregion
    }
}