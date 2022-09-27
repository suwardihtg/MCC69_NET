using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories.Interface
{
    public interface ILocation
    {
        List<Locations> Get();
        Locations GetDetail(int id);
        int Post(Locations locations);
        int Put(int id, Locations locations);
        int Delete(int id);


    }
}
