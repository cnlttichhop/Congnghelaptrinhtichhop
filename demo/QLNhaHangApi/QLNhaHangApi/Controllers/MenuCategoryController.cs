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
    public class MenuCategoryController : ApiController
    {
        // GET: api/MenuCategory
        public List<MenuCategory> Get()
        {
            MenuCategoryDAO cateDAO = new MenuCategoryDAO();
            return cateDAO.GetListMenuCategory();
        }

        // GET: api/MenuCategory/5
        public string Get(int id)
        {
            return "value";
        }
        // POST: api/MenuCategory
        public void Post(MenuCategory mnc)
        {
            MenuCategoryDAO mncDAO = new MenuCategoryDAO();
            mncDAO.InsertMenuCate(mnc);
        }

        // PUT: api/MenuCategory/5
        public void Put(MenuCategory mnc)
        {
            MenuCategoryDAO mncDAO = new MenuCategoryDAO();
            mncDAO.UpdateMenuCate(mnc);
        }

        // DELETE: api/MenuCategory/5
        public void Delete(int id)
        {
            MenuCategoryDAO mncDAO = new MenuCategoryDAO();
            mncDAO.deleteMenuCate(id);
        }
    }
}
