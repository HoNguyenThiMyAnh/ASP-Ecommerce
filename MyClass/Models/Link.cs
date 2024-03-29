using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClass.Models
{
    [Table("Links")]
    public class Link
    {
        [Key]
        public int Id { get; set; }
        public String Slug { get; set; }
        public string Type { get; set; }
        public int TableId { get; set; }

    }
}
