using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace IDAL
{
    public interface IAddress
    {
        void Addaddre(Address addre);
        IList<Address> seuseadd(int userid);
        void update(Address addre);
        Address selectaddid(int id);
        void delete(int id);
        Address selectaaduse(int userid);
    }
}
