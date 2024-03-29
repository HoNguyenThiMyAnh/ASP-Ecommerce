using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using MyClass.Models;

namespace MyClass.DAO
{
    public class CategoryDAO
    {
        private MyDBContext db = new MyDBContext();
        //Trả về danh sách các mẫu tin 
  
        public List<Category> getListByParentId(int parentid)
        {
            List<Category> list= db.Categorys.Where(m=>m.ParentId==parentid && m.Status==1)
                .OrderBy(m=>m.Orders)
                .ToList();
            return list;
        }
        public List<Category> getList(string page = "All")
        {
            List<Category> list = null;
            switch (page)
            {
                case "Index":
                    {
                        list = db.Categorys.Where(m => m.Status != 0).ToList();
                        break;
                    }
                case "Trash":
                    {
                        list = db.Categorys.Where(m => m.Status == 0).ToList();
                        break;
                    }
                default:
                    {
                        list = db.Categorys.ToList();
                        break;
                    }
            }
            return list;
        }
        //Trả về 1 mẫu tin 
        public Category getRow(int? id)
        {
           if (id == null)
            {
                return null;
            }
           else
            {

                return db.Categorys.Find(id);
            }

        }
        public Category getRow(string  slug)
        {
           
                return db.Categorys.Where(m=>m.Slug == slug && m.Status==1).FirstOrDefault();

            
        }
        //Thêm mẫu tin

        public int Insert(Category row)
        {
            db.Categorys.Add(row);
            return db.SaveChanges();

        }
        //Cập nhật mẫu tin

        public int Update(Category row)
        {
            db.Entry(row).State = EntityState.Modified;
            return db.SaveChanges();

        }
        //Cập nhật mẫu tin

        public int Delete(Category row)
        {
            db.Categorys.Remove(row);
            return db.SaveChanges();

        }
        public List<int> getListId(int parentid)
        {
            List<int> listcatid = new List<int>();
            List<Category> listcategory1 = this.getList(parentid);
            if (listcategory1.Count > 0)
            {
                {
                    foreach (var cat1 in listcategory1)
                    {
                        listcatid.Add(cat1.Id);
                        List<Category> listcategory2 = this.getList(cat1.Id);
                        if (listcategory2.Count > 0)
                        {
                            foreach (var cat2 in listcategory2)
                            {
                                listcatid.Add(cat2.Id);
                                List<Category> listcategory3 = this.getList(cat2.Id);
                                if (listcategory3.Count > 0)
                                {
                                    foreach (var cat3 in listcategory3)
                                    {
                                        listcatid.Add(cat3.Id);
                                    }
                                }
                            }
                        }
                    }
                }

            }
            listcatid.Add(parentid);
            return listcatid;
        }

        private List<Category> getList(int parentid)
        {
            return db.Categorys.ToList();
        }
    }
}



