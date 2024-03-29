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
    public class PostDAO
    {
        private MyDBContext db = new MyDBContext();
        // Trả về danh sách các mẫu tin

        public List<PostInfo> getListByTopicId(int topicid, string type = "post", int? notid = null)
        {
            List<PostInfo> list = null;
            if (notid == null)
            {
                list = db.Posts
                .Join(
                db.Topics,
                p => p.TopicId,
                t => t.Id,
                (p, t) => new PostInfo
                {
                    Id = p.Id,
                    TopicId = p.TopicId,
                    TopicName = t.Name,
                    Title = p.Title,
                    Slug = p.Slug,
                    Detail = p.Detail,
                    Img = p.Img,
                    PostType = p.PostType,
                    MetaDesc = p.MetaDesc,
                    MetaKey = p.MetaKey,
                    Created_At = p.Created_At,
                    Created_By = p.Created_By,
                    Updated_At = p.Updated_At,
                    Updated_By = p.Updated_By,
                    Status = p.Status,
                }
                )
                .Where(m => m.Status == 1 && m.PostType == type && m.TopicId == topicid).ToList();

            }
            else
            {
                list = db.Posts
              .Join(
              db.Topics,
              p => p.TopicId,
              t => t.Id,
              (p, t) => new PostInfo
              {
                  Id = p.Id,
                  TopicId = p.TopicId,
                  TopicName = t.Name,
                  Title = p.Title,
                  Slug = p.Slug,
                  Detail = p.Detail,
                  Img = p.Img,
                  PostType = p.PostType,
                  MetaDesc = p.MetaDesc,
                  MetaKey = p.MetaKey,
                  Created_At = p.Created_At,
                  Created_By = p.Created_By,
                  Updated_At = p.Updated_At,
                  Updated_By = p.Updated_By,
                  Status = p.Status,
              }
              )
              .Where(m => m.Status == 1 && m.PostType == type && m.TopicId == topicid && m.Id != notid).ToList();
            }
            return list;
        }

        public List<PostInfo> getList(string page = "All", string type = "post")
        {
            List<PostInfo> list = null;
            switch (page)
            {
                case "Index":
                    {

                        list = db.Posts
                                    .Join(db.Posts,
                        p => p.TopicId,
                        t => t.Id,
                        (p, t) => new PostInfo
                        {
                            Id = p.Id,
                            TopicId = p.TopicId,
                            Title = p.Title,
                            Slug = p.Slug,
                            Detail = p.Detail,
                            Img = p.Img,
                            PostType = p.PostType,
                            MetaDesc = p.MetaDesc,
                            MetaKey = p.MetaKey,
                            Created_At = p.Created_At,
                            Created_By = p.Created_By,
                            Updated_At = p.Updated_At,
                            Updated_By = p.Updated_By,
                            Status = p.Status,
                        }
                        )
                        .Where(m => m.Status != 0 && m.PostType == type)
                        .ToList();
                        break;
                    }
                case "Trash":
                    {
                        list = db.Posts
                           .Join(db.Posts,
               p => p.TopicId,
               t => t.Id,
               (p, t) => new PostInfo
               {
                   Id = p.Id,
                   TopicId = p.TopicId,
                   Title = p.Title,
                   Slug = p.Slug,
                   Detail = p.Detail,
                   Img = p.Img,
                   PostType = p.PostType,
                   MetaDesc = p.MetaDesc,
                   MetaKey = p.MetaKey,
                   Created_At = p.Created_At,
                   Created_By = p.Created_By,
                   Updated_At = p.Updated_At,
                   Updated_By = p.Updated_By,
                   Status = p.Status,
               }
               )
               .Where(m => m.Status == 0)
               .ToList();
                        break;
                    }
                default:
                    {
                        list = db.Posts
                           .Join(db.Posts,
               p => p.TopicId,
               t => t.Id,
               (p, t) => new PostInfo
               {
                   Id = p.Id,
                   TopicId = p.TopicId,
                   Title = p.Title,
                   Slug = p.Slug,
                   Detail = p.Detail,
                   Img = p.Img,
                   PostType = p.PostType,
                   MetaDesc = p.MetaDesc,
                   MetaKey = p.MetaKey,
                   Created_At = p.Created_At,
                   Created_By = p.Created_By,
                   Updated_At = p.Updated_At,
                   Updated_By = p.Updated_By,
                   Status = p.Status,
               }
               )

               .ToList();
                        break;
                    }
            }
            return list;

        }
        public List<PostInfo> getList(string type = "post")
        {
            List<PostInfo> list = db.Posts
                .Join(
                db.Topics,
                p => p.TopicId,
                t => t.Id,
                (p, t) => new PostInfo
                {
                    Id = p.Id,
                    TopicId = p.TopicId,
                    TopicName = t.Name,
                    Title = p.Title,
                    Slug = p.Slug,
                    Detail = p.Detail,
                    Img = p.Img,
                    PostType = p.PostType,
                    MetaDesc = p.MetaDesc,
                    MetaKey = p.MetaKey,
                    Created_At = p.Created_At,
                    Created_By = p.Created_By,
                    Updated_At = p.Updated_At,
                    Updated_By = p.Updated_By,
                    Status = p.Status,
                }
                )
                .Where(m => m.Status == 1 && m.PostType == type)
                .ToList();
            return list;

        }
        public Post getRow(int? id)
        {
            return db.Posts.Find(id);
        }
        public Post getRow(string slug)
        {
            return db.Posts.Where(m => m.PostType == "Post" && m.Slug == slug && m.Status == 1).FirstOrDefault();
        }
        public Post getRow(string slug, string posttype)
        {
            return db.Posts.Where(m => m.Slug == slug && m.PostType == posttype && m.Status == 1).FirstOrDefault();
        }

        public int getCount()
        {
            return db.Posts.Count();
        }
        //Trả về 1 mẫu tin

        //Thêm mẫu tin 
        public int Insert(Post row)
        {
            db.Posts.Add(row);
            return db.SaveChanges();
        }
        //Cập nhật  mẫu tin 
        public int Update(Post row)
        {
            db.Entry(row).State = EntityState.Modified;
            return db.SaveChanges();
        }
        //Cập nhật  mẫu tin 
        public int Delete(Post row)
        {
            db.Posts.Remove(row);
            return db.SaveChanges();
        }

    }
}
