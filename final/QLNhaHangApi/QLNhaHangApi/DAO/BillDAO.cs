using QLNhaHangApi.ENTITY;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace QLNhaHangApi.DAO
{
    public class BillDAO
    {
        DatabaseConnect dbConnect = new DatabaseConnect();
        // them 1 bill vs ban
        public void insertBill(Bill b)
        {
            string que = string.Format(" INSERT dbo.Bill(IdTable, DateCheckIn, Status) VALUES({0},  GETDATE() ,0)", b.IdTable, b.DateCheckin.ToShortDateString());         
            dbConnect.ExecuteNonQuery(que);
     
        }
        // update total bill
        public void updateTotalBill(Bill b)
        {
            string query = string.Format(" update Bill set Total ={1} where id ={0}", b.Id,b.Total);
            dbConnect.ExecuteNonQuery(query);
        }

        public DataSet LoadDSByTime(String date1, String date2)
        {
            var conn = new SqlConnection(
@"Data Source=DESKTOP-0QO838D\SQLEXPRESS;Initial Catalog=QLNHAHANG2;Integrated Security=True");

            conn.Open();
      
            //   string query = string.Format("SELECT * FROM dbo.Bill WHERE DateCheckIn>='{0}' AND DateCheckIn<='{1}'", date1.ToShortDateString(), date2.ToShortDateString());
          
     
            var cmd = string.Format("SELECT * FROM dbo.Bill WHERE DateCheckIn>='{0}' AND DateCheckIn<='{1}'", date1, date2);
            var dataAdapter = new SqlDataAdapter(cmd, conn);

            var data = new DataSet();

            dataAdapter.Fill(data, "ListBill");

            return data;

           
        }

    }
}