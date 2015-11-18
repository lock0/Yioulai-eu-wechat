using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Yioulaieuwechat.Web.Models
{
    public class MangoCardModel
    {      
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ThumbnailUrl { get; set; }
        public CardTypeModel CardTypeModel { get; set; }
        public AccountModel AccountModel { get; set; }
        public string HtmlCode { get; set; }
        /// <summary>
        /// 是否发布
        /// </summary>
        public bool IsPublish { get; set; }
        /// <summary>
        /// 浏览量
        /// </summary>
        public PvDataModel[] PvDataModels { get; set; }
        /// <summary>
        /// 分享次数
        /// </summary>
        public ShareTimeModel[] ShareTimeModels { get; set; }
        public OrderModel[] OrderModels { get; set; }
        public DateTime? UpdateTime { get; set; }
        public DateTime CreatedTime { get; set; }
        public bool IsDeleted { get; set; }
    }
}