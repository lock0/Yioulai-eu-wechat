using System;
using System.Data.Entity;
using Yioulaieuwechat.Library.Models;
using Yioulaieuwechat.Library.Models.Interfaces;
using Yioulaieuwechat.Library.Services;

namespace Yioulaieuwechat.Test
{
    public class YioulaieuwechatDataContext : DbContext, IDataContext
    {
        public IDbSet<Offer> Offers { get; set; }
        public IDbSet<Order> Orders { get; set; }
        public IDbSet<WeChatUser> WeChatUsers { get; set; }
        IDbSet<TEntity> IDataContext.Set<TEntity>()
        {
            return this.Set<TEntity>();
        }

        public override int SaveChanges()
        {
            var entities = ChangeTracker.Entries<IDtStamped>();

            foreach (var dtStamped in entities)
            {
                if (dtStamped.State == EntityState.Added)
                {
                    dtStamped.Entity.CreatedTime = DateTime.Now;
                }

                if (dtStamped.State == EntityState.Modified)
                {
                    dtStamped.Entity.UpdateTime = DateTime.Now;
                }
            }

            return base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Configurations.Add(new CategoryMapping());
            //modelBuilder.Configurations.Add(new AvatarMapping());
            //modelBuilder.Configurations.Add(new LetterMapping());
            modelBuilder.Configurations.Add(new OfferMapping());
            modelBuilder.Configurations.Add(new WeChatUserMapping());

            base.OnModelCreating(modelBuilder);
        }
    }

}
