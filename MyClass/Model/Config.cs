﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClass.Model
{
    [Table("Configs")]
    public class Config
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Value { get; set; }
        public int Status { get; set; }

        [Table("Config_settings")]

        public class Config_setting
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string SiteName { get; set; }

        }
    }
}
