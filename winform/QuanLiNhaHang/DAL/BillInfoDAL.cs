using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiNhaHang.DAL
{
    class BillInfoDAL
    {

        // them 1 mon vao hoa don tai ban A
        DatabaseConnect dbConnect = new DatabaseConnect();
        public void insertBillInfo()
        {
            string query = String.Format("");
            dbConnect.ExecuteNonQuery(query);
        }

        // lấy thông tin chi tiết hoa  đơn của 1 bàn ăn

        public DataTable getBillInfoByIdBill(int id)
        {
            string query = String.Format("select m.Id , m.Name, m.IdCategory , b.Count , m.Price, (m.Price *b.Count ) as N'Thanh Tien'   from BillInfo b,Menu m where IdMenu = m.Id   and IdBill={0}", id);
            return dbConnect.GETdata(query);
        }

        // them mot mon an vao bill info
        public void insertBillInfo(int idBill, int idMenu, int soLuong)
        {
            string query = String.Format(" themMon  {0},{1},{2}", idBill, idMenu, soLuong);
            dbConnect.ExecuteNonQuery(query);
        }
        public void editBillInfo(int idBill, int idMenu, int soLuong)
        {
            string query = String.Format("  update BillInfo set Count={2} where IdBill={0} and IdMenu={1}", idBill, idMenu, soLuong);
            dbConnect.ExecuteNonQuery(query);
        }
        public void DeleteBillInfo(int idBill, int idMenu)
        {
            string query = String.Format("  delete BillInfo where IdBill={0} and IdMenu={1}", idBill, idMenu);
            dbConnect.ExecuteNonQuery(query);
        }
    }
}
