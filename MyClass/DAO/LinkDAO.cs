using MyClass.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClass.DAO
{
    public class LinkDAO
    {
        private MyDBContext db = new MyDBContext();
        public List<Link> getList()
        {
            return db.Links.ToList(); //chua co dieu kien
        }
        //tra ve 1 mau tin
        public Link getRow(int? id)
        {
            return db.Links.Find(id);
        }
        public Link getRow(string slug)
        {
            return db.Links.Where(m => m.Slug == slug).FirstOrDefault();
        }
       
        public Link getRow(int tableid, string type)
        {
            return db.Links.Where(m => m.TableId == tableid && m.Type == type).FirstOrDefault();
        }
        //so mau tin
        public int getCount()
        {
            return db.Categorys.Count();
        }
 
        public int Insert(Link row)
        {
            db.Links.Add(row);
            return db.SaveChanges();

        }
        //Cập nhật mẫu tin

        public int Update(Link row)
        {
            db.Entry(row).State = EntityState.Modified;
            return db.SaveChanges();

        }
        //Cập nhật mẫu tin

        public int Delete(Link row)
        {
            db.Links.Remove(row);
            return db.SaveChanges();

        }
    }
}
