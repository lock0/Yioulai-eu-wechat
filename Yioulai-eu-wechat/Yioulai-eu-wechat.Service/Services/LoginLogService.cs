using System;
using System.Linq;
using Yioulaieuwechat.Library.Models;
using Yioulaieuwechat.Library.Services;

namespace Yioulaieuwechat.Service.Services
{
    public class LoginLogService : BaseService, ILoginLogService
    {
        public LoginLogService(YioulaieuwechatDataContext dbContext)
            : base(dbContext)
        {
        }
        public LoginLog GetLoginLog(string state)
        {
            return DbContext.LoginLogs.FirstOrDefault(n => n.State == state);
        }

        public LoginLog GetLoginLog(Guid id)
        {
            return DbContext.LoginLogs.FirstOrDefault(n => n.Id == id);
        }

        public IQueryable<LoginLog> GetLoginLogs()
        {
            return DbContext.LoginLogs;
        }

        public void Insert(LoginLog loginLog)
        {
            DbContext.LoginLogs.Add(loginLog);
            DbContext.SaveChanges();
        }

        public void Update()
        {
            DbContext.SaveChanges();
        }
    }
}
