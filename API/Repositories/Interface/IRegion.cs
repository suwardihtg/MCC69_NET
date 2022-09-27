using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories.Interface
{
    public interface IRegion
    {
        // Return untuk Get ALL
        List<Regions> Get();

        //return get id
        Regions GetDetail(int id);

        //return post
        int Create(Regions region);

        //return Edit
        int Edit(int id, Regions region);

        //return delelete
        int Delete(int id);


    }
}
