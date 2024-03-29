using MyClass.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;


namespace MyClass.DAO
{
    public class ProductDAO
    {
        private MyDBContext db = new MyDBContext();

        public List<Product> SearchByKey(string key)
        {
            return db.Products.SqlQuery("Select * from Products where Name like '%" + key + "%'").ToList();
        }
        public List<ProductInfo> getListByListCatId(List<int> listcatid, int take)
        {
            List<ProductInfo> list = db.Products
                .Join(
                    db.Categorys,
                    p => p.CatId,
                    c => c.Id,
                    (p, c) => new ProductInfo
                    {
                        Id = p.Id,
                        CatId = p.CatId,
                        SupplierId = p.SupplierId,
                        Name = p.Name,
                        CatName = c.Name,
                        Slug = p.Slug,
                        Img = p.Img,
                        PriceBuy = p.PriceBuy,
                        PriceSell = p.PriceSell,
                        Detail = p.Detail,
                        Number = p.Number,
                        MetaDesc = p.MetaDesc,
                        Metakey = p.Metakey,
                        CreatedBy = p.CreatedBy,
                        Created_At = p.Created_At,
                        UpdatedAt = p.UpdatedAt,
                        UpdatedBy = p.UpdatedBy,
                        Status = p.Status,
                    }

                )
                .Where(m => m.Status == 1 && listcatid.Contains(m.CatId))
                .OrderByDescending(m => m.Created_At)
                .Take(take)
                .ToList();
            return list;
        }
        public IPagedList<ProductInfo> getListByListCatId(List<int> listcatid, int pageSize, int pageNummber)
        {
            IPagedList
                <ProductInfo> list = db.Products
                .Join(
                    db.Categorys,
                    p => p.CatId,
                    c => c.Id,
                    (p, c) => new ProductInfo
                    {
                        Id = p.Id,
                        CatId = p.CatId,
                        SupplierId = p.SupplierId,
                        Name = p.Name,
                        CatName = c.Name,
                        Slug = p.Slug,
                        Img = p.Img,
                        PriceBuy = p.PriceBuy,
                        PriceSell = p.PriceSell,
                        Detail = p.Detail,
                        Number = p.Number,
                        MetaDesc = p.MetaDesc,
                        Metakey = p.Metakey,
                        CreatedBy = p.CreatedBy,
                        Created_At = p.Created_At,
                        UpdatedAt = p.UpdatedAt,
                        UpdatedBy = p.UpdatedBy,
                        Status = p.Status,
                    }

                )
                .Where(m => m.Status == 1 && listcatid.Contains(m.CatId))
                .OrderByDescending(m => m.Created_At)
                               .ToPagedList(pageNummber, pageSize);

            return list;
        }
        public List<ProductInfo> getListByListCatId(int take)
        {
            List<ProductInfo> list = db.Products
                .Join(
                    db.Categorys,
                    p => p.CatId,
                    c => c.Id,
                    (p, c) => new ProductInfo
                    {
                        Id = p.Id,
                        CatId = p.CatId,
                        SupplierId = p.SupplierId,
                        Name = p.Name,
                        CatName = c.Name,
                        Slug = p.Slug,
                        Img = p.Img,
                        PriceBuy = p.PriceBuy,
                        PriceSell = p.PriceSell,
                        Detail = p.Detail,
                        Number = p.Number,
                        MetaDesc = p.MetaDesc,
                        Metakey = p.Metakey,
                        CreatedBy = p.CreatedBy,
                        Created_At = p.Created_At,
                        UpdatedAt = p.UpdatedAt,
                        UpdatedBy = p.UpdatedBy,
                        Status = p.Status,
                    }

                )
                .Where(m => m.Status == 1)
                .OrderByDescending(m => m.Created_At)
                .Take(take)
                .ToList();
            return list;
        }
        public IPagedList<ProductInfo> getList(int pageSize, int pageNummber)
            //phan trang
        {
            IPagedList<ProductInfo> list = db.Products
                .Join(
                    db.Categorys,
                    p => p.CatId,
                    c => c.Id,
                    (p, c) => new ProductInfo
                    {
                        Id = p.Id,
                        CatId = p.CatId,
                        SupplierId = p.SupplierId,
                        Name = p.Name,
                        CatName = c.Name,
                        Slug = p.Slug,
                        Img = p.Img,
                        PriceBuy = p.PriceBuy,
                        PriceSell = p.PriceSell,
                        Detail = p.Detail,
                        Number = p.Number,
                        MetaDesc = p.MetaDesc,
                        Metakey = p.Metakey,
                        CreatedBy = p.CreatedBy,
                        Created_At = p.Created_At,
                        UpdatedAt = p.UpdatedAt,
                        UpdatedBy = p.UpdatedBy,
                        Status = p.Status,
                    }

                )
                .Where(m => m.Status == 1)
                .OrderByDescending(m => m.Created_At)
                .ToPagedList(pageNummber, pageSize);
            return list;
        }
         public List<ProductInfo> getList(List<int> listcatid, int limit)
        {
            List<ProductInfo> list = db.Products
                .Join(
                    db.Categorys,
                    p => p.CatId,
                    c => c.Id,
                    (p, c) => new ProductInfo
                    {
                        Id = p.Id,
                        CatId = p.CatId,
                        SupplierId = p.SupplierId,
                        Name = p.Name,
                        CatName = c.Name,
                        Slug = p.Slug,
                        Img = p.Img,
                        PriceBuy = p.PriceBuy,
                        PriceSell = p.PriceSell,
                        Detail = p.Detail,
                        Number = p.Number,
                        MetaDesc = p.MetaDesc,
                        Metakey = p.Metakey,
                        CreatedBy = p.CreatedBy,
                        Created_At = p.Created_At,
                        UpdatedAt = p.UpdatedAt,
                        UpdatedBy = p.UpdatedBy,
                        Status = p.Status,
                    }

                )
                .Where(m => m.Status == 1)
                .OrderByDescending(m => m.Created_At)
                .Take(limit)
                .ToList();
            return list;
        }


        public List<ProductInfo> getList(List<int> listcatid, int limit,int notid,bool check=true)
        {
            List<ProductInfo> list = db.Products
                .Join(
                    db.Categorys,
                    p => p.CatId,
                    c => c.Id,
                    (p, c) => new ProductInfo
                    {
                        Id = p.Id,
                        CatId = p.CatId,
                        SupplierId = p.SupplierId,
                        Name = p.Name,
                        CatName = c.Name,
                        Slug = p.Slug,
                        Img = p.Img,
                        PriceBuy = p.PriceBuy,
                        PriceSell = p.PriceSell,
                        Detail = p.Detail,
                        Number = p.Number,
                        MetaDesc = p.MetaDesc,
                        Metakey = p.Metakey,
                        CreatedBy = p.CreatedBy,
                        Created_At = p.Created_At,
                        UpdatedAt = p.UpdatedAt,
                        UpdatedBy = p.UpdatedBy,
                        Status = p.Status,
                    }

                )
                .Where(m => m.Status == 1 && m.Id!=notid && listcatid.Contains(m.CatId))
                .OrderByDescending(m => m.Created_At)
                .Take(limit)
                .ToList();
            return list;
        }


        public List<ProductInfo> getList(string page = "All")
        {
            List<ProductInfo> list = null;
            switch (page)
            {
                case "Index":
                    {
                        list = db.Products
                            .Join(
                    db.Categorys,
                    p => p.CatId,
                    c => c.Id,
                    (p, c) => new ProductInfo
                    {
                        Id = p.Id,
                        CatId = p.CatId,
                        SupplierId = p.SupplierId,
                        Name = p.Name,
                        CatName = c.Name,
                        Slug = p.Slug,
                        Img = p.Img,
                        PriceBuy = p.PriceBuy,
                        PriceSell = p.PriceSell,
                        Detail = p.Detail,
                        Number = p.Number,
                        MetaDesc = p.MetaDesc,
                        Metakey = p.Metakey,
                        CreatedBy = p.CreatedBy,
                        Created_At = p.Created_At,
                        UpdatedAt = p.UpdatedAt,
                        UpdatedBy = p.UpdatedBy,
                        Status = p.Status,
                    }
                )
                            .Where(m => m.Status != 0).ToList();
                        break;
                    }
                case "Trash":
                    {
                        list = db.Products
                            .Join(
                    db.Categorys,
                    p => p.CatId,
                    c => c.Id,
                    (p, c) => new ProductInfo
                    {
                        Id = p.Id,
                        CatId = p.CatId,
                        SupplierId = p.SupplierId,
                        Name = p.Name,
                        CatName = c.Name,
                        Slug = p.Slug,
                        Img = p.Img,
                        PriceBuy = p.PriceBuy,
                        PriceSell = p.PriceSell,
                        Detail = p.Detail,
                        Number = p.Number,
                        MetaDesc = p.MetaDesc,
                        Metakey = p.Metakey,
                        CreatedBy = p.CreatedBy,
                        Created_At = p.Created_At,
                        UpdatedAt = p.UpdatedAt,
                        UpdatedBy = p.UpdatedBy,
                        Status = p.Status,
                    }
                    )
                            .Where(m => m.Status == 0).ToList();
                        break;
                    }
                default:
                    {
                        list = db.Products
                              .Join(
                    db.Categorys,
                    p => p.CatId,
                    c => c.Id,
                    (p, c) => new ProductInfo
                    {
                        Id = p.Id,
                        CatId = p.CatId,
                        SupplierId = p.SupplierId,
                        Name = p.Name,
                        CatName = c.Name,
                        Slug = p.Slug,
                        Img = p.Img,
                        PriceBuy = p.PriceBuy,
                        PriceSell = p.PriceSell,
                        Detail = p.Detail,
                        Number = p.Number,
                        MetaDesc = p.MetaDesc,
                        Metakey = p.Metakey,
                        CreatedBy = p.CreatedBy,
                        Created_At = p.Created_At,
                        UpdatedAt = p.UpdatedAt,
                        UpdatedBy = p.UpdatedBy,
                        Status = p.Status,
                    }
                    )
                            .ToList();
                        break;
                    }
            }
            return list;
        }
        //tra ve 1 mau  tin
        public Product getRow(string slug)
        {
            return db.Products.Where(m => m.Slug == slug && m.Status == 1).FirstOrDefault();
        }
        public Product getRow(int? id)
        {


                return db.Products.Find(id);


        }


        //so mau tin
        public int getCount()
        {
            return db.Products.Count();
        }
        public int Insert(Product entity)
        {
            db.Products.Add(entity);
            return db.SaveChanges();

        }
        //Cập nhật mẫu tin

        public int Update(Product entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            return db.SaveChanges();

        }
        //Cập nhật mẫu tin

        public int Delete(Product row)
        {
            db.Products.Remove(row);
            return db.SaveChanges();

        }


    }
}
