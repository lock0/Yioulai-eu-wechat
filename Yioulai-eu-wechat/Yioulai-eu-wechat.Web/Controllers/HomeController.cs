using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Yioulaieuwechat.Library.Models;
using Yioulaieuwechat.Library.Services;
using Yioulaieuwechat.Web.Help;
using Yioulaieuwechat.Web.Models;
using Yioulaieuwechat.Web.Models.ConiqModels;

namespace Yioulaieuwechat.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWeChatUserService _weChatUserService;
        private readonly IOfferService _offerService;
        private readonly ICountryCodeService _countryCodeService;
        public HomeController(IWeChatUserService weChatUserService, IOfferService offerService, ICountryCodeService countryCodeService)
        {
            _weChatUserService = weChatUserService;
            _offerService = offerService;
            _countryCodeService = countryCodeService;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetMangoCard()
        {
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult QrCodeHandle()
        {
            return View();
        }
        public ActionResult LoginConfirmation()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult MyQrCodeList()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult VerifyEmail()
        {
            var response = new ResponseModel
            {
                Error = false,
                Message = "succeed"
            };
            try
            {
                var jsonStr = System.Text.Encoding.Default.GetString(Convert.FromBase64String(HttpContext.Request["code"]));

                var fields = JsonConvert.DeserializeObject<fields>(jsonStr);
                var wechauser = _weChatUserService.GetWeChatUser(fields.openid);

                fields.gender = wechauser.Gender == Library.Models.Enum.Gender.女 ? "F" : "M";
                fields.country = _countryCodeService.GetCountryCode(wechauser.Country).Code;
                fields.external_id = fields.openid;

                //coniq注册用户
                var apikey = "f589e9615796f1e7371d8268d0d8f7f5002fc7ab";
                var uri = "https://poweredby.coniq.com/signup/0bnkao0.json";
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(uri);
                httpWebRequest.Headers.Add("Authorization", string.Format("ApiKey key=\"{0}\"", apikey));
                httpWebRequest.Headers.Add("x-api-version", "2.0");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                httpWebRequest.Timeout = 20000;

                string json = new JavaScriptSerializer().Serialize(new
                {
                    fields = new
                    {
                        first_name = fields.first_name,
                        last_name = fields.last_name,
                        email = fields.email,
                        phone = fields.phone,
                        date_of_birth = fields.date_of_brith,
                        gender = fields.gender,
                        country = fields.country,
                        external_id = fields.openid
                    }

                });


                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    streamWriter.Write(json);
                    streamWriter.Flush();
                    streamWriter.Close();
                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    var status = (int)httpResponse.StatusCode;
                    streamReader.Close();
                    if (status == 201)
                    {
                        //通过email获取用户的 customer_id
                        var customerid = Tools.GetBrcode(fields.email).Select(n => n.customer_id).FirstOrDefault();
                        wechauser.CustomerId = customerid.ToString();
                        wechauser.Mail = fields.email;
                        _weChatUserService.Update();
                        //绑定qrcode
                        if (Tools.BindQrcode(wechauser, fields.offerid))
                        {
                            var offer = _offerService.GetOffer(fields.offerid);
                            if (offer != null)
                            {
                                var order = new Order
                                {
                                    Id = Guid.NewGuid(),
                                    OfferId = offer.Id,
                                };
                                //if (!string.IsNullOrEmpty(shareid))
                                //{
                                //    order.SharerId = new Guid(shareid);
                                //}
                                wechauser.Orders.Add(order);
                            }
                            _weChatUserService.Update();
                        }

                    }
                    else
                    {
                        response.Error = true;
                        response.Message = result;
                    }
                }

            }
            catch (Exception ex)
            {
                response.Error = true;
                response.Message = ex.Message;
            }
            return View(response);
        }
    }
}