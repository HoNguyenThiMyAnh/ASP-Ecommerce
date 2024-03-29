using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClass.Model
{
    [Table("Product_sales")]

    public class Product_sale
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public int Product_id { get; set; }
        public string PriceSale { get; set; }
        public int Product_sale_id { get; set; }
        public DateTime DateBegin { get; set; }
        public DateTime DateEnd { get; set; }
    }
}

