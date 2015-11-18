using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yioulaieuwechat.Library.Models.Interfaces;

namespace Yioulaieuwechat.Library.Models
{
    public class Order : IDtStamped
    {
        public Guid Id { get; set; }
        public Guid? OfferId { get; set; }
        [ForeignKey("OfferId")]
        public virtual Offer Offer { get; set; }
        public Guid? SharerId { get; set; }
        [ForeignKey("SharerId")]
        public virtual WeChatUser Sharer { get; set; }
        public Guid? WeChatUserId { get; set; }
        [ForeignKey("WeChatUserId")]
        public virtual WeChatUser WeChatUser { get; set; }
        public DateTime? UpdateTime { get; set; }
        public DateTime CreatedTime { get; set; }
        public bool IsDeleted { get; set; }
    }
}
