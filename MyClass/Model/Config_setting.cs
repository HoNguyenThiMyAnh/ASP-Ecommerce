﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClass.Models
{
    [Table("Config_settings")]

    public class Config_setting
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SiteName { get; set; }
    }
}

    
