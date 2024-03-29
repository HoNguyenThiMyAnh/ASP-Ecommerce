using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClass.Models
{
    [Table("Products")]
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public int CatId { get; set; }
        public int SupplierId { get; set; }

        [Required(ErrorMessage = "Tên sản phẩm không để trống !")]
        public String Name { get; set; }
        public string Slug { get; set; }


        public String  Img { get; set; }
        [Required(ErrorMessage = "Tên sản phẩm không để trống !")]

        public decimal PriceBuy { get; set; }
        public decimal PriceSell { get; set; }
        public string Detail{ get; set; }
        public string Number { get; set; }
        public string MetaDesc { get; set; }
        [Required(ErrorMessage = "Từ khóa SEO không để rỗng !")]
        public string Metakey { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? Created_At { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public int? Status { get; set; }
        public int Sale { get; set; }
    }
}
