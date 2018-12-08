using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiNhaHang.DAL
{
    class BilDAL
    {
        DatabaseConnect dbConnect = new DatabaseConnect();
        // them 1 bill vs ban
        public void insertBill(int idTable, DateTime d)
        {
            //  string query = string.Format("insert Bill(IdTable,DateCheckIn, Status) values ({0},'{1}',0)", idTable, d.ToShortDateString());
         //   string query = string.Format(" INSERT dbo.Bill (IdTable,DateCheckIn, Status) values ({0},'{1}',0)", idTable, d.ToShortDateString());
           string que = string.Format(" INSERT dbo.Bill(IdTable, DateCheckIn, Status) VALUES({0},  GETDATE() ,0)", idTable, d.ToShortDateString());

       //     string query = " INSERT dbo.Bill(IdTable, DateCheckIn, Status) VALUES(" + idTable + ", '" + d.ToShortDateString() + "',0)";
            dbConnect.ExecuteNonQuery(que);
         //   dbConnect.ExecuteNonQuery(query);
        }
        // update total bill
        public void updateTotalBill(int id, int total)
        {
            string query = string.Format(" update Bill set Total ={1} where id ={0}", id, total);
            dbConnect.ExecuteNonQuery(query);
        }


        // binh

        public DataTable LoadDSByTime(DateTime date1, DateTime date2)
        {
            string d1 = date1.Year + "-" + date1.Month + "-" + date1.Day;
            string d2 = date2.Year + "-" + date2.Month + "-" + date2.Day;
            //   string query = string.Format("SELECT * FROM dbo.Bill WHERE DateCheckIn>='{0}' AND DateCheckIn<='{1}'", date1.ToShortDateString(), date2.ToShortDateString());
            string query = string.Format("SELECT * FROM dbo.Bill WHERE DateCheckIn>='{0}' AND DateCheckIn<='{1}'", d1, d2);

            return dbConnect.GETdata(query);
        }

    }
}
