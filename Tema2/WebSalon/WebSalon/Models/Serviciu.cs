using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebSalon.Models
{
    public class Serviciu
    {
        public int ServiciuId { get; set; }

        [Display(Name = "Nume Serviciu")]
        public string numeServiciu { get; set; }
        public float pret { get; set; }

        public virtual ICollection<ProgramareServiciu> ProgramareServiciu { get; set; }
    }
}
