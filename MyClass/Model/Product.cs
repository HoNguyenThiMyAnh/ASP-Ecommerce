using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClass.Model
{
    [Table("Products")]
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public int CatId { get; set; }
        public int SupplierId { get; set; }

        [Required(ErrorMessage = "Tên sản phẩm không để rỗng !")]

        public String Name { get; set; }

        public string Slug { get; set; }
        [Required(ErrorMessage = "Chi tiết sản phẩm không để rỗng !")]

        public String Img { get; set; }
        public String PriceBuy { get; set; }
        public String PriceSell { get; set; }
        public String Detail { get; set; }
        public int Number { get; set; }
        public string MetaDesc { get; set; }

        [Required(ErrorMessage = "Từ khóa SEO không để rỗng !")]
        public string MetaKey { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? Created_At { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? Status { get; set; }
    }
}