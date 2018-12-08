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
    public class AccountController : ApiController
    {
        // GET: api/Account
        public List<Account> Get()
        {
            AccountDAO accDAO = new AccountDAO();
            return accDAO.GetListAccount();
        }
        [HttpGet]
        public void doiMatKhau(string username, string oldpassword, string newpassword)
        {
            AccountDAO accDAO = new AccountDAO();
            accDAO.doiMatKhau(username,oldpassword,newpassword);
        }
        // GET: api/Account/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Account
        public void Post([FromBody]Account account)
        {
            AccountDAO accountDAO = new AccountDAO();
            accountDAO.insertAcc(account);
        }



        // PUT: api/Account/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Account/5
        public void Delete(int id)
        {
        }
    }
}
