using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyClass.Models;
using MyClass.DAO;
using banquanao.Library;

namespace banquanao.Controllers
{
    public class KhachhangController : Controller
    {
        UserDAO userDAO = new UserDAO();
        // GET: Khachhang
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(FormCollection filed)
        {
            String username = filed["username"];
            String password = XString.ToMD5(filed["password"]);
            //

            ModelUser row_user = userDAO.getRow(username, "Customer");
            String strError = "";
            if(row_user==null)
            {
                strError = "Tên đăng nhập không tồn tại";
            }
            else
            {
                if(password.Equals(row_user.Password))
                {
                    Session["UserCustomer"] = username;
                    Session["CustomerId"] = row_user.Id;
                    return Redirect("~/");
                }
                else
                {

                    strError = password;
                }
            }    
            ViewBag.Error = "<span class='text-danger'>"+strError+"</div>";
            return View("DangNhap");
        }
        public ActionResult DangKy()
        {
            return View();
        }
    }
}