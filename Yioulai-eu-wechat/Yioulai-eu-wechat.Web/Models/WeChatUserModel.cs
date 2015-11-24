﻿using Yioulaieuwechat.Web.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Yioulaieuwechat.Web.Models
{
    public class WeChatUserModel
    {       
        public Guid Id { get; set; }
        public string OpenId { get; set; }
        public string CustomerId { get; set; }
        public string Mail { get; set; }
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