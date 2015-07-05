using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using App.Apex.Web.Models;

namespace App.Apex.Web.Controllers
{
    public class NewsController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [ResponseType(typeof(NewsModel))]
        public async Task<IHttpActionResult> Get(int id)
        {
            NewsModel news = new NewsModel(); //await this.NewsModel(userId);

            if (news == null)
            {
                return this.NotFound();
            }

            return this.Ok(news);
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}