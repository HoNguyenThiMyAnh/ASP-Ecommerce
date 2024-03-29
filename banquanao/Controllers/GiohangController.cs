using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyClass.DAO;
using MyClass.Models;

namespace banquanao.Controllers
{
    public class GiohangController : Controller
    {
        ProductDAO productDAO = new ProductDAO();
        UserDAO userDAO = new UserDAO();
       OrderDAO orderDAO = new OrderDAO();
        OderDetailDAO oderDetailDAO = new OderDetailDAO();
        XCart xcart = new XCart();
        // GET: Cart
        public ActionResult Index()
        {
            List<CartItem> listcart = xcart.getCart();
            return View("Index", listcart);
        }
        public ActionResult CartAdd( int productid)
        {
            Product product = productDAO.getRow(productid); //chi tiet san pham
            CartItem cartitem = new CartItem(product.Id, product.Name, product.Img, product.PriceBuy,1);
            List<CartItem> listcart = xcart.AddCart(cartitem);
            return RedirectToAction("Index", "Giohang");
        }
        public ActionResult CartDel(int productid)
        {
            xcart.DelCart(productid);
            return RedirectToAction("Index", "Giohang");
        }
        //CartUpdate
        public ActionResult CartUpdate(FormCollection form)
        {
            if (!string.IsNullOrEmpty(form["CAPNHAT"]))
            {
                var listqty = form["qty"]; //3,6
                var listarr = listqty.Split('.'); //3,6
                xcart.UpdateCart(listarr);

            }
            return RedirectToAction("Index", "Giohang");

        }
        public ActionResult CartDelAll()
        {
            xcart.DelCart();
            return RedirectToAction("Index", "Giohang");

        }

        //thanh toan
        public ActionResult ThanhToan()
        {
            
            List<CartItem> listcart = xcart.getCart();
            //kiem tra dang nhap trang nguoi dung ==> khach hang 
            if (Session["UserCustomer"].Equals(""))
            {
                return Redirect("~/dang-nhap"); // chuyen huong den URL

            }
            int userid = int.Parse(Session["CustomerId"].ToString()); // ma nguoi dang nhap 
            ModelUser user = userDAO.getRow(userid);
            ViewBag.user = user;
            return View("ThanhToan", listcart);

        }

        public ActionResult DatMua(FormCollection field)
        {
            //luu thong tin vao csdl order va orderdetail
            int userid = int.Parse(Session["CustomerId"].ToString()); 
            ModelUser user = userDAO.getRow(userid);
            //lay thong tin
            String note = field["Note"];
            String receiverName = field["ReceiverName"];
            String receiverEmail = field["ReceiverEmail"];
            String receiverPhone = field["ReceiverPhone"];
            String receiverAddress = field["ReceiverAddress"];

            //tao doi tuong don hang
            Order order = new Order();
            order.UserId = userid;
            order.Note = note;
            order.ReceiverName = receiverName;
            order.ReceiverEmail = receiverEmail;
            order.ReceiverPhone = receiverPhone;
            order.ReceiverAddress = receiverAddress;
            order.Status = 1;
            Random rd = new Random();
            order.Code = "DH" + rd.Next(0, 9) + rd.Next(0, 9) + rd.Next(0, 9) + rd.Next(0, 9);
            //order.E = req.CustomerName;

            if (orderDAO.Insert(order) == 1)
            {
                //them vao chi tiet don hang
                List<CartItem> listcart = xcart.getCart();
                foreach (CartItem cartItem in listcart)
                {
                    OrderDetail orderdetail = new OrderDetail();
                    orderdetail.OrderId = order.Id;
                    orderdetail.ProductId = cartItem.ProductId;
                    orderdetail.Price = cartItem.Price;
                    orderdetail.Qty = cartItem.Qty;
                    orderdetail.Amount = cartItem.Amount;
                    oderDetailDAO.Insert(orderdetail); // 
                }

                //send email
                var strSanPham = "";
                var thanhtien = decimal.Zero;
                var TongTien = decimal.Zero;
                foreach (CartItem sp in listcart)
                {
                    strSanPham += "<tr>";
                    strSanPham += "<td>" + sp.Name + "</ td >";
                    strSanPham += "<td>" + sp.Qty + "</td>";
                    strSanPham += "<td>" + banquanao.Common.Common.FormatNumber(sp.Price, 0) + "</td>";
                    strSanPham += "<tr>";
                    thanhtien += sp.Price * sp.Qty;
                }
                TongTien = thanhtien;
                string contentCustomer = System.IO.File.ReadAllText(Server.MapPath("~/Content/templates/send2.html"));
                contentCustomer = contentCustomer.Replace("{{MaDon}}", order.Code);
                contentCustomer = contentCustomer.Replace("{{SanPham}}", strSanPham);
                contentCustomer = contentCustomer.Replace("{{NgayDat}}", DateTime.Now.ToString("dd/MM/yyyy"));

                contentCustomer = contentCustomer.Replace("{{TenKhachHang}}", order.ReceiverName);
                contentCustomer = contentCustomer.Replace("{{Phone}}", order.ReceiverPhone);
                contentCustomer = contentCustomer.Replace("{{Email}}", order.ReceiverEmail);
                contentCustomer = contentCustomer.Replace("{{Diachigiaohang}}", order.ReceiverAddress);

                contentCustomer = contentCustomer.Replace("{{ThanhTien}}", banquanao.Common.Common.FormatNumber(thanhtien, 0));
                contentCustomer = contentCustomer.Replace("{{TongTien}}", banquanao.Common.Common.FormatNumber(TongTien, 0));
                banquanao.Common.Common.SendMail("banquanao", "Đơn hàng #" + order.Code, contentCustomer.ToString(), order.ReceiverEmail);

                string contentAdmin = System.IO.File.ReadAllText(Server.MapPath("~/Content/templates/send1.html"));
                contentAdmin = contentAdmin.Replace("{{Madon}}", order.Code);
                xcart.DelCart();
            }
            
            return Redirect("~/thanh-cong"); 

        }
        public ActionResult ThanhCong()
        {
            return View();
        }

    }
}