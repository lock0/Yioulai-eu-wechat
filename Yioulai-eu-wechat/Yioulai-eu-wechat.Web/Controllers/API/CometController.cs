using Yioulaieuwechat.Library.Services;
using Yioulaieuwechat.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace Yioulaieuwechat.Web.Controllers.API
{
    public class CometController : AsyncController
    {
        private readonly ILoginLogService _loginLogService;
        public CometController(ILoginLogService loginLogService, IWeChatUserService weChatUserService)
        {
            _loginLogService = loginLogService;          
        }
        //LongPolling Action 1 - 处理客户端发起的请求
        public void LongPollingAsync()
        {
            var state = Request["state"];
            //计时器，5秒种触发一次Elapsed事件
            System.Timers.Timer timer = new System.Timers.Timer(1000);
            //告诉ASP.NET接下来将进行一个异步操作
            AsyncManager.OutstandingOperations.Increment();
            //订阅计时器的Elapsed事件
            timer.Elapsed += (sender, e) =>
            {
                
                if (state != null)
                {
                    var log = _loginLogService.GetLoginLog(state);
                    if (log != null)
                    {
                        //保存将要传递给LongPollingCompleted的参数
                        AsyncManager.Parameters["model"] = new LoginLogModel {
                            Id=log.Id,
                            CreateTime=log.CreateTime,
                            State=log.State
                        };
                        //告诉ASP.NET异步操作已完成，进行LongPollingCompleted方法的调用
                        AsyncManager.OutstandingOperations.Decrement();
                    }                    

                }
                

               
            };
            //启动计时器
            timer.Start();
        }

        //LongPolling Action 2 - 异步处理完成，向客户端发送响应
        public ActionResult LongPollingCompleted(LoginLogModel model)
        {
            return Json(model,JsonRequestBehavior.AllowGet);
        }
    }
}
