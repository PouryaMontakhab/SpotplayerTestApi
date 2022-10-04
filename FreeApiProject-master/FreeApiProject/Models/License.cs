using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreeApiProject.Models
{
    public class License
    {
        public List<string> Course { get; set; }
        public string Name { get; set; }
        public Watermark Watermark { get; set; }
    }
    public class Watermark
    {
        public List<InnerText> Texts { get; set; }
    }
    public class Response
    {
        public string _id { get; set; }
        public string key { get; set; }
        public string url { get; set; }
    }
    public class InnerText
    {
        public string Text { get; set; }
    }
}
