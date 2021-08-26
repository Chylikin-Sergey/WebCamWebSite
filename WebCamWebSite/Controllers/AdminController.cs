using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebCamWebSite.Models;

namespace WebCamWebSite.Controllers
{
    [OutputCache(Duration = 0)]
    public class AdminController : Controller
    {
        private dbContext context = new dbContext();
        private static int countTakeElements = 10;
        public ActionResult d026936df1996241d1cda58970b2a242 (int? count)
        {
            int countSkipElements = count ?? 0;
            if (Request.IsAjaxRequest())
            {
                return PartialView("_Records", LoadRecords(countSkipElements));
            }
            return View(LoadRecords(countSkipElements));
        }
        public ActionResult caf74675ceb79ba5cc13bafa102509369c2b53()
        {
            var messages = context.groupMessages.ToList().Where(g => g.Answer == null);

            return View(messages);
        }
        public ActionResult b92e2f286fa5100a3aa7a550f5e85d53f93ba930()
        {
            var list = context.groupMessages.ToList().Where(g => g.Answer != null).OrderBy(g => g.Question.Date);
            return View(list);
        }
        public ActionResult bae7d5be70820ed56467bd9a63744e23b47bd711(int? count)
        {
            int countSkipElements = count ?? 0;
            if (Request.IsAjaxRequest())
            {
                return PartialView("_Records1", LoadRecords(countSkipElements));
            }
            return View(LoadRecords(countSkipElements));
        }
        private IEnumerable<Info> LoadRecords (int countSkipElements)
        {
            var list = context.infos.ToList().OrderByDescending(u => u.Date).Skip(countSkipElements).Take(countTakeElements);
            return list;
        }
        public ActionResult SearchRequest (DateTime date)
        {
            var search = context.infos.ToList().FindAll(u => u.Date.Date.Equals(date.Date));
            return PartialView("_Records", search);
        }
        public bool RemoveRequest (List<int> index)
        {
            var item = (from i in context.infos
                        where index.Contains(i.Id)
                        select i);
            if (item != null)
            {
                context.infos.RemoveRange(item);
                context.SaveChanges();
                return true;
            }

            return false;
        }
        public void Verified (int id, string message, string buttonValue)
        {

            if (buttonValue != null && buttonValue == "on")
            {
                var curMessage = context.groupMessages.Where(g => g.Question.Id == id).First();
                if(curMessage != null)
                {
                    curMessage.Answer = new Message { Name = "Администратор", Msg = message, Date = DateTime.Now };
                }
            }
            else
            {
                var curMessage = context.messages.Where(m => m.Id == id).First();
                var gMessage = context.groupMessages.Where(g => g.Question.Id == curMessage.Id).First();
                context.groupMessages.Remove(gMessage);
                context.messages.Remove(curMessage);
            }
            context.SaveChanges();
        }


        public ActionResult SearchRecords1 (DateTime? date,string filter)
        {
            List<Info> search = null;
            if(date != null && !filter.Equals("Все"))
            {
                search = context.infos.ToList().FindAll(f => f.Date.Date.Equals(date) && f.state.Equals(filter));
            }
            else if(date != null)
            {
                search = context.infos.ToList().FindAll(f => f.Date.Date.Equals(date));
            }
            else if (!filter.Equals("Все"))
            {
                search = context.infos.ToList().FindAll(f => filter.Equals(f.state));
            }
            else
            {
                search = context.infos.ToList();
            }
            var result = search.OrderByDescending(o => o.Date);
            return PartialView("_Records1", result);
        }
        public void ChangeStatus (List<Dictionary<string, string>> status)
        {
            if (status != null)
            {
                foreach (var item in status)
                {
                    var id = Int32.Parse(item["id"]);
                    var girl = context.infos.Find(id);
                    if (girl != null)
                    {
                        if (item["status"] != null)
                        {
                            girl.state = item["status"];
                        }

                    }
                }
                context.SaveChanges();
            }
        }

        public bool RemoveMessage (List<int> index)
        {
            var gm = (from i in context.groupMessages
                      where index.Contains(i.Question.Id)
                      select i).ToList();
     
            if(gm != null)
            {
                foreach (var item in gm)
                {

                    var message = context.messages.Find(item.Question.Id);
                    context.messages.Remove(message);
                    message = context.messages.Find(item.Answer.Id);
                    context.messages.Remove(message);
                 }
                context.groupMessages.RemoveRange(gm);
                context.SaveChanges();
            }

            var post = context.Post.ToList().Where(p => p.Messages.Count() == 0);
            context.Post.RemoveRange(post);
            context.SaveChanges();

            return true;
        }
    }
}
