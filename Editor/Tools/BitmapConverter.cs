using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace SText.Tools
{
    public static class BitmapConverter
    {
        public static byte[] BitmapToByteArray(Bitmap bitmap)
        {
            using (MemoryStream memStream = new MemoryStream())
            {
                bitmap.Save(memStream, System.Drawing.Imaging.ImageFormat.Png);
                return memStream.ToArray();
            }
        }

        public static BitmapImage BitmapToBitmapImage(Bitmap bitmap)
        {
            using (MemoryStream memStream = new MemoryStream(BitmapToByteArray(bitmap)))
            {
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.StreamSource = memStream;
                image.EndInit();
                image.Freeze();
                return image;
            }
        }
    }
}
