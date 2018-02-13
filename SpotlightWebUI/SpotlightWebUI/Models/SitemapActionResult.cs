using System.Collections.Generic;
using System.Web.Mvc;
using System.Xml;

namespace SpotlightWebUI.Models {
    public class SitemapActionResult : ActionResult {
        private List<SitemapNode> _SitemapItems;
        private string _Website;
        public SitemapActionResult(List<SitemapNode> SitemapItems, string Website) {
            this._SitemapItems = SitemapItems;
            this._Website = Website;
        }
        public override void ExecuteResult(ControllerContext context) {
            context.HttpContext.Response.ContentType = "text/xml";
            using (XmlWriter writer = XmlWriter.Create(context.HttpContext.Response.Output)) {
                writer.WriteStartElement("urlset", "http://www.sitemaps.org/schemas/sitemap/0.9");
                foreach (var SiteMapItem in this._SitemapItems) {
                    writer.WriteStartElement("url");
                    writer.WriteElementString("loc", string.Format(this._Website + "{0}", SiteMapItem.Url));
                    if (SiteMapItem.LastModified != null) {
                        writer.WriteElementString("lastmod", string.Format("{0:yyyy-MM-dd}", SiteMapItem.LastModified));
                    }
                    writer.WriteElementString("changefreq", "daily");
                    writer.WriteElementString("priority", SiteMapItem.Priority.ToString());
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
                writer.Flush();
                writer.Close();
            }
        }
    }
}