﻿using API.Context;
using API.Models;
using API.Repositories.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/Region")]
    [ApiController]
   // [Authorize]
    public class RegionController : BaseController<RegionRepository, Regions, int>
    {
        
       public RegionController(RegionRepository regionRepository) : base(regionRepository)
        {
            
        }
    }
}
