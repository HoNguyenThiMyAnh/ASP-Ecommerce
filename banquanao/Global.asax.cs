using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace banquanao
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
        protected void Session_Start()
        {

            //luu thong tin dang nhap quan ly 
            Session["UserAdmin"] = "";
            //luu ma nguoi dang nhap quan ly
            Session["UserId"] = "1";
            Session["Fullname"] = ""; 
            Session["Img"] = ""; 
            //gio hang 
            Session["MyCart"] = "";
            //luu thong tin dang nhap nguoi dung
            Session["UserCustomer"] = "";
            Session["CustomerId"] = "";


        }
    }
}
