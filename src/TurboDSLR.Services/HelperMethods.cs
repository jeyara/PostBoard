using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurboDSLR.Data.Models;

namespace TurboDSLR.Services
{
    public class HelperMethods
    {
        public static Image GetBaseImage(string fileName, string title= "", string caption = "")
        {
            Image img = new Image();

            img.AddedOnUtc = DateTime.UtcNow;
            img.AltText = fileName;
            img.Caption = caption;
            img.FileName = fileName;
            img.Status = Data.Enum.ImageStatus.New;
            img.Title = title;

            return img;
        }
    }
}
