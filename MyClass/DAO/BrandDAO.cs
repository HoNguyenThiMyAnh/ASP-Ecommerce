﻿using MyClass.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClass.DAO
{
    public class BrandDAO
    {
        private MyDBContext db = new MyDBContext();
        public List<Brand> getList(string status = "All")
        {
            List<Brand> list = null;
            switch (status)
            {
                case "Index":
                    {
                        list = db.Brands.Where(m => m.Status != 0).ToList();
                        break;
                    }
                case "Trash":
                    {
                        list = db.Brands.Where(m => m.Status == 0).ToList();
                        break;
                    }
                default:
                    {
                        list = db.Brands.ToList();
                        break;
                    }
            }
            return list;
        }

        public Brand getRow(int? id)
        {
            if (id == null)
            {
                return null;
            }
            else
            {
                return db.Brands.Find(id);

            }

        }

        public int Insert(Brand row)
        {
            db.Brands.Add(row);
            return db.SaveChanges();

        }
        //Cập nhật mẫu tin

        public int Update(Brand row)
        {
            db.Entry(row).State = EntityState.Modified;
            return db.SaveChanges();

        }
        //Cập nhật mẫu tin

        public int Delete (Brand row)
        {
            db.Brands.Remove(row);
            return db.SaveChanges();

        }

     

    }
}
