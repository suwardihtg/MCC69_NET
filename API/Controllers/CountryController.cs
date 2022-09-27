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
    [Route("api/Country")]
    [ApiController]
    public class CountryController : BaseController<CountryRepository, Countries, int>
    {
       

        public CountryController(CountryRepository countryRepository) : base(countryRepository)
        {
            
        }
        
    }
}
