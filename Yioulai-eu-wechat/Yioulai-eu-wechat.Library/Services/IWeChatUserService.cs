using Yioulaieuwechat.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yioulaieuwechat.Library.Services
{
    public interface IWeChatUserService : IDisposable
    {
        void Insert(WeChatUser wechatuser);
        void Update();
        WeChatUser GetWeChatUser(Guid id);
        WeChatUser GetWeChatUser(string openId);
        IQueryable<WeChatUser> GetWeChatUsers();
    }
}
