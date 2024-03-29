using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClass.Model
{
    [Table("Sliders")]
    public class Slider
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Không để rỗng !")]
        public string Name { get; set; }
        public string Link { get; set; }

        [Required(ErrorMessage = "Không để rỗng !")]
        public string Value { get; set; }
        public int? Status { get; set; }

    }
}
