using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Drawing.Imaging;

namespace SText.Tools
{
    public static class BitmapConverter
    {
        public static byte[] BitmapToByteArray(Bitmap bitmap, ImageFormat format)
        {
            using (MemoryStream memStream = new MemoryStream())
            {
                bitmap.Save(memStream, format);
                return memStream.ToArray();
            }
        }

        public static BitmapImage ByteArrayToBitmapImage(byte[] bytes)
        {
            using (var ms = new MemoryStream(bytes))
            {
                ms.Seek(0, SeekOrigin.Begin);
                var image = new BitmapImage();
                image.BeginInit();
                image.StreamSource = ms;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.EndInit();

                return image;
            }
        }

        public static BitmapImage BitmapToBitmapImage(Bitmap bitmap, ImageFormat format)
        {
            using (var ms = new MemoryStream())
            {
                bitmap.Save(ms, format);
                ms.Seek(0, SeekOrigin.Begin);
                var image = new BitmapImage();
                image.BeginInit();
                image.StreamSource = ms;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.EndInit();

                return image;
            }
        }

    }
}
