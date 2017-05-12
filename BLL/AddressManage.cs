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
    public class AddressManage
    {
        public static IAddress addrse = DataAccess.Createaddre();
        public static void Addaddre(Address addre)
        {
            addrse.Addaddre(addre);
        }
        public static void update(Address addre)
        {
            addrse.update(addre);
        }
        public static IList<Address> seuseadd(int userid)
        {
            return addrse.seuseadd(userid);
        }
        public static Address selectaddid(int id)
        {
            return addrse.selectaddid(id);
        }
        public static void delete(int id)
        {
            addrse.delete(id);
        }
        public static Address selectaaduse(int userid)
        {
            return addrse.selectaaduse(userid);
        }
    }
}
