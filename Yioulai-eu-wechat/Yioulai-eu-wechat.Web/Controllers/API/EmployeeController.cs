using AutoMapper;
using Yioulaieuwechat.Library.Models;
using Yioulaieuwechat.Library.Services;
using Yioulaieuwechat.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Yioulaieuwechat.Web.Controllers.API
{
    public class EmployeeController : BaseApiController
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        public object Get()
        {
            Mapper.Reset();
            Mapper.CreateMap<Employee, EmployeeModel>();
            return _employeeService.GetEmployees().Select(Mapper.Map<Employee, EmployeeModel>);
        }
    }
}
