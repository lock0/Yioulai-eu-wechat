using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yioulaieuwechat.Library.Models;

namespace Yioulaieuwechat.Library.Services
{
    public interface IEmployeeService : IDisposable
    {
        void Insert(Employee employee);
        void Update();
        Employee GetEmployee(Guid id);
        IQueryable<Employee> GetEmployees();
    }
}
