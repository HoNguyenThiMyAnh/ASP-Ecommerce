using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClass.Models
{
    public class Brand
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public String Name { get; set; }
       
        public String Slug { get; set; }
        public string Img { get; set; }
        
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int? Orders { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? Created_At { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? Status { get; set; }

    }
}
