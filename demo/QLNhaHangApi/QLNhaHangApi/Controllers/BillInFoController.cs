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
    public class BillInFoController : ApiController
    {
       
        // GET: api/BillInFo
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/BillInFo/5
        public DataSet Get(int id)
        {
            BillInfoDAO infoDAO = new BillInfoDAO();
            return infoDAO.getBillInfoByIdBill(id);
        }

        // POST: api/BillInFo
        public void Post(BillInfo b)
        {
            BillInfoDAO infoDAO = new BillInfoDAO();
             infoDAO.insertBillInfo(b);
        }

        // PUT: api/BillInFo/5
        public void Put(BillInfo b)
        {
            BillInfoDAO infoDAO = new BillInfoDAO();
            infoDAO.editBillInfo(b);
        }

        // DELETE: api/BillInFo/5
        public void Delete(int idBill, int idMenu)
        {
            BillInfoDAO infoDAO = new BillInfoDAO();
            infoDAO.DeleteBillInfo(idBill,idMenu);
        }
    }
}
