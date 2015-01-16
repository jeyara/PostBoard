using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TurboDSLR.Web.Models
{
    public class HomeModel:BaseModel
    {

        public HomeModel()
        {
            HomePhotos = new List<PhotoModel>();
        }

        public IList<PhotoModel> HomePhotos { get; set; }

    }


}