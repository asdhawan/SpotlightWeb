using SpotlightWebUI.Models;
using System.Collections.Generic;
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
            string imagesPath = HostingEnvironment.MapPath(baseServerPath);
            foreach (FileInfo fi in Directory.GetFiles(imagesPath).Select(x => new FileInfo(x)).Where(x => !x.Extension.Contains("txt"))) {
                list.Add(new ImageInfo() { ImagePath = Url.Content(baseServerPath + fi.Name) });
            }
            return list;
        }
    }
}