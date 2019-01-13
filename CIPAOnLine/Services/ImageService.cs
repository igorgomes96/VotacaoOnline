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

        public static Bitmap EnquadrarImagem(Bitmap bmp)
        {
            int t = 0, l = 0, size = 0;
            if (bmp.Height > bmp.Width) {
                size = bmp.Width;
                t = (bmp.Height - bmp.Width) / 2;
            } else {
                size = bmp.Height;
                l = (bmp.Width - bmp.Height) / 2;
            }

            Bitmap res = new Bitmap(size, size);
            Graphics g = Graphics.FromImage(res);
            g.FillRectangle(new SolidBrush(Color.White), 0, 0, size, size);
            
            g.DrawImage(bmp, new Rectangle(0, 0, size, size), new Rectangle(l, t, bmp.Width - l * 2, bmp.Height - t * 2), GraphicsUnit.Pixel);
            return res;
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