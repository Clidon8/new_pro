using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;
using Models;
namespace API.Controllers
{
    [RoutePrefix("api/Main")]
    public class MainController : ApiController
    {
        Algoritem mainBl = new Algoritem();
        DocumentBL documentBl = new DocumentBL();
       
        // GET: api/Main
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Main/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Main
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Main/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Main/5
        public void Delete(int id)
        {
        }
        [Route("insert")]
        [HttpPost]
        public int Insert(Document d)
        {
            try
            {
                documentBl.AddDocument(d);
                return d.code;
            }
            catch (Exception)
            {
                return -1;
            }
        }
    }
}
