using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yioulaieuwechat.Library.Models;

namespace Yioulaieuwechat.Library.Services
{
    public interface IOfferService : IDisposable
    {
        void Insert(Offer offer);
        void Update();
        Offer GetOffer(Guid id);
        Offer GetOffer(string offerId);
        IQueryable<Offer> GetOffers();
    }
}
