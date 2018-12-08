using QuanLiNhaHang.ENTITY;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiNhaHang.DAL
{
    class MenuCategoryDAL
    {
        // lấy danh sách category
        DatabaseConnect dbConnect = new DatabaseConnect();
        public DataTable getListCategory()
        {
            HttpClient client = new HttpClient();
            StringBaseAdd s = new StringBaseAdd();
            client.BaseAddress = new Uri(s.url);
            HttpResponseMessage response = client.GetAsync("api/MenuCategory").Result;
            String a = response.Content.ReadAsStringAsync().Result;
            List<MenuCategory> data = response.Content.ReadAsAsync<List<MenuCategory>>().Result;

            return ToDataTable(data);

        }
        public DataTable ToDataTable(List<MenuCategory> data)
        {
            PropertyDescriptorCollection properties =
                TypeDescriptor.GetProperties(typeof(MenuCategory));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (MenuCategory item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }
        public async void insertMenuCate(string name)
        {
            HttpClient client = new HttpClient();
            StringBaseAdd s = new StringBaseAdd();
            client.BaseAddress = new Uri(s.url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            MenuCategory mnc = new MenuCategory();
            mnc.Name = name;


            HttpResponseMessage responsePost = await client.PostAsJsonAsync("api/MenuCategory", mnc);

        }

        public async void deleteMenuCate(int id)
        {
            HttpClient client = new HttpClient();
            StringBaseAdd s = new StringBaseAdd();
            client.BaseAddress = new Uri(s.url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage responsePost = await client.DeleteAsync("api/MenuCategory/" + id);
        }

        public async void UpdateMenuCate(string name, int idmenucate)
        {
            HttpClient client = new HttpClient();
            StringBaseAdd s = new StringBaseAdd();
            client.BaseAddress = new Uri(s.url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            MenuCategory mnc = new MenuCategory();
            mnc.Name = name;
            mnc.Id = idmenucate;


            HttpResponseMessage responsePost = await client.PutAsJsonAsync("api/MenuCategory", mnc);
        }

        public DataTable searchMenuCate(string name)
        {
            string query = string.Format("SELECT * FROM MenuCategory WHERE Name LIKE '%{0}%'", name);
            return dbConnect.GETdata(query);
        }

    }
}
