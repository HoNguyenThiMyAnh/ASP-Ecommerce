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
    public class OrderController : Controller
    {
        private OrderDAO orderDAO = new OrderDAO();
        private OderDetailDAO orderDetailDAO = new OderDetailDAO();
        // GET: Admin/Order
        public ActionResult Index()
        {
            List<Order> list = orderDAO.getList("index");
            return View(list);

        }
        //GET:Admin/Order/Details
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = orderDAO.getRow(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            ViewBag.ListChiTiet = orderDetailDAO.getList(id);
            return View(order);
        }
        public ActionResult Status(int? id)
        {
            Order order = orderDAO.getRow(id);
            if (order == null)
            {
                TempData["mesage"] = new XMessage("danger", "Mẫu tin không tồn tại");
                return RedirectToAction("Index");
            }
            order.Status = (order.Status == 1) ? 2 : 1;
            orderDAO.Update(order);
            TempData["mesage"] = new XMessage("danger", "Thay đổi trạng thái thành công");
            return RedirectToAction("Index");
        }
        public ActionResult DelTrash(int? id)
        {
            Order order = orderDAO.getRow(id);
            order.Status = 0;
            orderDAO.Update(order);
            return RedirectToAction("Index");
        }
        public ActionResult Trash()
        {

            return View(orderDAO.getList("Trash"));
        }
        public ActionResult ReTrash(int? id)
        {
            Order order = orderDAO.getRow(id);
            if (order == null)
            {
                TempData["mesage"] = new XMessage("danger", "Mẫu tin không tồn tại");
                return RedirectToAction("Index");
            }
            order.Status = 2;
            orderDAO.Update(order);
            return RedirectToAction("Trash");
        }
        public ActionResult Destroy(int? id)
        {
            Order order = orderDAO.getRow(id);
            if (order == null)
            {
                TempData["mesage"] = new XMessage("danger", "Mẫu tin không tồn tại");
                return RedirectToAction("Index");
            }
            if (order.Status == 1 || order.Status == 2)
            {
                order.Status = 0;
                order.UpdatedAt = DateTime.Now;
                order.UpdatedBy = 1;
            }
            else
            {
                if (order.Status == 3)
                {
                    TempData["message"] = new XMessage("sucess", "Đơn hàng không thể hủy");
                }
                if (order.Status == 4)
                {
                    TempData["message"] = new XMessage("danger", "Đơn hàng đang giao không thể hủy");
                }

                return RedirectToAction("Index");
            }
            orderDAO.Update(order);
            TempData["message"] = new XMessage("success", "Đã hủy thành công");
            return RedirectToAction("Index");
        }

    }
}