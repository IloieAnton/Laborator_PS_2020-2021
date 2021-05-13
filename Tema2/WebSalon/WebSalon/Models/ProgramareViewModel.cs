using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSalon.Models
{
    public class ProgramareViewModel
    {

        public int ProgramareId { get; set; }

        public string numeClient { get; set; }
        public string telefon { get; set; }
        public DateTime dataOra { get; set; }

        public float cost { get; set; }
    }
}
