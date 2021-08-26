using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebCamWebSite.Models
{
    public class Info
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Surname { get; set; }
        public string Message { get; set; }
        public string TelegramNumber { get; set; }
        public string Instagram { get; set; }
        public DateTime Date { get; set; }
        public string state { get; set; }


    }
}