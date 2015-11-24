using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Yioulaieuwechat.Web.Models.ConiqModels;

namespace Yioulaieuwechat.Web.Models
{
    public class QrCodeHandleModel
    {
        public OfferModel ConiqOfferModel { get; set; }
        public WeChatUserModel WeChatUserModel { get; set; }
        public Guid? ShareId { get; set; }
    }
}