using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebSalon.Data;
using WebSalon.Models;
using WebSalon.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebSalon.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProgramareApiController : ControllerBase
    {
        private readonly ProgramareService _programareService;
        public ProgramareApiController(WebSalonContext context)
        {
            _programareService = new ProgramareService(context);
        }

       
        [HttpGet]
        public IEnumerable<Programare> ProgramariUser()
        {
            List<Programare> programariUser = new List<Programare>();
            string username = User.Identity.Name;
            List<Programare> programari = _programareService.GetProgramari().ToList();
            Console.WriteLine(programari);
            foreach(Programare programare in programari)
            {
                if(programare.username == username)
                {
                    programariUser.Add(programare);
                }
            }

            return programariUser;
        }

    }
}
