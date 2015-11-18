using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Yioulaieuwechat.Library.Models.Interfaces;

namespace Yioulaieuwechat.Library.Models
{
    public class Account:IDtStamped
    {
        [Key]
        public Guid Id { get; set; }
        public virtual WeChatUser WeChatUser { get; set; }
        /// <summary>
        /// 手机号码
        /// </summary>
        public string PhoneNum { get; set; }
        public string Email { get; set; }
        public virtual ICollection<MangoCard> MangoCards { get; set; } 
        public virtual Company Company { get; set; }
        public DateTime? UpdateTime { get; set; }
        public DateTime CreatedTime { get; set; }
        public bool IsDeleted { get; set; }
    }
}
