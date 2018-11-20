using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Telerik.Sitefinity.Mvc;

namespace SitefinityWebApp.Mvc.Controllers
{
    [ControllerToolboxItem(Name = "EventList", Title = "EventList", SectionName = "MVCWidget")]
    public class EventsFiltersController : Controller
    {
        // GET: EventsFilters 
        public ActionResult Index()
        {
            EventsFilterModel model = new EventsFilterModel(); 
            return View();
        }
    }
}