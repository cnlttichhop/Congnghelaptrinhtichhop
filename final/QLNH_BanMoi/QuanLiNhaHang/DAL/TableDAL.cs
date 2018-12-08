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
    class TableDAL
    {
      

        // lấy danh sách table từ csdl
        public List<Table> getListTable(int tt) //1 co nguoi , 0 ko có ngươi , 2 all
        {
            List<Table> lsTable = new List<Table>();
            HttpClient client = new HttpClient();
            StringBaseAdd s = new StringBaseAdd();
            client.BaseAddress = new Uri(s.url);
            HttpResponseMessage response = client.GetAsync("api/Table").Result;
            List<Table> data = response.Content.ReadAsAsync<List<Table>>().Result;
            switch (tt)
            {
                case 0:
                    foreach (Table t in data)
                    {
                        if (t.Status == 0)
                        {
                            lsTable.Add(t);
                        }
                    }
                    return lsTable;

                case 1:
                    foreach (Table t in data)
                    {
                        if (t.Status != 0)
                        {
                            lsTable.Add(t);
                        }
                    }
                    return lsTable;

                case 2:

                    return data;


            }

            return lsTable;
        }



        // tra về một bảng với id cho  trước

        public Table getTableById(int id)
        {

            List<Table> lsTable = new List<Table>();
            HttpClient client = new HttpClient();
            StringBaseAdd s = new StringBaseAdd();
            client.BaseAddress = new Uri(s.url);
            HttpResponseMessage response = client.GetAsync("api/Table/" + id).Result;
            Table data = response.Content.ReadAsAsync<Table>().Result;
            return data;
        }


        // goi ham chuyen ban
        public async void ChuyenBan(int idOldTable, int idNewTable)
        {
            List<Table> lsTable = new List<Table>();
            HttpClient client = new HttpClient();
            StringBaseAdd s = new StringBaseAdd();
            client.BaseAddress = new Uri(s.url);
            HttpResponseMessage response = await client.GetAsync(string.Format("api/Table?idOldTable={0}&&idNewTable={1}", idOldTable, idNewTable));

        }
        // goi proc thanh toan

        public async void ThanhToan(int idTable, int idBill)
        {
            List<Table> lsTable = new List<Table>();
            HttpClient client = new HttpClient();
            StringBaseAdd s = new StringBaseAdd();
            client.BaseAddress = new Uri(s.url);
            HttpResponseMessage response = await client.GetAsync(string.Format("api/Table?idTable={0}&&idBill={1}", idTable, idBill));
        }

        //**********************************************************************
        //an


        public List<Table> getTableMenu_Area(string area)
        {
            List<Table> lsTable = new List<Table>();
            HttpClient client = new HttpClient();
            StringBaseAdd s = new StringBaseAdd();
            client.BaseAddress = new Uri(s.url);
            HttpResponseMessage response = client.GetAsync("api/Table").Result;
            List<Table> data = response.Content.ReadAsAsync<List<Table>>().Result;
            foreach (Table t in data)
            {
                if (t.Area == area)
                {
                    lsTable.Add(t);
                }
            }
            return lsTable;
        }

        // tra về một bảng với id cho  trước

        
        // insert một bàn 

        public async void insertTableMenu(Table table)
        {
            HttpClient client = new HttpClient();
            StringBaseAdd s = new StringBaseAdd();
            client.BaseAddress = new Uri(s.url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            try
            {

                HttpResponseMessage responsePost = await client.PostAsJsonAsync("api/Table", table);

                if (responsePost.IsSuccessStatusCode)
                {
                    Console.WriteLine("insert TableMenu success");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public async void editTableMenu(int id, Table table)
        {
            HttpClient client = new HttpClient();
            StringBaseAdd s = new StringBaseAdd();
            client.BaseAddress = new Uri(s.url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            try
            {

                HttpResponseMessage responsePut = await client.PutAsJsonAsync("api/Table/" + id, table);

                if (responsePut.IsSuccessStatusCode)
                {
                    Console.WriteLine("Update TableMenu success");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public async void deleteTableMenu(int id)
        {
            HttpClient client = new HttpClient();
            StringBaseAdd s = new StringBaseAdd();
            client.BaseAddress = new Uri(s.url);

            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));


        }
    }
}