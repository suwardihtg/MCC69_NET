using API.Context;
using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories.Data
{
    public class JobRepository : GeneralRepository<Jobs, int>
    {
        public JobRepository(MyContext myContext) : base(myContext)
        {

        }
    }
}
