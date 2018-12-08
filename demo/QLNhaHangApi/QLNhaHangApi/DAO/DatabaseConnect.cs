using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace QLNhaHangApi.DAO
{
    public class DatabaseConnect
    {
        public SqlConnection dataConection()
        {
            return new SqlConnection(@"Data Source=DESKTOP-0QO838D\SQLEXPRESS;Initial Catalog=QLNHAHANG2;Integrated Security=True");
            // 2 chỗ cũng sửa connect là ở BillInfoDAO và BillDAO
        }
        public DataTable GETdata(string querySQL)
        {
            try
            {
                SqlConnection connection = dataConection();
                SqlDataAdapter adapter = new SqlDataAdapter(querySQL, connection);
                DataTable data = new DataTable();
                adapter.Fill(data);
                return data;
            }
            catch
            {
               
                return null;
            }
        }

        public void ExecuteNonQuery(string querySQL)
        {
            try
            {
                SqlConnection connection = dataConection();
                connection.Open();
                SqlCommand command = new SqlCommand(querySQL, connection);
                command.ExecuteNonQuery();
                command.Dispose();
                connection.Close();

            }
            catch
            {
                

            }
        }
    }
}