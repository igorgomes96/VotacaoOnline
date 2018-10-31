using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;

namespace CIPAOnLine.Services
{
    public class ImageService
    {
        public static Bitmap CropImage(Bitmap source, Rectangle section)
        {
            Bitmap bmp = new Bitmap(section.Width, section.Height);
            Graphics g = Graphics.FromImage(bmp);
            g.DrawImage(source, 0, 0, section, GraphicsUnit.Pixel);

            return bmp;
        }

        public static Bitmap EnquadrarImagem(Bitmap source)
        {
            Rectangle? section = null;

            if (source.Height > source.Width)
            {
                float dif = source.Height - source.Width;
                section = new Rectangle(new Point(0, Convert.ToInt32(dif / 2)), new Size(source.Width, source.Width));
            }
            else
            {
                float dif = source.Width - source.Height;
                section = new Rectangle(new Point(Convert.ToInt32(dif / 2), 0), new Size(source.Height, source.Height));
            }

            Bitmap CroppedImage = CropImage(source, section.Value);
            return CroppedImage;
        }

        public static byte[] ConvertImageByte(Image image)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(image, typeof(byte[]));
        }

        public static Image GetThumbnail(Image image, int height, int width)
        {
            return image.GetThumbnailImage(width, height, null, IntPtr.Zero);
        }
    }
}