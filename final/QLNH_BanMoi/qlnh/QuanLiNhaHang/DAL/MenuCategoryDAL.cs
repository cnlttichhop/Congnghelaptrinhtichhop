using QuanLiNhaHang.ENTITY;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiNhaHang.DAL
{
    class MenuCategoryDAL
    {
        // lấy danh sách category
        DatabaseConnect dbConnect = new DatabaseConnect();
        public DataTable getListCategory()
        {
            string query = "select * from MenuCategory";
            return dbConnect.GETdata(query);

        }

        public void insertMenuCate(MenuCategory mnc)
        {
            string query = string.Format("INSERT MenuCategory  VALUES (N'{0}')", mnc.Name);
            //DatabaseConnect dtConnet = new DatabaseConnect();
            dbConnect.ExecuteNonQuery(query);
        }

        public void deleteMenuCate(int id)
        {
            string query = string.Format("DELETE MenuCategory WHERE Id={0}", id);
            //DatabaseConnect dtConnet = new DatabaseConnect();
            dbConnect.ExecuteNonQuery(query);
        }

        public void UpdateMenuCate(MenuCategory mnc)
        {
            string query = string.Format(" UPDATE MenuCategory SET Name = N'{1}' WHERE Id = '{0}'", mnc.Id, mnc.Name);
            DatabaseConnect dtConnet = new DatabaseConnect();
            dbConnect.ExecuteNonQuery(query);
        }

        public DataTable searchMenuCate(string name)
        {
            string query = string.Format("SELECT * FROM MenuCategory WHERE Name LIKE '%{0}%'", name);
            return dbConnect.GETdata(query);
        }

    }
}
