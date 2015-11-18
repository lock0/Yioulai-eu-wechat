using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yioulaieuwechat.Library.Models;

namespace Yioulaieuwechat.Library.Services
{
    public interface IDataContext : IObjectContextAdapter, IDisposable
    {
        IDbSet<Account> Accounts { get; set; }
        IDbSet<Company> Companies { get; set; }
        IDbSet<CardDemo> CardDemos { get; set; }
        IDbSet<Employee> Employees { get; set; }
        IDbSet<CardType> CardTypes { get; set; }
        IDbSet<LoginLog> LoginLogs { get; set; }
        IDbSet<WeChatUser> WeChatUsers { get; set; }
        int SaveChanges();
        IDbSet<TEntity> Set<TEntity>() where TEntity : class;
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}
