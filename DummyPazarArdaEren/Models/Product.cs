using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DummyPazarArdaEren.Models
{
    public class Product
    {

        public int ID { get; set; }

        public int Category_ID { get; set; }

        [ForeignKey("Category_ID")]
        public virtual Categories Category { get; set; }

        [Display(Name="Ürün")]
        [Required(ErrorMessage ="Lütfen Bir Ürün Adı Giriniz")]
        [StringLength(127,ErrorMessage ="Bu Alan En Fazla 127 Karakter Olabilir")]
        public string Name { get; set; }

        [Display(Name="Açıklama")]
        [StringLength(4095,ErrorMessage = "Bu Alan En Fazla 4095 Karakter Olabilir")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }


        [Display(Name = "Büyük Resim")]
        [StringLength(127)]
        public string ImageBigPath { get; set; }

        [Display(Name = "İkon Resmi")]
        [StringLength(127)]
        public string ImageIconPath { get; set; }


        [Display(Name="Fiyat")]
        [Required(ErrorMessage ="Bu Alan Boş Bırakılamaz")]
        public decimal Price { get; set; }

        [Display(Name="Aktif mi")]
        public bool IsActive { get; set; }
    }
}