using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Models;
using IDAL;

namespace DAL
{
   public class SqlUsers:IUsers
    {
        BraveEntities db = new BraveEntities();
        public void Register(Users user)
        {
            var chk_member = db.Users.Where(o => o.UserName == user.UserName).FirstOrDefault();
            
            user.Addtime = DateTime.Now;
            db.Users.Add(user);
            db.SaveChanges();
        }
        public Users Login(Users user)
        {
           return db.Users.Where(o => o.UserName == user.UserName).Where(o => o.Password == user.Password).FirstOrDefault();
        
        }
        public Users Findname(Users user)
        {
          return db.Users.Where(o => o.UserName == user.UserName).FirstOrDefault();
          
        }
    }
}
