using System;
using System.Linq;
using Yioulaieuwechat.Library.Models;
using Yioulaieuwechat.Library.Services;

namespace Yioulaieuwechat.Service.Services
{
    public class EmployeeService : BaseService, IEmployeeService
    {
        public EmployeeService(YioulaieuwechatDataContext dbContext)
            : base(dbContext)
        {
        }

        public Employee GetEmployee(Guid id)
        {
            return DbContext.Employees.FirstOrDefault(n => n.Id == id);
        }

        public IQueryable<Employee> GetEmployees()
        {
            return DbContext.Employees;
        }

        public void Insert(Employee employee)
        {
            DbContext.Employees.Add(employee);
            DbContext.SaveChanges();
        }

        public void Update()
        {
            DbContext.SaveChanges();
        }
    }
}
