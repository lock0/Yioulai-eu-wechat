using System;
using System.Linq;
using Yioulaieuwechat.Library.Models;
using Yioulaieuwechat.Library.Services;

namespace Yioulaieuwechat.Service.Services
{
    public class CardDemoService : BaseService, ICardDemoService
    {
        public CardDemoService(YioulaieuwechatDataContext dbContext)
            : base(dbContext)
        {
        }
        public void Insert(CardDemo cardDemo)
        {
            DbContext.CardDemos.Add(cardDemo);
            DbContext.SaveChanges();
        }

        public void Update()
        {
            this.DbContext.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var carddemo = DbContext.CardDemos.FirstOrDefault(n => n.Id == id);
            DbContext.CardDemos.Remove(carddemo);
            Update();
        }

        public CardDemo GetCardDemo(Guid id)
        {
            return DbContext.CardDemos.FirstOrDefault(n => n.Id == id);
        }

        public IQueryable<CardDemo> GetCardDemos()
        {
            return DbContext.CardDemos.Where(n => !n.IsDeleted);
        }
       
    }
}
