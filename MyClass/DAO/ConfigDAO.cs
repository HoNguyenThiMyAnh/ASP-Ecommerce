using MyClass.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClass.DAO
{
    public class ConfigDAO
    {
        private MyDBContext db = new MyDBContext();
        //Trả về danh sách các mẫu tin 
        public List<Config> getList(string status = "All")
        {
            List<Config> list = null;
            switch (status)
            {
                case "Index":
                    {
                        list = db.Configs.Where(m => m.Status != 0).ToList();
                        break;
                    }
                case "Trash":
                    {
                        list = db.Configs.Where(m => m.Status == 0).ToList();
                        break;
                    }
                default:
                    {
                        list = db.Configs.ToList();
                        break;
                    }
            }
            return list;
        }
        public int Insert(Config row)
        {
            db.Configs.Add(row);
            return db.SaveChanges();

        }
        //Cập nhật mẫu tin

        public int Update(Config row)
        {
            db.Entry(row).State = EntityState.Modified;
            return db.SaveChanges();

        }
        //Cập nhật mẫu tin

        public int Delete(Config row)
        {
            db.Configs.Remove(row);
            return db.SaveChanges();

        }
    }
}
