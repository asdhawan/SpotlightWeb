using System;

namespace SpotlightWebUI.Models {
    public class SitemapNode {
        public SitemapFrequency? Frequency { get; set; }
        public DateTime? LastModified { get; set; }
        public double? Priority { get; set; }
        public string Url { get; set; }

        public SitemapNode(string url, double priority) {
            Url = url;
            Priority = priority;
            LastModified = DateTime.Now;
        }
    }
}