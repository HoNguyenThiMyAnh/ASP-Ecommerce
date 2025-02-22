﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClass.Models
{
    [Table("Post")]
    public class Post
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Từ khóa SEO không để rỗng !")]
        public int TopicId { get; set; }

        public String Title { get; set; }
        public string Slug { get; set; }
        [Required(ErrorMessage = "Nội dung bài viết không để rỗng !")]

        public string Detail { get; set; }
        public string Img { get; set; }
        public string PostType { get; set; }

        [Required(ErrorMessage = "Từ khóa SEO không để rỗng !")]
        public string MetaDesc { get; set; }
        [Required(ErrorMessage = "Từ khóa SEO không để rỗng !")]
        public string MetaKey { get; set; }
        public int? Created_By { get; set; }
        public DateTime? Created_At { get; set; }
        public int? Updated_By { get; set; }
        public DateTime? Updated_At { get; set; }
        public int? Status { get; set; }
    }
}
