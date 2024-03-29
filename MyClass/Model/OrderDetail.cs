using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClass.Model
{
    [Table("OrderDetails")]
    public class OrderDetail
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên loại sản phẩm không được để rỗng!")]

        public int? OrderId { get; set; }
        public int? ProductId { get; set; }
        public float? Price { get; set; }
        public int? Qty { get; set; }
        public float Amount { get; set; }

    }
}

