using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Yioulaieuwechat.Web.Models.ConiqModels
{
    public class fields
    {
        public string openid { get; set; }
        public string offerid { get; set; }
        //以下是表单字段
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public phone phone { get; set; }
        public string date_of_brith { get; set; }
        public string gender { get; set; }
        public string country { get; set; }
        public string external_id { get; set; }
    }
    public class phone
    {
        public string country_code { get; set; }
        public string number { get; set; }
        
    }
}