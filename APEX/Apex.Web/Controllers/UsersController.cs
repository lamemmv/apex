using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Apex.Web.Models;

namespace Apex.Web.Controllers
{
    public class UsersController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // POST api/<controller>
        [HttpPost]
        public void Post(UserLoginModel userLoginModel)
        {
            Console.WriteLine("");
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}
