using QLNhaHangApi.ENTITY;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace QLNhaHangApi.DAO
{
    public class BillInfoDAO
    {
        // them 1 mon vao hoa don tai ban A
        DatabaseConnect dbConnect = new DatabaseConnect();
        public void insertBillInfo()
        {
            string query = String.Format("");
            dbConnect.ExecuteNonQuery(query);
        }

        // lấy thông tin chi tiết hoa  đơn của 1 bàn ăn

        public DataSet getBillInfoByIdBill(int id)
        {
            var conn = new SqlConnection(
        @"Data Source=DESKTOP-0QO838D\SQLEXPRESS;Initial Catalog=QLNHAHANG2;Integrated Security=True");

            conn.Open();

            var cmd = String.Format("select m.Id , m.Name, m.IdCategory , b.Count , m.Price, (m.Price *b.Count ) as N'Thanh Tien'   from BillInfo b,Menu m where IdMenu = m.Id   and IdBill={0}", id);
            var dataAdapter = new SqlDataAdapter(cmd, conn);

            var data = new DataSet();

            dataAdapter.Fill(data, "BillInFo");

            return data;
        }

        // them mot mon an vao bill info
        public void insertBillInfo(BillInfo b)
        {
            string query = String.Format(" themMon  {0},{1},{2}", b.IdBill, b.IdMenu, b.Count);
            dbConnect.ExecuteNonQuery(query);
        }
        public void editBillInfo(BillInfo b)
        {
            string query = String.Format("  update BillInfo set Count={2} where IdBill={0} and IdMenu={1}", b.IdBill, b.IdMenu, b.Count);
            dbConnect.ExecuteNonQuery(query);
        }
        public void DeleteBillInfo(int idBill, int idMenu)
        {
            string query = String.Format("  delete BillInfo where IdBill={0} and IdMenu={1}", idBill, idMenu);
            dbConnect.ExecuteNonQuery(query);
        }
    }
}