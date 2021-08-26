using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebCamWebSite.Models
{
    public class GroupMessage
    {
        public int Id { get; set; }
        public virtual Message Question { get; set; }
        public virtual Message Answer { get; set; }
        public virtual Post Post { get; set; }
    }
}