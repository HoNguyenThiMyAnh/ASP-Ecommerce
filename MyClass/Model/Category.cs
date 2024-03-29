using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClass.Model
{
    [Table("Categorys")]
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên loại sản phẩm không được để rỗng!")]
        public string Name { get; set; }

        public String Slug { get; set; }

        public int? ParentId { get; set; }
        public int? Orders { get; set; }
        [Required(ErrorMessage = "Mo ta  SEO không để rỗng !")]
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
