using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace QuanLyNhaHangServiceAPI.Controllers
{
    public class TableController : ApiController
    {
        // GET: api/Table
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Table/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Table
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Table/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Table/5
        public void Delete(int id)
        {
        }
    }
}
