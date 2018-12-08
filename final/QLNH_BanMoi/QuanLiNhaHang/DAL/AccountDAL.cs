using QuanLiNhaHang.ENTITY;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiNhaHang.DAL
{
    class AccountDAL
    {
        
        //************************an
      
        public DataTable GetAccount()
        {
            HttpClient client = new HttpClient();
            StringBaseAdd s = new StringBaseAdd();
            client.BaseAddress = new Uri(s.url);
            HttpResponseMessage response = client.GetAsync("api/Account").Result;
            List<Account> data = response.Content.ReadAsAsync<List<Account>>().Result;

            return ToDataTable(data);

        }


        //***************************
        // tim nhan vien theo account

        public Employee getEmployeeByAccount(string username)
        {
            List<Table> lsTable = new List<Table>();
            HttpClient client = new HttpClient();
            StringBaseAdd s = new StringBaseAdd();
            client.BaseAddress = new Uri(s.url);
            HttpResponseMessage response = client.GetAsync("api/Employee?username="+username).Result;
           Employee data = response.Content.ReadAsAsync<Employee>().Result;
           
            return data;
        }


        public void doiMatKhau(string username, string oldpassword, string newpassword)
        {
            HttpClient client = new HttpClient();
            StringBaseAdd s = new StringBaseAdd();
            client.BaseAddress = new Uri(s.url);
            HttpResponseMessage response = client.GetAsync(String.Format("api/Account?username={0}&&oldpassword={1}&&newpassword={2}", username, oldpassword, newpassword)).Result;
          
        }



        // insert account
        public async void insertAccount(Account account)
        {
            HttpClient client = new HttpClient();
            StringBaseAdd s = new StringBaseAdd();
            client.BaseAddress = new Uri(s.url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            try
            {

                HttpResponseMessage responsePost = await client.PostAsJsonAsync("api/Account", account);

                if (responsePost.IsSuccessStatusCode)
                {
                    Console.WriteLine("insert Account success");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        //**************************


        // ma hoa password md5
        public string encodeMD5(string input)
        {
            //Tạo MD5 
            MD5 mh = MD5.Create();
            //Chuyển kiểu chuổi thành kiểu byte
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            //mã hóa chuỗi đã chuyển
            byte[] hash = mh.ComputeHash(inputBytes);
            //tạo đối tượng StringBuilder (làm việc với kiểu dữ liệu lớn)
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            Console.WriteLine(sb.ToString());


            string output = sb.ToString();
            return output;
        }
        public DataTable ToDataTable(List<Account> data)
        {
            PropertyDescriptorCollection properties =
                TypeDescriptor.GetProperties(typeof(Account));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (Account item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }
    }
}
