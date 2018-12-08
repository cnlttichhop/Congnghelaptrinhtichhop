using QuanLiNhaHang.ENTITY;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLiNhaHang.DAL
{
    class BillInfoDAL
    {

        // them 1 mon vao hoa don tai ban A

        public DataTable getBillInfoByIdBill(int id)
        {
            HttpClient client = new HttpClient();
            StringBaseAdd s = new StringBaseAdd();
            client.BaseAddress = new Uri(s.url);
            HttpResponseMessage response = client.GetAsync("api/BillInFo/" + id).Result;
            DataSet data = response.Content.ReadAsAsync<DataSet>().Result;
            string datwa = response.Content.ReadAsStringAsync().Result; ;
            return data.Tables[0];
        }

        // them mot mon an vao bill info
        public async void insertBillInfo(int idBill, int idMenu, int count)
        {
            HttpClient client = new HttpClient();
            StringBaseAdd s = new StringBaseAdd();
            client.BaseAddress = new Uri(s.url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            BillInfo b = new BillInfo();
            b.IdBill = idBill;
            b.IdMenu = idMenu;
            b.Count = count;
            HttpResponseMessage responsePost = await client.PostAsJsonAsync("api/BillInfo", b);
          
        }
        public async void editBillInfo(int idBill, int idMenu, int count)
        {
            HttpClient client = new HttpClient();
            StringBaseAdd s = new StringBaseAdd();
            client.BaseAddress = new Uri(s.url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            BillInfo b = new BillInfo();
            b.IdBill = idBill;
            b.IdMenu = idMenu;
            b.Count = count;
            HttpResponseMessage responsePost = await client.PutAsJsonAsync("api/BillInfo", b);
           
        }
        public async void DeleteBillInfo(int idBill, int idMenu)
        {
            HttpClient client = new HttpClient();
            StringBaseAdd s = new StringBaseAdd();
            client.BaseAddress = new Uri(s.url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            BillInfo b = new BillInfo();
            b.IdBill = idBill;
            b.IdMenu = idMenu;
            HttpResponseMessage responsePost = await client.DeleteAsync(String.Format("api/BillInfo?idBill={0}&&idMenu={1}",idBill,idMenu));
           
        }
    }
}
