﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Yioulaieuwechat.Web.Models
{
    public class CardTypeModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<CardTypeModel> SubCardTypeModels { get; set; }
        public CardDemoModel[] CardDemoModels { get; set; }
    }
}