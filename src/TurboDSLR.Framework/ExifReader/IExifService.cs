using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurboDSLR.Framework.Exif;

namespace TurboDSLR.Framework.Exif
{
    public interface IExifService
    {
        Dictionary<int, ExifTag> ReadExifTags(string fileName, bool useEmbeddedColorManagement = true, bool validateImageData = false);

        Dictionary<int, ExifTag> ReadExifTags(Image image);
    }
}
