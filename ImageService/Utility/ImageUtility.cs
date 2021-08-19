using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Threading.Tasks;


namespace ImageServiceApi.Utility
{
    public static class ImageUtility
    {
        public static Image GetImageFromStream(Stream fileStream) => Image.FromStream(fileStream);
        public static Image GetImageFromFile(string imagePath) => Image.FromFile(imagePath);
        public static Size GetImageSize(Image image) => new(image.Width, image.Height);

        public static Size GetImageSizeToAbsoluteWidth(Image image, int width)
        {
            var scale = (double)width / image.Width;
            var height = Convert.ToInt32(Math.Floor(image.Height * scale));
            return new(width, height);
        }
        public static Size GetImageSizeToAbsoluteHeight(Image image, int height)
        {
            var scale = (double)height / image.Height;
            var width = Convert.ToInt32(Math.Floor(image.Width * scale));
            return new(width, height);
        }

        public static Size GetImageSizeToMaxEdgeLength(Image image, double edgeLength)
        {
            var scale = edgeLength / Math.Max(image.Width, image.Height);
            var width = Convert.ToInt32(Math.Floor(image.Width * scale));
            var height = Convert.ToInt32(Math.Floor(image.Height * scale));
            return new(width, height);
        }

        public static  Task<Image> GetResizeImageAsync(Image image, Size size)
        {
            using var bmp = new Bitmap(size.Width, size.Height, PixelFormat.Format24bppRgb);
            using var graphics = Graphics.FromImage(bmp);

            graphics.InterpolationMode = InterpolationMode.Low;
            graphics.CompositingQuality = CompositingQuality.HighSpeed;
            graphics.SmoothingMode = SmoothingMode.None;
            graphics.PixelOffsetMode = PixelOffsetMode.HighSpeed;
            graphics.DrawImage(image, new Rectangle(0, 0, size.Width, size.Height));

            var imageStream = new MemoryStream();
            bmp.Save(imageStream, ImageFormat.Jpeg);

            return Task.FromResult(Image.FromStream(imageStream));
        }
    }
}
