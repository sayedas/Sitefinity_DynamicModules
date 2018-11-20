using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitefinityWebApp.Mvc.Models
{
    public class EventList
    {
        public string Title { get; set; }
        public string description { get; set; }
        public DateTime EventStart { get; set; }
        public DateTime? EventEnd { get; set; }
        public string Street { get; set; }
        public List<string> Categories { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string Image { get; set; }
        public string Organiser { get; set; }
    }
}