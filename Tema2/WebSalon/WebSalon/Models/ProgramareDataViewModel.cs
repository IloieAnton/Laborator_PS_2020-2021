using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebSalon.Models
{
    public class ProgramareDataViewModel
    {
        public List<Programare> programari { get; set; }
        public SelectList DateInceput { get; set; }
        public SelectList DateFinala { get; set; }
        public DateTime pDataI { get; set; }
        public DateTime pDataF { get; set; }
        public string numeClient { get; set; }

    }
}
