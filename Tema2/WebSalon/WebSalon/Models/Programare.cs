using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace WebSalon.Models
{
    public class Programare
    {
        public int ProgramareId { get; set; }
       
        [Display(Name = "Nume Client")]
        public string numeClient { get; set; }
       
        [Display(Name = "Nr. Telefon")]
        [StringLength(10, MinimumLength = 10)]
        [RegularExpression(@"07[0-9]+")]
        public string telefon { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Data/Ora")]
        public DateTime dataOra { get; set; }

        public string username { get; set; }


        public virtual ICollection<ProgramareServiciu> ProgramareServiciu { get; set; }

    }
}
