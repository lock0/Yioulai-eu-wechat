using System;
using System.ComponentModel.DataAnnotations;
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
        public DateTime? UpdateTime { get; set; }
        public DateTime CreatedTime { get; set; }
        public bool IsDeleted { get; set; }
    }
}
