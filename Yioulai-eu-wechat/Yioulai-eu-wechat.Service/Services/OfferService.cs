using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yioulaieuwechat.Library.Models;
using Yioulaieuwechat.Library.Services;

namespace Yioulaieuwechat.Service.Services
{
    public class OfferService : BaseService, IOfferService
    {
        public OfferService(YioulaieuwechatDataContext dbContext)
            : base(dbContext)
        {
        }
        public Offer GetOffer(string offerId)
        {
            return DbContext.Offers.FirstOrDefault(n => n.OfferId == offerId);
        }

        public Offer GetOffer(Guid id)
        {
            return DbContext.Offers.FirstOrDefault(n => n.Id == id);
        }

        public IQueryable<Offer> GetOffers()
        {
            return DbContext.Offers;
        }

        public void Insert(Offer offer)
        {
            DbContext.Offers.Add(offer);
            DbContext.SaveChanges();
        }

        public void Update()
        {
            DbContext.SaveChanges();
        }
    }
}
