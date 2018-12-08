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
    class BilDAL
    {
       
        // them 1 bill vs ban
        public async void insertBill(int idTable, DateTime d)
        {
            HttpClient client = new HttpClient();
            StringBaseAdd s = new StringBaseAdd();
            client.BaseAddress = new Uri(s.url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            Bill b = new Bill();
            b.IdTable = idTable;
            b.DateCheckin = d;
            try
            {

                HttpResponseMessage responsePost = await client.PostAsJsonAsync("api/Bill", b);

                if (responsePost.IsSuccessStatusCode)
                {
                    MessageBox.Show("ok", "ok");

                }
            }
            catch
            {

            }
        }
        // update total bill
        public async void updateTotalBill(int id, int total)
        {
            HttpClient client = new HttpClient();
            StringBaseAdd s = new StringBaseAdd();
            client.BaseAddress = new Uri(s.url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            Bill b = new Bill();
            b.Id = id;
            b.Total = total;
            HttpResponseMessage responsePost = await client.PutAsJsonAsync("api/Bill", b);
        }


        // binh

        public DataTable LoadDSByTime(DateTime date1, DateTime date2)
        {
            string d1 = date1.Year + "-" + date1.Month + "-" + date1.Day;
            string d2 = date2.Year + "-" + date2.Month + "-" + date2.Day;
            HttpClient client = new HttpClient();
            StringBaseAdd s = new StringBaseAdd();
            client.BaseAddress = new Uri(s.url);
            HttpResponseMessage response = client.GetAsync(String.Format("api/Bill?date1={0}&&date2={1}",d1,d2)).Result;
            DataSet data = response.Content.ReadAsAsync<DataSet>().Result;
            string datwa = response.Content.ReadAsStringAsync().Result; ;
            return data.Tables[0];
        }

    }
}
