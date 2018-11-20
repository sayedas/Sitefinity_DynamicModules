using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SitefinityWebApp.Mvc.Models;
using Telerik.Sitefinity.Modules.Events;
using Telerik.Sitefinity.GenericContent.Model;
using Telerik.Sitefinity.RelatedData;
using Telerik.Sitefinity.Model;
using Telerik.Sitefinity.Mvc;

namespace SitefinityWebApp.Mvc.Controllers
{
    [ControllerToolboxItem(Name = "EventList", Title = "EventList", SectionName = "MVCWidget")]
    public class EventListController : Controller
    {
        // GET: EventList
        public ActionResult Index()
        {
            EventsManager eventsManager = EventsManager.GetManager();
            var eventItem = eventsManager.GetEvents().Where(e => e.Title == "Universal Training").FirstOrDefault();
            var eventPosts = eventsManager.GetEvents().Where(n => n.Status == ContentLifecycleStatus.Live).ToList();
            List <EventList> li = new List<EventList>();
            foreach (var item in eventPosts)
            {
                var image = item.GetRelatedItems<Telerik.Sitefinity.Libraries.Model.Image>("Image").FirstOrDefault();//To retrieve the custom field image
                var image1 = " ";
                if (image != null)
                {
                    image1 = image.MediaUrl.ToString();
                }
                
                 var Title = item.Title;
                 var description = item.Content;
                 var EventStart = item.EventStart;
                 var EventEnd = item.EventEnd;
                var Street = item.Street;
                var City = item.City;
                var Country = item.Country;
                var State = item.State;

                li.Add(new EventList
                {
                    Title = item.Title,
                    description = item.Content,
                    EventStart = item.EventStart,
                    EventEnd = item.EventEnd,
                    Street = item.Street,
                    City = item.City,
                    Country = item.Country,
                    State = item.State,
                    Image = image1,
                    Organiser = item.GetValue("Organiser").ToString()


                });



            }
            

            return View("Index",li);
        }
    }
}