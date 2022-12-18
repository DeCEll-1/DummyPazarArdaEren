﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DummyPazarArdaEren.Models
{
    public class Categories
    {


        public int ID { get; set; }


        [Display(Name = "Kategori Adı")]
        [Required(ErrorMessage = "Alana Bir Şey Yazınız")]
        [StringLength(63, ErrorMessage = "Bu Alan En Fazla 63 Karakter Olabilir")]
        public string Name { get; set; }

        [Display(Name = "Açıklama")]
        [DataType(DataType.MultilineText)]
        [StringLength(4095, ErrorMessage = "Bu Alan En Fazla 4095 Karakter Olabilir")]
        public string Description { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}