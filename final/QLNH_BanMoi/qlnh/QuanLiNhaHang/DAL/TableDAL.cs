using QuanLiNhaHang.ENTITY;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiNhaHang.DAL
{
    class TableDAL
    {
        DatabaseConnect dbConnect = new DatabaseConnect();
       
        // lấy danh sách table từ csdl
        public List<Table> getListTable(int tt) //1 co nguoi , 0 ko có ngươi , 2 all
        {
            List<Table> lsTable = new List<Table>();
          switch (tt)
            {
                case 0:
                    string query = String.Format("select * from TableMenu where Status=0");
                    DataTable data = dbConnect.GETdata(query);

                    // chọn từng dòng trong bảng dữ liệu
                    foreach (DataRow item in data.Rows)
                    {
                        // bên class table đã khởi tạo contructor
                        Table tb = new Table(item);
                        lsTable.Add(tb);
                    }
                    break;
                case 1:
                    string query1 = String.Format("select * from TableMenu where Status<>0" );
                    DataTable data1 = dbConnect.GETdata(query1);

                    // chọn từng dòng trong bảng dữ liệu
                    foreach (DataRow item in data1.Rows)
                    {
                        // bên class table đã khởi tạo contructor
                        Table tb = new Table(item);
                        lsTable.Add(tb);
                    }
                    break;
                case 2:
                    string query2 = "select * from TableMenu";
                    DataTable data2 = dbConnect.GETdata(query2);

                    // chọn từng dòng trong bảng dữ liệu
                    foreach (DataRow item in data2.Rows)
                    {
                        // bên class table đã khởi tạo contructor
                        Table tb = new Table(item);
                        lsTable.Add(tb);
                    }
                    break;
                
            }

            return lsTable;
        }

        // hien thi danh sach ban trống

        public List<Table> getListTableEmpty()
        {
            string query = "select * from TableMenu";
            DataTable data = dbConnect.GETdata(query);
            List<Table> lsTable = new List<Table>();
            // chọn từng dòng trong bảng dữ liệu
            foreach (DataRow item in data.Rows)
            {
                
                // bên class table đã khởi tạo contructor
                Table tb = new Table(item);
                if(tb.Status==0) lsTable.Add(tb);
            }
            return lsTable;
        }
        // tra về một bảng với id cho  trước

        public Table getTableById(int id)
        {
           
            string query = "select * from TableMenu";
            DataTable data = dbConnect.GETdata(query);
            List<Table> lsTable = new List<Table>();
            // chọn từng dòng trong bảng dữ liệu
            foreach (DataRow item in data.Rows)
            {
                // bên class table đã khởi tạo contructor
                if( Convert.ToInt32(item.ItemArray[0].ToString() )== id)
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
            dbConnect.ExecuteNonQuery(query);
        }
        // goi proc thanh toan

        public void ThanhToan(int idTable , int idBill)
        {
            string query = string.Format("thanhToan {0},{1}", idTable, idBill);
            dbConnect.ExecuteNonQuery(query);
        }

        //**********************************************************************
        //an

        public DataTable getTableMenu()
        {
            string query = "SELECT * FROM dbo.TableMenu";
            return dbConnect.GETdata(query);
        }
        //
        public DataTable getTableMenu_Area(string Area)
        {
            string query = string.Format("SELECT * FROM dbo.TableMenu WHERE Area=N'{0}'", Area);
            return dbConnect.GETdata(query);
        }
        // them ban
        public void insertTableMenu(Table tb)
        {
            string query = string.Format("INSERT dbo.TableMenu(TableName, Status, Area) VALUES(N'{0}', {1}, N'{2}')", tb.TableName, tb.Status, tb.Area);
            dbConnect.ExecuteNonQuery(query);
        }

        // sua ban
        public void editTableMenu(Table tb)
        {
            string query = string.Format("UPDATE dbo.TableMenu set TableName=N'{0}',Status={1}, Area=N'{2}' where Id={3}", tb.TableName, tb.Status, tb.Area, tb.Id);
            dbConnect.ExecuteNonQuery(query);
        }

        // xoa ban
        public void deleteTableMenu(int id)
        {
            string query = string.Format("DELETE dbo.TableMenu WHERE Id={0}", id);
            dbConnect.ExecuteNonQuery(query);
        }
    }
}
