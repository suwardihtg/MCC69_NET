using API.Context;
using API.Models;
using API.Repositories.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/Location")]
    [ApiController]
    public class LocationController : BaseController<LocationRepository, Locations, int>
    {
        public LocationController(LocationRepository locationRepository) : base(locationRepository)
        {

        }

    }
}
