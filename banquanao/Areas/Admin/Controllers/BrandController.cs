using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyClass.Models;
using MyClass.DAO;

using System.IO;
using banquanao.Library;

namespace banquanao.Areas.Admin.Controllers
{
    public class BrandController : Controller
    {
        BrandDAO brandDAO = new BrandDAO();
        LinkDAO linkDAO = new LinkDAO();


        public ActionResult Index()
        {
            return View(brandDAO.getList("Index"));
        }


        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Brand brand = brandDAO.getRow(id);
            if (brand == null)
            {
                return HttpNotFound();
            }
            return View(brand);
        }

        // GET: Admin/Brand/Create
        public ActionResult Create()
        {
            ViewBag.ListOrder = new SelectList(brandDAO.getList("Index"), "Orders", "Name", 0);
            return View();
        }

        // POST: Admin/Brand/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Brand brand)
        {
            if (ModelState.IsValid)
            {
                //xử lý thêm thông tin
                brand.Slug = XString.Str_Slug(brand.Name);
              
                if (brand.Orders == null)
                {
                    brand.Orders = 1;
                }
                else
                {
                    brand.Orders += 1;
                }
                //upload hinh
                var img = Request.Files["img"];// lay ntgh otin file
                if (img.ContentLength != 0)
                {
                    string[] FileExtentions = new string[] { ".jpg", ".jepg", ".png", ".gif" };
                    if (FileExtentions.Contains(img.FileName.Substring(img.FileName.LastIndexOf("."))))
                    {

                        string imgName = brand.Slug + img.FileName.Substring(img.FileName.LastIndexOf("."));
                        brand.Img = imgName;
                        string PathDir = "~/Public/images/brands/";
                        string PathFile = Path.Combine(Server.MapPath(PathDir), imgName);
                        img.SaveAs(PathFile);

                    }
                }
                //end upload flie

                brand.CreatedBy = Convert.ToInt32(Session["UserId"].ToString());
                brand.Created_At = DateTime.Now;
                brand.UpdatedAt = DateTime.Now;
                brand.UpdatedBy = 1;
                if (brandDAO.Insert(brand) == 1)
                {
                    Link link = new Link();
                    link.Slug = brand.Slug;
                    link.TableId = brand.Id;
                    link.Type = "Brand";
                    linkDAO.Insert(link);
                }

                TempData["message"] = new XMessage("success", "Thêm Thành Công");
                return RedirectToAction("Index", "Brand");
            }
            ViewBag.ListOrder = new SelectList(brandDAO.getList("Index"), "Orders", "Name", 0);
            return View(brand);
        }

        // GET: Admin/Brand/Edit/5
        public ActionResult Edit(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Brand brand = brandDAO.getRow(id);
            if (brand == null)
            {
                return HttpNotFound();
            }

            return View(brand);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Brand brand)
        {
            if (ModelState.IsValid)
            {
                brand.Slug = XString.Str_Slug(brand.Name);
               
                if (brand.Orders == null)
                {
                    brand.Orders = 1;
                }
                else
                {
                    brand.Orders += 1;

                }
                //upload hinh
                var img = Request.Files["img"];// lay ntgh otin file
                //kiemtra tap tin
                if (img.ContentLength != 0)
                {
                    string[] FileExtentions = new string[] { ".jpg", ".jepg", ".png", ".gif" };
                    if (FileExtentions.Contains(img.FileName.Substring(img.FileName.LastIndexOf("."))))
                    {

                        string imgName = brand.Slug + img.FileName.Substring(img.FileName.LastIndexOf("."));
                        brand.Img = imgName;
                        string PathDir = "~/Public/images/brands/";
                        string PathFile = Path.Combine(Server.MapPath(PathDir), imgName);
                        //xoafile
                        if(brand.Img.Length>0)
                        {
                            string DelPath = Path.Combine(Server.MapPath(PathDir), brand.Img);
                            System.IO.File.Delete(DelPath);
                        }
                        img.SaveAs(PathFile);

                    }
                }
                //end upload flie
                brand.UpdatedBy = Convert.ToInt32(Session["UserId"].ToString());
                brand.UpdatedAt = DateTime.Now;
                if (brandDAO.Update(brand) == 1)
                {
                    Link link = linkDAO.getRow(brand.Id, "Brand");
                    link.Slug = brand.Slug;
                    linkDAO.Update(link);
                }
                TempData["message"] = new XMessage("success", "Cập nhật thành công");
                return RedirectToAction("Index");
            }
            ViewBag.ListOrder = new SelectList(brandDAO.getList("Index"), "Orders", "Name", 0);
            return View(brand);
        }

        // GET: Admin/Brand/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Brand brand = brandDAO.getRow(id);
            if (brand == null)
            {
                return HttpNotFound();
            }
            ViewBag.ListOrder = new SelectList(brandDAO.getList("Index"), "Orders", "Name", 0);
            return View(brand);
        }

        // POST: Admin/Brand/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Brand brand = brandDAO.getRow(id);
            Link link = linkDAO.getRow(brand.Id, "Brand");
            string PathDir = "~/Public/images/brands/";
            //xoa hinha nhh
        
            if (brand.Img != null)
            {
                string DelPath = Path.Combine(Server.MapPath(PathDir), brand.Img);
                System.IO.File.Delete(DelPath);
            }
            if (brandDAO.Delete(brand) == 1)
            {

                linkDAO.Delete(link);

            }

            TempData["message"] = new XMessage("success", "Xóa mẫu tin thành công");
            return RedirectToAction("Trash", "Brand");
        }
        public ActionResult Trash()
        {
            return View(brandDAO.getList("Trash"));

        }
        public ActionResult Status(int? id)
        {
            if (id == null)
            {
                TempData["message"] = new XMessage("danger", "Mã loại sản phẩm không tồn tại");
                return RedirectToAction("Index", "Brand");
            }
            Brand brand = brandDAO.getRow(id);
            if (brand == null)
            {
                TempData["message"] = new XMessage("danger", "Mẫu tin không tồn tại");
                return RedirectToAction("Index", "Brand");
            }
            brand.Status = (brand.Status == 1) ? 2 : 1;
            brand.UpdatedBy = Convert.ToInt32(Session["UserId"].ToString());
            brand.UpdatedAt = DateTime.Now;
            brandDAO.Update(brand);
            TempData["message"] = new XMessage("success", "Thay đổi trạng thái thành công");
            return RedirectToAction("Index", "Brand");

        }
        public ActionResult DelTrash(int? id)
        {
            if (id == null)
            {
                TempData["message"] = new XMessage("danger", "Mã loại sản phẩm không tồn tại");
                return RedirectToAction("Index", "Brand");
            }
            Brand brand = brandDAO.getRow(id);
            if (brand == null)
            {
                TempData["message"] = new XMessage("danger", "Mẫu tin không tồn tại");
                return RedirectToAction("Index", "Brand");
            }
            brand.Status = 0;// trạng thái rac =0 
            brand.UpdatedBy = Convert.ToInt32(Session["UserId"].ToString());
            brand.UpdatedAt = DateTime.Now;
            brandDAO.Update(brand);
            TempData["message"] = new XMessage("success", "Xóa vào thùng rác thành công");
            return RedirectToAction("Index", "Brand");
        }

        public ActionResult Retrash(int? id)
        {
            if (id == null)
            {
                TempData["message"] = new XMessage("danger", "Mã loại sản phẩm không tồn tại");
                return RedirectToAction("Trash", "Brand");
            }
            Brand brand = brandDAO.getRow(id);
            if (brand == null)
            {
                TempData["message"] = new XMessage("danger", "Mẫu tin không tồn tại");
                return RedirectToAction("Trash", "Brand");
            }
            brand.Status = 2;// trạng thái rac =0 
            brand.UpdatedBy = Convert.ToInt32(Session["UserId"].ToString());
            brand.UpdatedAt = DateTime.Now;
            brandDAO.Update(brand);
            TempData["message"] = new XMessage("success", "Xóa vào thùng rác thành công");
            return RedirectToAction("Trash", "Brand");
        }
    }
}
