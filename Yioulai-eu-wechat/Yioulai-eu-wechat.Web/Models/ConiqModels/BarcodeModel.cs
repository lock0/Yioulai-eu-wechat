using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Yioulaieuwechat.Web.Models.ConiqModels
{
    public class BarcodeModel
    {
        public string barcode_number { get; set; }
        public int offer_id { get; set; }
        public int customer_id { get; set; }
        public string channel { get; set; }
        public string tracking_code { get; set; }
        public string image_url { get; set; }
        public DateTime created_datetime_utc { get; set; }
    }
}