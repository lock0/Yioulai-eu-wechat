using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yioulaieuwechat.Library.Models;

namespace Yioulaieuwechat.Library.Services
{
    public interface ICardDemoService : IDisposable
    {
        void Insert(CardDemo cardDemo);
        void Update();
        void Delete(Guid id);
        CardDemo GetCardDemo(Guid id);
        IQueryable<CardDemo> GetCardDemos();
    }
}
