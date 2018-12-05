using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Net.Http.Headers;

namespace WinformStudentAPItest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
       

        private void button1_Click(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:7333/");
            HttpResponseMessage response = client.GetAsync("api/Student/").Result;
            List<Student> data = response.Content.ReadAsAsync<List<Student>>().Result;
            textBox1.Text = data[0].Name;
            Student s = new Student();
            DataTable data1 = s.ToDataTable<Student>(data);
            dataGridView1.DataSource = data1;
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            Student stu = new Student();
            stu.Id = tbid.Text;
            stu.Name = tbname.Text;
            stu.IdLop = "001";
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:7333/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                
                HttpResponseMessage responsePost = await client.PostAsJsonAsync("api/Student", stu);

                if (responsePost.IsSuccessStatusCode)
                {
                    MessageBox.Show("heh", "heheh");
            
                }
            }
            catch
            {

            }
            HttpResponseMessage response = client.GetAsync("api/Student/").Result;
            List<Student> data = response.Content.ReadAsAsync<List<Student>>().Result;
            textBox1.Text = data[0].Name;
            Student s = new Student();
            DataTable data1 = s.ToDataTable<Student>(data);
            dataGridView1.DataSource = data1;
        }
    }

}
