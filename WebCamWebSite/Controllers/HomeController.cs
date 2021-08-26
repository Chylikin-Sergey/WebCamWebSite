using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using WebCamWebSite.Models;
using WebCamWebSite.Util;

namespace WebCamWebSite.Controllers
{

    public class HomeController : Controller
    {
        private dbContext context = new dbContext();
        [OutputCache(Duration = 604800, Location = OutputCacheLocation.Downstream)]
        public ActionResult Index ()
        {
           
            return View();
        }
        [OutputCache(Duration = 604800, Location = OutputCacheLocation.Downstream)]
        public ActionResult Contacts ()
        {
            return View();
        }
        [OutputCache(Duration = 604800, Location = OutputCacheLocation.Downstream)]
        public ActionResult Comments ()
        {
            return View();
        }
        [OutputCache(Duration = 604800, Location = OutputCacheLocation.Downstream)]
        public ActionResult FAQ ()
        {
            return View();
        }
        public ActionResult Ask_a_Questions ()
        {
            var list = context.Post.ToList();
            return View(list);
        }
        [HttpPost]
        public ActionResult Contacts (Info info)
        {
            info.Date = DateTime.Now;
            info.state = "Не выбрано";
            context.infos.Add(info);
            context.SaveChanges();

            return View("Index");
        }
        [HttpPost]
        public ActionResult Ask_a_Questions (string name, string message, int idAnswer)
        {

            Post post = null;
     
            var newMessage = new Message { Name = name, Msg = message, Date = DateTime.Now };
            var newGroup = new GroupMessage{ Question = newMessage};
            context.messages.Add(newMessage);
            context.groupMessages.Add(newGroup);

            var gm = context.groupMessages.Where(g => g.Question.Id == idAnswer || g.Answer.Id == idAnswer).FirstOrDefault();
            if (gm != null)
            {
                post = context.Post.Find(gm.Post.Id);
                post.Messages.Add(newGroup);
            }
            else
            {
                post = new Post();
                post.Messages = new List<GroupMessage>() { newGroup};
                context.Post.Add(post);
            }

            context.SaveChanges();
            return View();
        }
        public ActionResult Sitemap ()
        {
            Generator sitemapGenerator = new Generator();
            var sitemapNodes = sitemapGenerator.GetSitemapNodes(this.Url);
            string xml = sitemapGenerator.GetSitemapDocument(sitemapNodes);
            return this.Content(xml, "text/xml", Encoding.UTF8);
        }
    }
}