using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DummyPazarArdaEren.Models
{
    public class Manager
    {



        public int ID { get; set; }

        public int ManagerType_ID { get; set; }
        [ForeignKey("ManagerType_ID")]
        public virtual ManagerType ManagerType { get; set; }

        [Required(ErrorMessage ="Bu Alan Boş Bırakılamaz")]
        [StringLength(50,ErrorMessage ="En Fazla 50 Karakter Olabilir")]
        public string Name { get; set; }

        [StringLength(50, ErrorMessage = "En Fazla 50 Karakter Olabilir")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Bu Alan Boş Bırakılamaz")]
        [StringLength(50, ErrorMessage = "En Fazla 50 Karakter Olabilir")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Bu Alan Boş Bırakılamaz")]
        [StringLength(maximumLength: 20,MinimumLength =8, ErrorMessage = "Şifre 8-20 Karakter Arasında Olmalıdır")]
        public string Passworld { get; set; }

        [Required(ErrorMessage = "Bu Alan Boş Bırakılamaz")]
        [StringLength(maximumLength: 255, ErrorMessage = "En Fazla 255 Karakter Olabilir")]
        public string Mail { get; set; }

        public bool IsActive { get; set; }

    }
}