using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TurboDSLR.Framework.Exif;

namespace TurboDSLR.Web.Models
{
    public class ExifModel
    {
        public ExifModel()
        {
            CapturedDateTime = null;
        }

        public ExifModel(Dictionary<int, ExifTag> tags)
        {
            string gpsla = "", gpslar = "", gpslo = "", gpslor = "";
            CapturedDateTime = null;

            foreach (var item in tags)
            {

                switch (item.Value.FieldName)
                {
                    case "ISOSpeedRatings":
                        ISO = item.Value.Value;
                        break;
                    case "Copyright":
                        CopyRight = item.Value.Value;
                        break;
                    case "DateTimeOriginal":
                        CapturedDateTime = DateTime.ParseExact(item.Value.Value, "yyyy:MM:dd hh:mm:ss", null);
                        break;
                    case "FNumber":
                        Aperture = item.Value.Value;
                        break;
                    case "ExposureBiasValue":
                        Ev = item.Value.Value;
                        break;
                    case "Flash":
                        FlashFired = item.Value.Value.ToLower().Contains("not") ? false : true;
                        break;
                    case "FocalLength":
                        FocalLength = item.Value.Value;
                        break;
                    case "ExposureMode":
                        ExposureMode = item.Value.Value;
                        break;
                    case "Model":
                        Camera = item.Value.Value;
                        break;
                    case "GPSLatitudeRef":
                        gpslar = item.Value.Value.ToLower().Contains("south") ? "S" : "N";
                       break;
                    case "GPSLatitude":
                       gpsla = item.Value.Value;
                        break;
                    case "GPSLongitudeRef":
                         gpslor = item.Value.Value.ToLower().Contains("east") ? "E" : "W";
                       break;
                    case "GPSLongitude":
                       gpslo = item.Value.Value;
                        break;
                    default:
                        break;
                }
            }

            if (!string.IsNullOrWhiteSpace(gpsla) && !string.IsNullOrWhiteSpace(gpslar) && !string.IsNullOrWhiteSpace(gpslo) && !string.IsNullOrWhiteSpace(gpslor))
            {
                GPSCoordinates = string.Format("{0} {1},{2} {3}", gpsla, gpslar, gpslo, gpslor);
            }
        }

        public string ISO { get; set; }

        public string Aperture { get; set; }

        public string ShutterSpeed { get; set; }

        public bool FlashFired { get; set; }

        public string Ev { get; set; }

        public string FocalLength { get; set; }

        public string ExposureMode { get; set; }

        public string CopyRight { get; set; }

        public string Camera { get; set; }

        public string GPSCoordinates { get; set; }

        public DateTime? CapturedDateTime { get; set; }

    }
}