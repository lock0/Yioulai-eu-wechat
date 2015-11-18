using System;
using System.Linq;
using Yioulaieuwechat.Library.Models;
using Yioulaieuwechat.Library.Services;

namespace Yioulaieuwechat.Service.Services
{
    public class AccountService : BaseService, IAccountService
    {
        public AccountService(YioulaieuwechatDataContext dbContext)
            : base(dbContext)
        {
        }

        public void Insert(Account account)
        {
            this.DbContext.Accounts.Add(account);
            this.DbContext.SaveChanges();
        }

        public void Update()
        {
            this.DbContext.SaveChanges();
        }
        public Account GetAccount(Guid id)
        {
            return this.DbContext.Accounts.FirstOrDefault(u => u.Id == id);
        }

        public IQueryable<Account> GetAccounts()
        {
            return this.DbContext.Accounts.Where(n=>!n.IsDeleted);
        }

        public void Delete(Guid id)
        {
            var account = DbContext.Accounts.FirstOrDefault(n => n.Id == id);
            DbContext.Accounts.Remove(account);
            Update();
        }

    }
}
