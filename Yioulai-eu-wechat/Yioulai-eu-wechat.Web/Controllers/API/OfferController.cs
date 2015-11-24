using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Linq;
using Yioulaieuwechat.Library.Models;
using Yioulaieuwechat.Web.Models.ConiqModels;
using AutoMapper;
using Yioulaieuwechat.Library.Services;
using System;
using System.Web;
using System.Configuration;
using Yioulaieuwechat.Web.Help;

namespace Yioulaieuwechat.Web.Controllers.API
{
    public class OfferController : BaseApiController
    {
        private readonly IOfferService _offerService;
        public OfferController(IOfferService offerService)
        {
            _offerService = offerService;
        }
        /// <summary>
        /// 获取所有Offer
        /// </summary>
        /// <returns></returns>
        public object Get()
        {        

            //把获取的Offer插入数据库或者更新
            Mapper.CreateMap<OfferModel, Offer>().ForMember(n => n.Description, opt => opt.MapFrom(src => src.description))
                .ForMember(n => n.Title, opt => opt.MapFrom(src => src.title))
                .ForMember(n => n.ExpiryDate, opt => opt.MapFrom(src => src.expiry_date))
                .ForMember(n => n.CreatedDatetime, opt => opt.MapFrom(src => src.created_datetime_utc))
                .ForMember(n => n.OfferId, opt => opt.MapFrom(src => src.id))
                .ForMember(n => n.StartDate, opt => opt.MapFrom(src => src.start_date))
                .ForMember(n => n.ValidDays, opt => opt.MapFrom(src => string.Join(",", src.valid_days.Select(p => p.ToString()).ToArray())))
                .ForMember(n => n.Id, opt => opt.MapFrom(src => Guid.NewGuid()));
            var models = Tools.GetOffers();          
            var state = Guid.NewGuid().ToString();                     
            foreach(var item in models)
            {
                item.QrCodeUrl = string.Format(                    
                    "https://open.weixin.qq.com/connect/oauth2/authorize?appid={0}&redirect_uri={1}&response_type=code&scope=snsapi_userinfo&state={2}#wechat_redirect",
                    ConfigurationManager.AppSettings["AppId"], HttpUtility.UrlEncode(HttpContext.Current.Request.Url.Scheme+"://" + HttpContext.Current.Request.Url.Host + "/Home/QrCodeHandle?offid=" + item.id), state);
            }


            var offers = models.Select(Mapper.Map<OfferModel, Offer>);
            //新增
            var currentOffers = _offerService.GetOffers().ToArray();            
            //需要新增的
            var inserts = offers.Where(n => currentOffers.All(p => p.OfferId != n.OfferId));
            if (inserts.Any())
            {
                foreach(var item in inserts)
                {
                    _offerService.Insert(item);
                }
            }
            //需要删除的
            var deletes = currentOffers.Where(n => offers.Any(p => p.OfferId == n.OfferId) == false);
            if (deletes.Any())
            {
                foreach (var item in deletes)
                {
                    item.IsDeleted = true;
                }
            }
            //需要更新的
            var updates = currentOffers.Where(n => offers.Any(p => p.OfferId == n.OfferId));
            if (updates != null)
            {
                foreach(var item in updates)
                {
                    var first = offers.FirstOrDefault(p => p.OfferId == item.OfferId);
                    if (first != null)
                    {
                        item.StartDate = first.StartDate;
                        item.ValidDays = first.ValidDays;
                        item.Title = first.Title;
                        item.Description = first.Description;
                        item.ExpiryDate = first.ExpiryDate;
                        item.IsDeleted = false;
                    }
                }
            }
            _offerService.Update();
            return models;           

        }
    }
}
