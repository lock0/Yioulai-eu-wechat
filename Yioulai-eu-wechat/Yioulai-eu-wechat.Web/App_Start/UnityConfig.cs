using System.Web.Http;
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Yioulaieuwechat.Library.Services;
using Yioulaieuwechat.Service.Services;
using Unity.Mvc5;

namespace Yioulaieuwechat.Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = BuildUnityContainer();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
        }
        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();
            RegisterTypes(container);

            return container;
        }
        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<IOfferService, OfferService>();
            container.RegisterType<ICountryCodeService, CountryCodeService>();
            container.RegisterType<IWeChatUserService, WeChatUserService>();
        }
    }
}