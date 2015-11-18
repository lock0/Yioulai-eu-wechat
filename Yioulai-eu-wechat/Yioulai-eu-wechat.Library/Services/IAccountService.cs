using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yioulaieuwechat.Library.Models;

namespace Yioulaieuwechat.Library.Services
{
    public interface IAccountService : IDisposable
    {
        void Insert(Account account);
        void Update();
        void Delete(Guid id);
        Account GetAccount(Guid id);
        IQueryable<Account> GetAccounts();
    }
}
