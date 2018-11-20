using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SitefinityWebApp.Mvc.Models;
using Telerik.Sitefinity.Modules.Blogs;
using Telerik.Sitefinity.Blogs.Model;
using Telerik.Sitefinity.GenericContent.Model;
using Telerik.Sitefinity.Taxonomies;
using Telerik.Sitefinity.Taxonomies.Model;
using Telerik.Sitefinity.Model;
using Telerik.Sitefinity.RelatedData;
using Telerik.Sitefinity.Mvc;

namespace SitefinityWebApp.Mvc.Controllers
{
    [ControllerToolboxItem(Name = "BlogList", Title = "BlogList", SectionName = "CustomWidget")]
    public class BlogListController : Controller
    {

        // GET: BlogList
        public ActionResult Index()
        {
            var Model = new BlogList();
            BlogsManager blogsManager = BlogsManager.GetManager();
            Blog blog = blogsManager.GetBlogs().Where(b => b.Title == "Blogs Lists").FirstOrDefault();//parent Blog name
            var blogpost = blogsManager.GetBlogPosts().Where(m => m.Status == ContentLifecycleStatus.Live).ToList();//data created under the blogs.


            List<BlogList> li = new List<BlogList>();
            foreach (var item in blogpost)
            {
                var image = item.GetRelatedItems<Telerik.Sitefinity.Libraries.Model.Image>("Image").FirstOrDefault();//To retrieve the custom field image
                var image1 = " ";
                if (image != null)
                {
                    image1 = image.MediaUrl.ToString();
                }
                var Title = item.Title;
                var Description = item.Content;

                li.Add(new BlogList
                {
                    Title = item.Title,
                    Description = item.Content,
                    Image = image1
                });


            }


                return View("Index", li);
            


        }
    }
}

