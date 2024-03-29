using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClass.Models
{
   public class ProductInfo
    {
        public int Id { get; set; }
        public int CatId { get; set; }
        public int SupplierId { get; set; }
        public String Name { get; set; }
        public String CatName { get; set; }
        public string Slug { get; set; }
        public string Img { get; set; }
        public decimal PriceBuy { get; set; }
        public decimal PriceSell { get; set; }
        public string Detail { get; set; }
        public string Number { get; set; }
        public string MetaDesc { get; set; }
        public string Metakey { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? Created_At { get; set; }
        public int? UpdatedBy { get; set; }
        public int? Status { get; set; }
    }
}
