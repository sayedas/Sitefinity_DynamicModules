using SitefinityWebApp.Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Telerik.Sitefinity.GenericContent.Model;
using Telerik.Sitefinity.Modules.News;
using Telerik.Sitefinity.Mvc;
using Telerik.Sitefinity.News.Model;
using Telerik.Sitefinity.RelatedData;
using Telerik.Sitefinity.Taxonomies;
using Telerik.Sitefinity.Taxonomies.Model;
using Telerik.Sitefinity.Model;
using Telerik.OpenAccess;


namespace SitefinityWebApp.Mvc.Controllers
{
    [ControllerToolboxItem(Name = "News", Title = "News", SectionName = "MvcWidget")]
    public class NewsController : Controller
    {
        // GET: News
        public ActionResult Index()
        {
            NewsManager newsManager = NewsManager.GetManager();
            NewsItem newsItem = newsManager.GetNewsItems().Where(item => item.Title == "News").FirstOrDefault();
            var newspost = newsManager.GetNewsItems().Where(m => m.Status == ContentLifecycleStatus.Live).ToList();
            List<News> li = new List<News>();

            foreach (var item in newspost)
            {
                var image = item.GetRelatedItems<Telerik.Sitefinity.Libraries.Model.Image>("Image").FirstOrDefault();//To retrieve the custom field image
                var image1 = " ";
                if (image != null)
                {
                    image1 = image.MediaUrl.ToString();
                }
                var Title = item.Title;
                var Description = item.Content;
                li.Add(new News
                {
                    Title = item.Title,
                    Description = item.Content,
                    Image = image1
                });
            }

            return View("Index",li);
        }
        
    }

}