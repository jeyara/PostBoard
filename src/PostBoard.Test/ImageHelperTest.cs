using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PostBoard.Framework.Exif;
using PostBoard.Framework.Helper;

namespace PostBoard.Test
{

    [TestClass]
    public class ImageHelperTest
    {
        [TestMethod]
        public void ReadMetaTest()
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            baseDir = System.IO.Path.Combine(baseDir,"TestAssets");
            baseDir = baseDir + "\\hornsby-cloud.jpg";

            var res = ImageHelper.ReadImageExif(baseDir);



             var exif = new ExifTagCollection(baseDir);


        }
    }
}
