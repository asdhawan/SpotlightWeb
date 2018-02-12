using SpotlightWebUI.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Hosting;
using System.Web.Http;

namespace SpotlightWebUI.Controllers {
    public class VideosController : ApiController {
        // GET api/<controller>
        [Route("api/videos")]
        public List<VideoInfo> Get() {
            List<VideoInfo> list = new List<VideoInfo>();
            string baseServerPath = "~/Content/gallery/videos/";
            string videosPath = HostingEnvironment.MapPath(baseServerPath);

            foreach (FileInfo fi in Directory.GetFiles(videosPath).Select(x => new FileInfo(x)).Where(x => !x.Extension.Contains("txt"))) {
                list.Add(new VideoInfo() {
                    VideoPath = Url.Content(baseServerPath + fi.Name)
                });
            }
            return list;
        }
    }
}