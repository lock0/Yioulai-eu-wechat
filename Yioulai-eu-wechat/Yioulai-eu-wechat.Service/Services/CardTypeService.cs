using System;
using System.Linq;
using Yioulaieuwechat.Library.Models;
using Yioulaieuwechat.Library.Services;

namespace Yioulaieuwechat.Service.Services
{
    public class CardTypeService : BaseService, ICardTypeService
    {
        public CardTypeService(YioulaieuwechatDataContext dbContext)
            : base(dbContext)
        {
        }
        public void Insert(CardType cardType)
        {
            DbContext.CardTypes.Add(cardType);
            DbContext.SaveChanges();
        }

        public void Update()
        {
            DbContext.SaveChanges();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public CardType GetCardType(Guid id)
        {
            return DbContext.CardTypes.FirstOrDefault(n => n.Id == id);
        }

        public IQueryable<CardType> GetCardTypes()
        {
            return DbContext.CardTypes;
        }
    }
}
