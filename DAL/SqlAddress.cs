using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using IDAL;

namespace DAL
{
   public class SqlAddress:IAddress
    {
        BraveEntities db = new BraveEntities();
        public void Addaddre(Address addre)
        {
            addre.AddressTime = DateTime.Now;
            db.Address.Add(addre);
            db.SaveChanges();
        }
        public void update(Address addre)
        {
            db.Entry<Address>(addre).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
        public IList<Address> seuseadd(int userid)
        {
            
            return db.Address.Where(p => p.User_id == userid).ToList();
        }
        public Address selectaddid(int id)
        {
            return db.Address.Single(p => p.Address_id == id);
        }
        public void delete(int id)
        {
            Address addre = db.Address.Single(l => l.Address_id == id);
            db.Address.Remove(addre);
            db.SaveChanges();
        }
        public Address selectaaduse(int userid)
        {
            return db.Address.Where(p => p.User_id == userid).Where(p => p.flat == true).FirstOrDefault();
        }
    }
}
