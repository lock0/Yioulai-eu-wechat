﻿using Yioulaieuwechat.Web.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Yioulaieuwechat.Web.Models
{
    public class EmployeeModel
    {
        public Guid Id { get; set; }
        public string Gender { get; set; }
        public string Name { get; set; }
        public string ThumbnailUrl { get; set; }      
    }
}