﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace banquanao
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            //khai bao url = co dinh
            routes.MapRoute(
            name: "LienHe",
            url: "lien-he",
            defaults: new { controller = "Lienhe", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "GioHang",
                url: "gio-hang",
                defaults: new { controller = "Giohang", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "ThanhToan",
                url: "thanh-toan",
                defaults: new { controller = "Giohang", action = "ThanhToan", id = UrlParameter.Optional }
            );
            routes.MapRoute(
               name: "ThanhCong",
               url: "thanh-cong",
               defaults: new { controller = "Giohang", action = "ThanhCong", id = UrlParameter.Optional }
           );
            routes.MapRoute(
               name: "TimKiem",
               url: "tim-kiem",
               defaults: new { controller = "Tiemkiem", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "TatCaSanPham",
                url: "tat-ca-san-pham",
                defaults: new { controller = "Site", action = "Product", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "TatCaBaiViet",
                url: "tat-ca-bai-viet",
                defaults: new { controller = "Site", action = "Post", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "SanPhamNhaCungCap",
                url: "tat-ca-nha-cung-cap",
                defaults: new { controller = "Site", action = "Suplier", id = UrlParameter.Optional }
                );

            routes.MapRoute(
                name: "DangNhap",
                    url: "dang-nhap",
                    defaults: new { controller = "Khachhang", action = "DangNhap", id = UrlParameter.Optional}
                );

            //khai bai url động - nằm kế trên default 
            routes.MapRoute(
            name: "SiteLug",
            url: "{slug}",
            defaults: new { controller = "Site", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
              name: "Default",
              url: "{controller}/{action}/{id}",
              defaults: new { controller = "Site", action = "Index", id = UrlParameter.Optional }
          );
        }
    }
}
