using MyClass.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClass.DAO
{
    public class OderDetailDAO
    {
        private MyDBContext db = new MyDBContext();

        public List<OrderDetail> getList(int? orderid)
        {
            return db.OrderDetails.Where(m => m.OrderId == orderid).ToList();
        }
        public List<OrderDetail> getList(string page = "All")
        {
            List<OrderDetail> list = db.OrderDetails.ToList();
            return list;
        }
        //trả về 1 mẫu tin
        public OrderDetail getRow(int? id)
        {
            return db.OrderDetails.Find(id);
        }
        public int getRow()
        {
            return db.OrderDetails.Count();
        }
        //Thêm mẫu tin 
        public int Insert(OrderDetail row)
        {
            db.OrderDetails.Add(row);
            return db.SaveChanges();
        }
        //Cập nhật  mẫu tin 
        public int Update(OrderDetail row)
        {
            db.Entry(row).State = EntityState.Modified;
            return db.SaveChanges();
        }
        //Cập nhật  mẫu tin 
        public int Delete(OrderDetail row)
        {
            db.OrderDetails.Remove(row);
            return db.SaveChanges();
        }

    }

}
