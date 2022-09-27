using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories.Interface
{
    public interface IUser
    {
        List<User> Get();
        User GetDetail(int id);
        int Post(User user);
        int Put(int id, User user);
        int Delete(int id);
    }
}
