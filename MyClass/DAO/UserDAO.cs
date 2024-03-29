using MyClass.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClass.DAO
{
   public class UserDAO
    {
        private MyDBContext db = new MyDBContext();


        public List<ModelUser> getList()
        {
            return db.Users.ToList();
        }
        public List<ModelUser> getList(string page = "All", string roles = null)
        {
            List<ModelUser> list = null;
            switch (page)
            {
                case "Index":
                    {
                        list = db.Users.Where(m => m.Status!= 0 && m.Roles == roles).ToList();
                        break;
                    }
                case "Trash":
                    {
                        list = db.Users.Where(m => m.Status != 0 && m.Roles == roles).ToList();
                        break;
                    }
                default:
                    {
                        list = db.Users.Where(m => m.Roles == roles).ToList();
                        break;
                    }
            }
            return list;
        }
        //Trả về 1 mẫu tin 
        public ModelUser getRow()
        {
                return db.Users.Find();
        }
        public ModelUser getRow(int? id)
        {
            return db.Users.Find(id);
        }
        public ModelUser getRow(string username, string roles)
        {

                return db.Users.Where(m => m.Status == 1 && m.Roles == roles && (m.UserName == username || m.Email == username)).FirstOrDefault();
        }
        //so mau tin
       
        //Thêm mẫu tin

        public int Insert(ModelUser row)
        {
            db.Users.Add(row);
            return db.SaveChanges();

        }
        //Cập nhật mẫu tin

        public int Update(ModelUser row)
        {
            db.Entry(row).State = EntityState.Modified;
            return db.SaveChanges();

        }
        //Cập nhật mẫu tin

        public int Delete(ModelUser row)
        {
            db.Users.Remove(row);
            return db.SaveChanges();

        }

    }
}
