using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebCamWebSite.Models
{
    public class Post
    {
        public int Id { get; set; }
        public virtual ICollection<GroupMessage> Messages { get; set; }
    }
}