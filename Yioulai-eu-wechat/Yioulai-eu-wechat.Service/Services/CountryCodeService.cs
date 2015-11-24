using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yioulaieuwechat.Library.Models;
using Yioulaieuwechat.Library.Services;

namespace Yioulaieuwechat.Service.Services
{
    public class CountryCodeService : BaseService, ICountryCodeService
    {
        public CountryCodeService(YioulaieuwechatDataContext dbContext)
            : base(dbContext)
        {
        }
        

        public CountryCode GetCountryCode(string Name)
        {
            return DbContext.CountryCodes.FirstOrDefault(n => n.Name == Name);
        }
    }
}
