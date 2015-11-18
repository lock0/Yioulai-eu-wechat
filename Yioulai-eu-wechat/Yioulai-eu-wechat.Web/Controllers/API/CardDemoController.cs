using AutoMapper;
using Yioulaieuwechat.Library.Models;
using Yioulaieuwechat.Library.Services;
using Yioulaieuwechat.Web.Models;
using System.Linq;

namespace Yioulaieuwechat.Web.Controllers.API
{
    public class CardDemoController : BaseApiController
    {
        private readonly ICardDemoService _cardDemoService;
        public CardDemoController(ICardDemoService cardDemoService)
        {
            _cardDemoService = cardDemoService;
        }
        public object Get()
        {
            Mapper.Reset();
            Mapper.CreateMap<CardType, CardTypeModel>();
            Mapper.CreateMap<CardDemo, CardDemoModel>().ForMember(n => n.CardTypeModel, opt => opt.MapFrom(src => src.CardType));
            return _cardDemoService.GetCardDemos().Select(Mapper.Map<CardDemo, CardDemoModel>);
        }
    }
}
