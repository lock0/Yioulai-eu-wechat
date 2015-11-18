using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Yioulaieuwechat.Library.Models.Interfaces;

namespace Yioulaieuwechat.Library.Models
{
    public class MangoCard : IDtStamped
    {
        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ThumbnailUrl { get; set; }
        public virtual CardType CardType { get; set; }
        public virtual Account Account { get; set; }
        public string HtmlCode { get; set; }
        /// <summary>
        /// 是否发布
        /// </summary>
        public bool IsPublish { get; set; }
        /// <summary>
        /// 浏览量
        /// </summary>
        public virtual ICollection<PvData> PvDatas { get; set; }
        /// <summary>
        /// 分享次数
        /// </summary>
        public virtual ICollection<ShareTime> ShareTimes { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public DateTime? UpdateTime { get; set; }
        public DateTime CreatedTime { get; set; }
        public bool IsDeleted { get; set; }
    }
}
