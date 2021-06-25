using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Net;

namespace GeneralKnowledge.Test.App.Tests
{
    /// <summary>
    /// Image rescaling
    /// </summary>
    public class RescaleImageTest : ITest
    {
        public void Run()
        {
            // TODO
            // Grab an image from a public URL and write a function that rescales the image to a desired format
            // The use of 3rd party plugins is permitted
            // For example: 100x80 (thumbnail) and 1200x1600 (preview)
            try
            {
                Console.WriteLine("-----------------------------------");
                Console.WriteLine("       Rescale Image Test");
                Console.WriteLine("-----------------------------------");
                string url = "https://cdn.pixabay.com/photo/2015/04/19/08/32/marguerite-729510__340.jpg";
                Image image = GetImage(url);
                Image img100x80 = ResizeImage(image, new Size(100, 80));
                Image img1200x1600 = ResizeImage(image, new Size(1200, 1600));
                Console.WriteLine("Original Size : {0}x{1}", image.Width, image.Height);
                Console.WriteLine("Resize : {0}x{1}", img100x80.Width,img100x80.Height);
                Console.WriteLine("Resize : {0}x{1}", img1200x1600.Width, img1200x1600.Height);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception : " + ex.Message);
            }

        }

        //Resize the image.
        private Image ResizeImage(Image image, Size size)
        {
            Bitmap new_image = new Bitmap(size.Width, size.Height);
            Graphics g = Graphics.FromImage((Image)new_image);
            g.InterpolationMode = InterpolationMode.High;
            g.DrawImage(image, 0, 0, size.Height, size.Width);
            return new_image;
        }
        //Retrieve image from public url
        private Image GetImage(string url)
        {
            using (var wc = new WebClient())
            {
                using (var imgStream = new MemoryStream(wc.DownloadData(url)))
                {
                    var objImage = Image.FromStream(imgStream);

                    return objImage;

                }
            }
        }
    }
}
