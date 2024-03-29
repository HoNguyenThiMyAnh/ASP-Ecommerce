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

namespace banquanao.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        private UserDAO userDAO = new UserDAO();

        // GET: Admin/User
        public ActionResult Index()
        {
            return View();
        }

        // GET: Admin/User/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModelUser user = userDAO.getRow(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Admin/User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/User/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Email,Phone,UserName,Password,Img,CreatedBy,Created_At,UpdatedBy,UpdatedAt,Status")] ModelUser user)
        {
            if (ModelState.IsValid)
            {
                
                return RedirectToAction("");
            }

            return View(user);
        }

        // GET: Admin/User/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModelUser user = userDAO.getRow(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Admin/User/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Email,Phone,UserName,Password,Img,CreatedBy,Created_At,UpdatedBy,UpdatedAt,Status")] ModelUser user)
        {
            if (ModelState.IsValid)
            {
                
                return RedirectToAction("");
            }
            return View(user);
        }

        // GET: Admin/User/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModelUser user = userDAO.getRow(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Admin/User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ModelUser user = userDAO.getRow(id);

            return RedirectToAction("Index");
        }

        public ActionResult Trash()
        {
            return View(userDAO.getList("Trash"));
        }
        public ActionResult Retrash(int? id)
        {
            ModelUser user = userDAO.getRow(id);
            if (user == null)
            {
                TempData["message"] = new XMessage("danger", "Mẫu tin không tồn tại");
                return RedirectToAction("Index");
            }
            user.Status = 2;
            userDAO.Update(user);
            return RedirectToAction("Trash");
        }
        public String NameCustomer(int userid)
        {
            ModelUser user = userDAO.getRow(userid);
            if (user == null)
            {
                return "";
            }
            else
            {
                return user.FullName;
            }
        }
    }
}

