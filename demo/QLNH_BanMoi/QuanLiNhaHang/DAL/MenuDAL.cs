using QuanLiNhaHang.ENTITY;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiNhaHang.DAL
{
    class MenuDAL
    {   // do

        DatabaseConnect dbConnect = new DatabaseConnect();
        // hiển thị menu theo category
        public List<Menu> getListMenuByIdCategory(int idCategory)
        {
            HttpClient client = new HttpClient();
            StringBaseAdd s = new StringBaseAdd();
            client.BaseAddress = new Uri(s.url);
            HttpResponseMessage response = client.GetAsync("api/Menu/" + idCategory).Result;
            List<Menu> data = response.Content.ReadAsAsync<List<Menu>>().Result;
            return data;
        }

        // lấy id Category theo


        // ********************************************************************************************
        // nhan

        //hien thi menu theo cate
        public DataTable LoadDSMenuByCate(int idCate)
        {
            string query = String.Format("SELECT mn.Id, mn.Name, mn.Price, mn.Status FROM Menu mn, MenuCategory mnc WHERE mn.Idcategory = mnc.Id and IdCategory ='{0}' ", idCate);
            return dbConnect.GETdata(query);
        }

        public async void insertMenu(string name, int price, string status, int idCategory)
        {
            HttpClient client = new HttpClient();
            StringBaseAdd s = new StringBaseAdd();
            client.BaseAddress = new Uri(s.url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            ENTITY.Menu mn = new ENTITY.Menu();
            mn.Name = name;
            mn.Price = price;
            mn.Status = status;
            mn.IdCategory = idCategory;

            try
            {

                HttpResponseMessage responsePost = await client.PostAsJsonAsync("api/Menu", mn);

            }
            catch
            {

            }
        }

        //internal object LoadDSMenuByCate(object idCate)
        //{
        //    throw new NotImplementedException();
        //}

        public async void deleteMenu(int id)
        {
            HttpClient client = new HttpClient();
            StringBaseAdd s = new StringBaseAdd();
            client.BaseAddress = new Uri(s.url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage responsePost = await client.DeleteAsync("api/Menu/" + id);
        }


        public async void UpdateMenu(string name, int price, string status, int idMenu)
        {
            HttpClient client = new HttpClient();
            StringBaseAdd s = new StringBaseAdd();
            client.BaseAddress = new Uri(s.url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            ENTITY.Menu mn = new ENTITY.Menu();
            mn.Name = name;
            mn.Price = price;
            mn.Status = status;
            mn.Id = idMenu;


            HttpResponseMessage responsePost = await client.PutAsJsonAsync("api/Menu", mn);

        }

        public DataTable searchMenu(string name)
        {
            string query = string.Format("SELECT * FROM Menu WHERE Name LIKE '%{0}%'", name);
            return dbConnect.GETdata(query);
        }

        internal object LoadDSMenuByCate()
        {
            throw new NotImplementedException();
        }
    }
}
