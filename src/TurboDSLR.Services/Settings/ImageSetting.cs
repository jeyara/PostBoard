using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurboDSLR.Services.Settings
{
    public class ImageSetting
    {
        public int FeaturedImageWidth { get; set; }

        public int FeaturedImageHeight { get; set; }

        public int StreamingImageWidth { get; set; }

        public string RootImageFolder { get; set; }

        public string StreamingImageFolder { get; set; }

        public string FeaturedImageFolder { get; set; }

    }
}
