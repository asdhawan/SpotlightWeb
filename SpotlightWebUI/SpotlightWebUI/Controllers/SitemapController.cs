using SpotlightWebUI.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace SpotlightWebUI.Controllers {
    public class SitemapController : Controller {
        public SitemapActionResult Index() {
            var Website = "http://www.spotlightes.com";
            var sitemapNodes = new List<SitemapNode>();
            sitemapNodes.Add(new SitemapNode("", 1.0));
            sitemapNodes.Add(new SitemapNode("/Home", 1.0));
            sitemapNodes.Add(new SitemapNode("/Services", 0.9));
            sitemapNodes.Add(new SitemapNode("/Services/#videoBooths", 0.85));
            sitemapNodes.Add(new SitemapNode("/Services/#casinonNights", 0.85));
            sitemapNodes.Add(new SitemapNode("/Services/#photoBooths", 0.85));
            sitemapNodes.Add(new SitemapNode("/Services/#outdoorMovies", 0.85));
            sitemapNodes.Add(new SitemapNode("/Services/#djServices", 0.85));
            sitemapNodes.Add(new SitemapNode("/Services/#videography", 0.85));
            sitemapNodes.Add(new SitemapNode("/Gallery", 0.8));
            sitemapNodes.Add(new SitemapNode("/Home/Contact", 0.7));
            return new SitemapActionResult(sitemapNodes, Website);
        }
    }
}