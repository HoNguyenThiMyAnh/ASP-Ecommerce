using MyClass.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClass.DAO
{
    public class SliderDAO
    {
        private MyDBContext db = new MyDBContext();
        //tra ve danh sach overri...
        public List<Slider> getListByPosition(string position )
        {
             return db.Sliders.Where(m=>m.Position== position && m.Status==1).OrderBy(m=>m.Orders).ToList();
        }
        public List<Slider> getList(string status = "All")
        {
            List<Slider> list = null;
            switch (status)
            {
                case "Index":
                    {
                        list = db.Sliders.Where(m => m.Status != 0).ToList();
                        break;
                    }
                case "Trash":
                    {
                        list = db.Sliders.Where(m => m.Status == 0).ToList();
                        break;
                    }
                default:
                    {
                        list = db.Sliders.ToList();
                        break;
                    }
            }
            return list;
        }
        public int Insert(Slider entity)
        {
            db.Sliders.Add(entity);
            return db.SaveChanges();

        }
        //Cập nhật mẫu tin

        public int Update(Slider entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            return db.SaveChanges();

        }
        //Cập nhật mẫu tin

        public int Delete(Slider entity)
        {
            db.Sliders.Remove(entity);
            return db.SaveChanges();

        }
    }
}
