using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace PostBoard.Framework.Helper
{
    public static class ImageHelper
    {
        public static object ReadImageExif(string fullPathToImage)
        {
            Image theImage = new Bitmap(fullPathToImage);

            PropertyItem[] propItems = theImage.PropertyItems;

            return propItems;
        }

        public static Image ResizeImage(Image image, Size size, bool preserveAspectRatio = true, bool dontZoom = true)
        {
            int newWidth;
            int newHeight;
            if (preserveAspectRatio)
            {
                int originalWidth = image.Width;
                int originalHeight = image.Height;
                float percentWidth = (float)size.Width / (float)originalWidth;
                float percentHeight = (float)size.Height / (float)originalHeight;
                float percent = percentHeight < percentWidth ? percentHeight : percentWidth;
                newWidth = (int)(originalWidth * percent);
                newHeight = (int)(originalHeight * percent);
            }
            else
            {
                newWidth = size.Width;
                newHeight = size.Height;
            }

            if (dontZoom)
            {
                if (image.Width < newWidth || image.Height < newHeight)
                {
                    return image;
                }
            }

            Image newImage = new Bitmap(newWidth, newHeight);
            using (Graphics graphicsHandle = Graphics.FromImage(newImage))
            {
                graphicsHandle.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphicsHandle.PixelOffsetMode = PixelOffsetMode.HighQuality;
                graphicsHandle.CompositingQuality = CompositingQuality.HighQuality;
                graphicsHandle.SmoothingMode = SmoothingMode.AntiAlias;
                graphicsHandle.DrawImage(image, 0, 0, newWidth, newHeight);
            }

            return newImage;
        }
    }
}
