using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yioulaieuwechat.Library.Models;

namespace Yioulaieuwechat.Library.Services
{
    public interface ICardTypeService : IDisposable
    {
        void Insert(CardType cardType);
        void Update();
        void Delete(Guid id);
        CardType GetCardType(Guid id);
        IQueryable<CardType> GetCardTypes();
    }
}
