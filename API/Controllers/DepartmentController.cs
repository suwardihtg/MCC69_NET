﻿using API.Models;
using API.Repositories.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : BaseController<DepartmentRepository, Departments, int>
    {
        public DepartmentController(DepartmentRepository departmentRepository) : base(departmentRepository)
        {

        }
    }
}
