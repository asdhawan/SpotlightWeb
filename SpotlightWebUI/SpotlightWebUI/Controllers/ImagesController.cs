using SpotlightWebUI.Models;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Web.Hosting;
using System.Web.Http;

namespace SpotlightWebUI.Controllers {
    public class ImagesController : ApiController {
        // GET api/<controller>
        [Route("api/images")]
        public List<ImageInfo> Get() {
            List<ImageInfo> list = new List<ImageInfo>();
            string baseServerPath = "~/Content/gallery/images/";
            string baseThumbnailsPath = baseServerPath + "thumbs/";
            string imagesPath = HostingEnvironment.MapPath(baseServerPath);
            string thumbNailsPath = HostingEnvironment.MapPath(baseThumbnailsPath);
            if (!Directory.Exists(thumbNailsPath))
                Directory.CreateDirectory(thumbNailsPath);

            foreach (FileInfo fi in Directory.GetFiles(imagesPath).Select(x => new FileInfo(x)).Where(x => !x.Extension.Contains("txt"))) {
                try {
                    string thumbnailName = string.Format("thumb_{0}", fi.Name);
                    string thumbnailLocalPath = thumbNailsPath + Path.DirectorySeparatorChar + thumbnailName;
                    string imageLocalPath = imagesPath + Path.DirectorySeparatorChar + fi.Name;
                    if (!File.Exists(thumbnailLocalPath)) {
                        Image resized = ResizeImage(Image.FromFile(imageLocalPath), 350);
                        resized.Save(thumbnailLocalPath);
                    }
                    list.Add(new ImageInfo() {
                        ImagePath = Url.Content(baseServerPath + fi.Name),
                        ThumbnailPath = Url.Content(baseThumbnailsPath + thumbnailName)
                    });
                } catch { /*Ignore*/ }
            }
            return list;
        }

        private Image ResizeImage(Image original, int targetWidth) {
            double percent = (double)original.Width / targetWidth;
            int destWidth = (int)(original.Width / percent);
            int destHeight = (int)(original.Height / percent);

            Bitmap b = new Bitmap(destWidth, destHeight);
            Graphics g = Graphics.FromImage((Image)b);
            try {
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                g.CompositingQuality = CompositingQuality.HighQuality;

                g.DrawImage(original, 0, 0, destWidth, destHeight);
            } finally {
                g.Dispose();
            }

            return (Image)b;
        }
    }
}