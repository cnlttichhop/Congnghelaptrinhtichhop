
using QLNhaHangApi.ENTITY;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace QLNhaHangApi.DAO
{
    class TableDAO
    {

        DatabaseConnect connect = new DatabaseConnect();

        public List<Table> GetListTable()
        {
            String query = "SELECT * FROM TableMenu";
            DataTable data = connect.GETdata(query);
            List<Table> lsTable =ConvertToListTable(data);
            return lsTable;
        }

     
        public List<Table> ConvertToListTable(DataTable data)
        {
            List<Table> listTable= new List<Table>();
            foreach (DataRow row in data.Select())
            {
                Table tab = new Table();
                if (row.ItemArray[0].ToString() != null) tab.Id = Convert.ToInt16(row.ItemArray[0].ToString());
                if (row.ItemArray[1].ToString() != null) tab.TableName = row.ItemArray[1].ToString();
                if (row.ItemArray[2].ToString() != null) tab.Status = Convert.ToInt16(row.ItemArray[2].ToString());
                if (row.ItemArray[3].ToString() != "") tab.Area =row.ItemArray[3].ToString();
                listTable.Add(tab);
            }
            return listTable;
        }
        public Table getTableById(int id)
        {

            string query = "select * from TableMenu";
            DataTable data = connect.GETdata(query);
            List<Table> lsTable = new List<Table>();
            // chọn từng dòng trong bảng dữ liệu
            foreach (DataRow item in data.Rows)
            {
                // bên class table đã khởi tạo contructor
                if (Convert.ToInt32(item.ItemArray[0].ToString()) == id)
                {
                    Table tb = new Table(item);
                    return tb;
                }
            }
            return null;
        }
        // goi ham chuyen ban
        public void ChuyenBan(int idOldTable, int idNewTable)
        {
            string query = String.Format("chuyenban {0}, {1}", idOldTable, idNewTable);
            connect.ExecuteNonQuery(query);
        }
        // goi proc thanh toan

        public void ThanhToan(int idTable, int idBill)
        {
            string query = string.Format("thanhToan {0},{1}", idTable, idBill);
            connect.ExecuteNonQuery(query);
        }

        // insert table
        public void InsertTable(Table table)
        {
            string query = string.Format("INSERT dbo.TableMenu(TableName, Status, Area) VALUES(N'{0}' ,{1}, N'{2}')", table.TableName, table.Status, table.Area);
            connect.ExecuteNonQuery(query);
        }

        // edit table 
        public void editTableMenu(int id, Table tb)
        {
            string query = string.Format("UPDATE dbo.TableMenu set TableName=N'{0}',Status={1}, Area=N'{2}' where Id={3}", tb.TableName, tb.Status, tb.Area, id);
            connect.ExecuteNonQuery(query);
        }
        // xóa bàn 

        public void deleteTableMenu(int id)
        {
            string query = string.Format("DELETE dbo.TableMenu WHERE Id={0}", id);
            connect.ExecuteNonQuery(query);
        }

       
        
    }
}