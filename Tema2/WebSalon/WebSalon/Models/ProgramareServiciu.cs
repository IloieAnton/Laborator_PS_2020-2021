using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebSalon.Models
{

    public class ProgramareServiciu
    {
        [Key]
        [Column(Order = 1)]
        public int ProgramareId { get; set; }
   

        [Key]
        [Column(Order = 2)]
        public int ServiciuId { get; set; }

        public virtual Serviciu Serviciu { get; set; }
        public virtual Programare Programare { get; set; }
    }
}
