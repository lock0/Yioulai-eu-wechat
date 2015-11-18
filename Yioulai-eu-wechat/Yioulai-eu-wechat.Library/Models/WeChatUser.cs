using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using Yioulaieuwechat.Library.Models.Enum;
using Yioulaieuwechat.Library.Models.Interfaces;

namespace Yioulaieuwechat.Library.Models
{
    public class WeChatUser : IDtStamped
    {
        [Key]
        public Guid Id { get; set; }
        public string OpenId { get; set; }
        public string NickName { get; set; }
        public Gender Gender { get; set; }
        public string Language { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string Country { get; set; }
        public string Headimgurl { get; set; }
        /// <summary>
        /// 第三方用户Id
        /// </summary>
        public string CustomerId { get; set; }
        public string Mail { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Order> ShareOrders { get; set; }
        public DateTime? UpdateTime { get; set; }
        public DateTime CreatedTime { get; set; }
        public bool IsDeleted { get; set; }
    }
    public class WeChatUserMapping : EntityTypeConfiguration<WeChatUser>
    {
        public WeChatUserMapping()
        {
            HasMany(c => c.Orders)
                .WithOptional(p => p.WeChatUser)
                .HasForeignKey(p => p.WeChatUserId);
            HasMany(c => c.ShareOrders)
               .WithOptional(p => p.Sharer)
               .HasForeignKey(p => p.SharerId);
        }
    }
}
