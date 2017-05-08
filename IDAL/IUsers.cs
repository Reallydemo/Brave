using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace IDAL
{
    public interface IUsers
    {
        IQueryable<Users> Findname(Users user);
        void Register(Users user);
        Users Login(Users user);

    }
}
