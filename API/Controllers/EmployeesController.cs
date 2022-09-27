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
    [Route("api/Employees")]
    [ApiController]
    public class EmployeesController : BaseController<EmployessRepository, Employees, int>
    {
        public EmployeesController(EmployessRepository employessRepository) : base(employessRepository)
        {

        }

        
    }
}
