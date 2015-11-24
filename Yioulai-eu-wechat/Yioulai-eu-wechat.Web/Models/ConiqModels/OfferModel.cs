using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Yioulaieuwechat.Web.Models.ConiqModels
{
    public class OfferModel
    {
        public string id { get; set; }
        public string description { get; set; }
        public string title { get; set; }
        /// <summary>
        /// 过期日期
        /// </summary>
        public DateTime? expiry_date { get; set; }
        public DateTime start_date { get; set; }
        public int[] valid_days { get; set; }
        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime created_datetime_utc { get; set; }
        /// <summary>
        /// 处理offerId的controller的url
        /// </summary>
        public string QrCodeUrl { get; set; }
    }
}