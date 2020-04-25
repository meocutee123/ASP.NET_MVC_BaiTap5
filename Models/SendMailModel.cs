using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BaiTap5.Models
{
    public class SendMailModel
    {
        public string From { get; set; }
        public string Password { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}