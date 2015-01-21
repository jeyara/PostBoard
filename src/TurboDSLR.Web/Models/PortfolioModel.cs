using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TurboDSLR.Web.Models
{
    public class PortfolioModel
    {
        public PortfolioModel()
        {
            StreamPhotos = new List<PhotoModel>();
        }

        public IList<PhotoModel> StreamPhotos { get; set; }

        public int NextPage { get; set; }

        public string Tag { get; set; }
    }
}