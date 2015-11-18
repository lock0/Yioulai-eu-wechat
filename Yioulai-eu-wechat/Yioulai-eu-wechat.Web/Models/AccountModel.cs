using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Yioulaieuwechat.Web.Models
{
    public class AccountModel
    {
      
        public Guid Id { get; set; }
        public WeChatUserModel WeChatUserModel { get; set; }
        /// <summary>
        /// 手机号码
        /// </summary>
        public string PhoneNum { get; set; }
        public string Email { get; set; }
        public MangoCardModel[] MangoCards { get; set; }
        public CompanyModel CompanyModel { get; set; }
        public DateTime? UpdateTime { get; set; }
        public DateTime CreatedTime { get; set; }
        public bool IsDeleted { get; set; }
    }
}