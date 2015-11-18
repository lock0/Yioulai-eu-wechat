using System;
using System.Linq;
using Yioulaieuwechat.Library.Models;
using Yioulaieuwechat.Library.Services;

namespace Yioulaieuwechat.Service.Services
{
    public class WeChatUserService : BaseService, IWeChatUserService
    {
        public WeChatUserService(YioulaieuwechatDataContext dbContext)
            : base(dbContext)
        {
        }

        public WeChatUser GetWeChatUser(string openId)
        {
            return DbContext.WeChatUsers.FirstOrDefault(n => n.OpenId == openId);
        }

        public WeChatUser GetWeChatUser(Guid id)
        {
            return DbContext.WeChatUsers.FirstOrDefault(n => n.Id == id);
        }

        public IQueryable<WeChatUser> GetWeChatUsers()
        {
            return DbContext.WeChatUsers.Where(n=>!n.IsDeleted);
        }

        public void Insert(WeChatUser wechatuser)
        {
            DbContext.WeChatUsers.Add(wechatuser);
            DbContext.SaveChanges();
        }

        public void Update()
        {
            DbContext.SaveChanges();
        }
    }
}
