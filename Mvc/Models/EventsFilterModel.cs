using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitefinityWebApp.Mvc.Models
{
    public class EventsFilter
    {
        public List<product> product { get; set; }
        public List<news> industry { get; set; }
        public List<region> region { get; set; }
    }
    public class product
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
    public class news
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
    public class region
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}