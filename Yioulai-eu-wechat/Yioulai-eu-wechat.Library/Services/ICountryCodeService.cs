﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yioulaieuwechat.Library.Models;

namespace Yioulaieuwechat.Library.Services
{
    public interface ICountryCodeService : IDisposable
    {

        CountryCode GetCountryCode(string Name);
       
    }
}
