using Yioulaieuwechat.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yioulaieuwechat.Library.Services
{
    public interface ILoginLogService : IDisposable
    {
        void Insert(LoginLog loginLog);
        void Update();
        LoginLog GetLoginLog(Guid id);
        LoginLog GetLoginLog(string state);
        IQueryable<LoginLog> GetLoginLogs();
    }
}
