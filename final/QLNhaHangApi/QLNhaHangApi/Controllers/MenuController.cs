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
    public class MenuController : ApiController
    {
        // GET: api/Menu
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Menu/5
        public List<Menu> Get(int id)
        {
            MenuDAO menudao = new MenuDAO();
            return menudao.getListMenuByIdCategory(id);
        }

        [HttpGet]
        public DataSet searchMenu(string name)
        {
            MenuDAO menudao = new MenuDAO();
            return menudao.searchMenu(name);
        }

        // POST: api/Menu
        public void Post(Menu mnu)
        {
            MenuDAO mnuDAO = new MenuDAO();
            mnuDAO.InsertMenu(mnu);
        }

        // PUT: api/Menu/5
        public void Put(Menu mnu)
        {
            MenuDAO mnuDAO = new MenuDAO();
            mnuDAO.UpdateMenu(mnu);

        }

        // DELETE: api/Menu/5
        public void Delete(int id)
        {
            MenuDAO mnuDAO = new MenuDAO();
            mnuDAO.deleteMenu(id);

        }
    }
}
