using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yioulaieuwechat.Library.Models.Interfaces;

namespace Yioulaieuwechat.Library.Models
{
    public class Offer : IDtStamped
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        /// <summary>
        /// 第三方Id
        /// </summary>
        public string OfferId { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public DateTime? UpdateTime { get; set; }
        public DateTime CreatedTime { get; set; }
        public bool IsDeleted { get; set; }
    }
    public class OfferMapping : EntityTypeConfiguration<Offer>
    {
        public OfferMapping()
        {
            HasMany(c => c.Orders)
                .WithOptional(p => p.Offer)
                .HasForeignKey(p => p.OfferId);
            
        }
    }
}
