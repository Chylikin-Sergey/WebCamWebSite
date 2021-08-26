using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebCamWebSite.Models
{
    public class Message
    {
        //Id
        public int Id { get; set; }
        //Имя отправителя
        public string Name { get; set; }
        //Сообщение
        public string Msg { get; set; }
        //Дата
        public DateTime Date { get; set; }
    }
}