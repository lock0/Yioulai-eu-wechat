using System;
using Yioulaieuwechat.Web.Help;
using Yioulaieuwechat.Web.Models;
using Yioulaieuwechat.Web.Models.ConiqModels;

namespace Yioulaieuwechat.Web.Controllers.API
{
    public class SendMailForSignUpController : BaseApiController
    {
        public object Post(fields model)
        {
            var response = new ResponseModel
            {
                Error = false,
                Message = "succeed, Some minutes later you'll get an e-mail at the address provided containing a link in it."
            };
            try
            {
                MailHelper.SendRegisterMail(model);
            }
            catch (Exception ex)
            {
                response.Error = true;
                response.Message = ex.Message;
            }

            return response;
        }
    }
}
