﻿using MCC69_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCC69_App.Repositories.Data
{
    public class CountryRepository : GeneralRepository<Countries>
    {
        public CountryRepository(string request = "Country/") : base(request)
        {
        }
    }
}
