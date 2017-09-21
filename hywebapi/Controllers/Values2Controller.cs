using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace hywebapi.Controllers
{
    public class Values2Controller : Controller
    {
      
        [Route("api/[controller]/list")]
        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1list-2", "value2list-1" };
        }
        [Route("api/[controller]/{id}")]
        [HttpGet]
        public string Get(int id)
        {
            return "value";
        }
 
    }
}
