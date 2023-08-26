﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Rocky.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [DisplayName("Display Order")]
        public int DisplayOrder { get; set; }
    }
}
