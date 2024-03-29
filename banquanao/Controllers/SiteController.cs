using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyClass.Models;
using MyClass.DAO;
using PagedList;


namespace banquanao.Controllers
{

    public class SiteController : Controller
    {
        private MyDBContext db = new MyDBContext();
        private LinkDAO linkDAO = new LinkDAO();
        private ProductDAO productDAO = new ProductDAO();
        private PostDAO postDAO = new PostDAO();
        private CategoryDAO categoryDAO = new CategoryDAO();
        private TopicDAO topicDAO = new TopicDAO();
        // URL MAC DINH HOAC URL BAT KY
        public ActionResult Index(string slug = null, int? page=null)
        {
            if (slug == null)
            {
                return this.Homes();
            }
            else
            {
                Link link = linkDAO.getRow(slug);
                if (link != null)
                {
                    string typeLink = link.Type;
                    switch (typeLink)
                    {
                        case "category":
                            {
                                return this.ProductCategory(slug ,page);
                            }
                        case "topic":
                            {
                                return this.PostTopic(slug, page);

                            }
                        case "page":
                            {
                                return this.PostPage(slug);

                            }
                        default:
                            {
                                return this.Error404(slug);

                            }
                    }

                }
                else
                {
                    Product product = productDAO.getRow(slug);
                    if (product != null)
                    {
                        return this.ProductDetail(slug);
                    }
                    else
                    {
                        Post post = postDAO.getRow(slug);
                        if (post != null)
                        {
                            return this.PostDetail(post);
                        }
                        else
                        {
                            return this.Error404(slug);
                        }
                    }
                    //slug co trong bang post post-type=post
                    //slug khong co trong bang link
                }
            }
        }
        //trang chu
        public ActionResult Homes()
        {
            //List<ProductInfo> productNew = productDAO.getList();
           // ViewBag.ProductNew = productNew;
            List<Category> list = categoryDAO.getListByParentId(0);
            return View("Homes", list);
        }
        public ActionResult HomeProduct(int id)
        {
            Category category = categoryDAO.getRow(id); // chi tiet cua id = 3
            ViewBag.Category = category;
            // Danh muc loai theo 3 cap: 3 ==> con 9 ==> con 11
            List<int> listcatid = new List<int>();
            listcatid.Add(id); //cap 1 - 3
            List<Category> listcategory2 = categoryDAO.getListByParentId(id);
            if (listcategory2.Count() != 0)
            {
                foreach (var category2 in listcategory2)
                {
                    listcatid.Add(category2.Id); //cap 2 - 9
                    List<Category> listcategory3 = categoryDAO.getListByParentId(category2.Id);
                    if (listcategory3.Count() != 0)
                    {
                        foreach (var category3 in listcategory3)
                        {
                            listcatid.Add((int)category3.Id); //cap 3 - 11

                        }

                    }

                }

            }
            List<ProductInfo> list = productDAO.getListByListCatId(listcatid, 4);
            return View("HomeProduct", list);
        }
        //nhóm action product
        public ActionResult Product(int? page)
        {
            int pageNummber  = page ?? 1; //trang hien tai
            int pageSize = 1; //so mau tin hien thi tren 1 trang
            IPagedList<ProductInfo> list = productDAO.getList(pageSize, pageNummber);
            return View("Product", list);
        }
        public ActionResult ProductCategory(string slug, int? page)
        {

            int pageNummber = page ?? 1; //trang hien tai
            int pageSize = 1; //so mau tin hien thi tren 1 trang
            Category category = categoryDAO.getRow(slug);
            ViewBag.Category = category;
            // Danh muc loai theo 3 cap: 3 ==> con 9 ==> con 11
            List<int> listcatid = new List<int>();
            listcatid.Add(category.Id); //cap 1 - 3
            List<Category> listcategory2 = categoryDAO.getListByParentId(category.Id);
            if (listcategory2.Count() != 0)
            {
                foreach (var category2 in listcategory2)
                {
                    listcatid.Add(category2.Id); //cap 2 - 9
                    List<Category> listcategory3 = categoryDAO.getListByParentId(category2.Id);
                    if (listcategory3.Count() != 0)
                    {
                        foreach (var category3 in listcategory3)
                        {
                            listcatid.Add((int)category3.Id); //cap 3 - 11

                        }

                    }

                }

            }
            
            IPagedList<ProductInfo> list = productDAO.getListByListCatId(listcatid, pageSize, pageNummber);
            return View("ProductCategory", list);
        }
        public ActionResult ProductDetail(String slug)
        {
            int limit = 4;
            var row = productDAO.getRow(slug);
            int catid = row.CatId; //thuoc loai nao
            List<int> listcatid = categoryDAO.getListId(catid); //
            var listother = productDAO.getList(listcatid, limit, row.Id, true);
            ViewBag.ListOther = listother;
            return View("ProductDetail", row);
        }
        // NHÓM POST
        public ActionResult Post(int? page)
        {
            //int pageNummber = page ?? 1; //trang hien tai
            //int pageSize = 1; //so mau tin hien thi tren 1 trang
            List<PostInfo> list = postDAO.getList("Post");
            return View("Post", list);
        }
        public ActionResult PostTopic(string slug, int? page)
        {
            Topic topic = topicDAO.getRow(slug);
            ViewBag.Topic = topic;
          List <PostInfo> list = postDAO.getListByTopicId(topic.Id, "Post", null);
            return View("PostTopic", list);
        }

        public ActionResult PostPage(string slug)
        {
            Post post = postDAO.getRow(slug, "page"); //bang post
            return View("PostPage", post);
        }
        public ActionResult Product_sale()
        {
            var item = db.Products.Where(x => x.Sale == 1).Take(8).ToList();
            return View("Product_sale", item);
        }
        public ActionResult PostDetail(Post post)
        {
            ViewBag.ListOrther = postDAO.getListByTopicId(post.TopicId, "Post", post.Id);
            return View("PostDetail", post);
        }
        //Hàm  lỗi
        public ActionResult Error404(string slug)
        {

            return View("Error404");
        }

    }
}