using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yioulaieuwechat.Service
{
    public class BaseService
    {
        public readonly YioulaieuwechatDataContext DbContext;

        public BaseService(YioulaieuwechatDataContext dbContext)
        {
            DbContext = dbContext;
        }

        public void Dispose()
        {
            DbContext.Dispose();
        }
    }
}
