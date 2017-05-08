using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using IDAL;
using DAL;
using DALFactory;

namespace BLL
{
  public class UsersManage
    {
        public static IUsers usee = DataAccess.Createuse();
        public static void Register(Users user)
        {
            usee.Register(user);
        }
        public static Users Login(Users user)
        {
            return usee.Login(user);
        }
        public static IQueryable<Users> Findname(Users user)
        {
           return usee.Findname(user);
        }
    }
}
