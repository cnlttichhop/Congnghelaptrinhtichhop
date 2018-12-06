


using QLNhaHangApi.DAO;
using QLNhaHangApi.ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace QLNhaHangApi.Controllers
{
    public class TableController : ApiController
    {
        public object TableDAO { get; private set; }

        // GET: api/Table
        public List<Table> Get()
        {
            TableDAO dao = new TableDAO();
            return dao.GetListTable();
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
