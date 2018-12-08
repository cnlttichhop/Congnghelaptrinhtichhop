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
    class EmployeeDAL
    {
        DatabaseConnect dbConnect = new DatabaseConnect();
        // lấy tất cả nhân viên
        public List<Employee> getListEmployee()
        {
            List<Employee> lsEmployee = new List<Employee>();
            HttpClient client = new HttpClient();
            StringBaseAdd s = new StringBaseAdd();
            client.BaseAddress = new Uri(s.url);
            HttpResponseMessage respone = client.GetAsync("api/Employee").Result;
            List<Employee> data = respone.Content.ReadAsAsync<List<Employee>>().Result;
            return data;
        }
        // lấy nhân viên có tên = ""
        public List<Employee> searchEmployee(string name)
        {
            List<Employee> lsEmployee = new List<Employee>();
            HttpClient client = new HttpClient();
            StringBaseAdd s = new StringBaseAdd();
            client.BaseAddress = new Uri(s.url);
            HttpResponseMessage respone = client.GetAsync("api/Employee/" + name).Result;
            List<Employee> data = respone.Content.ReadAsAsync<List<Employee>>().Result;
            return data;
        }

        public async void insertEmployee(Employee employee)
        {
            HttpClient client = new HttpClient();
            StringBaseAdd s = new StringBaseAdd();
            client.BaseAddress = new Uri(s.url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            try
            {

                HttpResponseMessage responsePost = await client.PostAsJsonAsync("api/Employee", employee);

                if (responsePost.IsSuccessStatusCode)
                {
                    Console.WriteLine("insert Employee success");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        // updateemployee 
        public async void editEmployee(int id, Employee employee)
        {
            HttpClient client = new HttpClient();
            StringBaseAdd s = new StringBaseAdd();
            client.BaseAddress = new Uri(s.url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            try
            {

                HttpResponseMessage responsePut = await client.PutAsJsonAsync("api/Employee/" + id, employee);

                if (responsePut.IsSuccessStatusCode)
                {
                    Console.WriteLine("update Employee success");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        // delete employee

        public async void deleteEmployee(int id)
        {
            HttpClient client = new HttpClient();
            StringBaseAdd s = new StringBaseAdd();
            client.BaseAddress = new Uri(s.url);

            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage responedelete = await client.DeleteAsync("api/Employee/" + id);
        }



        // kiểm tra nhân viên đã có tài khaorn chưa

        public bool CheckHaveAccount(int idEmp)
        {
            string query = "select * from Account";
            DataTable data = dbConnect.GETdata(query);

            // chọn từng dòng trong bảng dữ liệu
            foreach (DataRow item in data.Rows)
            {
                if (idEmp.ToString() == item.ItemArray[3].ToString())
                    return false;
                // bên class table đã khởi tạo contructor
            }
            return true;
        }

        // tim kiem 

       

    }
}
