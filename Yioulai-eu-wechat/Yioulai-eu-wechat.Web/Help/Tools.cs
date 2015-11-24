using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Linq;
using Yioulaieuwechat.Web.Models.ConiqModels;
using System.Text;
using System.Web.Script.Serialization;
using Yioulaieuwechat.Library.Models;

namespace Yioulaieuwechat.Web.Help
{
    public static class Tools
    {
        public static string HttpGet(string url)
        {
            try
            {
                var myWebClient = new WebClient { Credentials = CredentialCache.DefaultCredentials };
                var pageData = myWebClient.DownloadData(url); //从指定网站下载数据  
                var pageHtml = System.Text.Encoding.Default.GetString(pageData); //如果获取网站页面采用的是GB2312，则使用这句
                return pageHtml;
            }

            catch (WebException webEx)
            {
                return webEx.Message;
            }
        }
        public static string HttpGetUTF8(string url)
        {
            try
            {
                var myWebClient = new WebClient { Credentials = CredentialCache.DefaultCredentials };
                var pageData = myWebClient.DownloadData(url); //从指定网站下载数据  
                var pageHtml = System.Text.Encoding.UTF8.GetString(pageData); //如果获取网站页面采用的是GB2312，则使用这句
                return pageHtml;
            }

            catch (WebException webEx)
            {
                return webEx.Message;
            }
        }
        /// <summary>
        /// 调用coniq api获取所有offers
        /// </summary>
        /// <returns></returns>
        public static OfferModel[] GetOffers()
        {
            var apikey = "50941883c739f5d7835db2a62297e1caa22b1c9b";
            var uri = "https://api.coniq.com/app/program/IRISTEST/offers";
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(uri);
            httpWebRequest.Headers.Add("Authorization", string.Format("ApiKey key=\"{0}\"", apikey));
            httpWebRequest.Headers.Add("x-api-version", "2.0");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "GET";
            httpWebRequest.Timeout = 20000;
            var httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            var streamReader = new StreamReader(httpWebResponse.GetResponseStream());
            string responseContent = streamReader.ReadToEnd();
            httpWebResponse.Close();
            streamReader.Close();
            var models = JsonConvert.DeserializeObject<IList<OfferModel>>(responseContent);
            return models.ToArray();
        }
        /// <summary>
        /// 获取用户mail及barcode
        /// </summary>
        /// <param name="mail"></param>
        /// <returns></returns>
        public static BarcodeModel[] GetBrcode(string mail)
        {
            var apikey = "f589e9615796f1e7371d8268d0d8f7f5002fc7ab";
            var uri = string.Format("https://api.coniq.com/barcode?customer_email={0}", mail);
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(uri);
            httpWebRequest.Headers.Add("Authorization", string.Format("ApiKey key=\"{0}\"", apikey));
            httpWebRequest.Headers.Add("x-api-version", "2.0");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "GET";
            //httpWebRequest.Timeout = 20000;
            var httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            var streamReader = new StreamReader(httpWebResponse.GetResponseStream());
            string responseContent = streamReader.ReadToEnd();
            httpWebResponse.Close();
            streamReader.Close();
            var models = JsonConvert.DeserializeObject<IList<BarcodeModel>>(responseContent);
            return models.ToArray();
        }
        public static bool BindQrcode(WeChatUser wechauser, string offerid)
        {
            //在coniq绑定offer
            var apikey = "f589e9615796f1e7371d8268d0d8f7f5002fc7ab";
            var uri = "https://api.coniq.com/barcode";
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(uri);
            httpWebRequest.Headers.Add("Authorization", string.Format("ApiKey key=\"{0}\"", apikey));
            httpWebRequest.Headers.Add("x-api-version", "2.0");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            //httpWebRequest.Timeout = 20000;

            string json = new JavaScriptSerializer().Serialize(new
            {
                offer_id =offerid,
                customer_id= wechauser.CustomerId,
                channel= "MAIL"
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
                    return true;
                }                
            }
            return false;
        }
    }
}