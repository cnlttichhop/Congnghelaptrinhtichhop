using QLNhaHangApi.DAO;
using QLNhaHangApi.ENTITY;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace QLNhaHangApi.Controllers
{
    public class BillController : ApiController
    {
        // GET: api/Bill
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Bill/5
        public DataSet Get(string date1, string date2)
        {
            BillDAO infoDAO = new BillDAO();
            return infoDAO.LoadDSByTime(date1,date2); ;
        }

        // POST: api/Bill
        public void Post(Bill b)
        {
            BillDAO billDAO = new BillDAO();
            billDAO.insertBill(b);
        }

        // PUT: api/Bill/5
        public void Put(Bill b)
        {
            BillDAO billDAO = new BillDAO();
            billDAO.updateTotalBill(b);
        }

        // DELETE: api/Bill/5
        public void Delete(int id)
        {
        }
    }
}
