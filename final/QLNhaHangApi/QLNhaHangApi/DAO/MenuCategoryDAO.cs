using QLNhaHangApi.ENTITY;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace QLNhaHangApi.DAO
{
    public class MenuCategoryDAO
    {
        DatabaseConnect connect = new DatabaseConnect();

        public List<MenuCategory> GetListMenuCategory()
        {

            String query = "SELECT * FROM MenuCategory";
            DataTable data = connect.GETdata(query);
            List<MenuCategory> lsCate = ConvertToListMenuCategory(data);
            return lsCate;
        }
        public List<MenuCategory> ConvertToListMenuCategory(DataTable data)
        {
            List<MenuCategory> listCate = new List<MenuCategory>();
            foreach (DataRow row in data.Select())
            {
                MenuCategory cate = new MenuCategory();
                if (row.ItemArray[0].ToString() != null) cate.Id = Convert.ToInt32( row.ItemArray[0].ToString());
                if (row.ItemArray[1].ToString() != null) cate.Name = row.ItemArray[1].ToString();

                listCate.Add(cate);
            }
            return listCate;
        }
        public void InsertMenuCate(MenuCategory mnc)
        {
            string query = String.Format("INSERT MenuCategory  VALUES (N'{0}')", mnc.Name);
            //DataTable data = dbConnect.GETdata(query);
            connect.ExecuteNonQuery(query);
        }
        public void UpdateMenuCate(MenuCategory mnc)
        {
            string query = string.Format(" UPDATE MenuCategory SET Name = N'{1}' WHERE Id = '{0}'", mnc.Id, mnc.Name);

            connect.ExecuteNonQuery(query);
        }

        public DataSet searchMenuCate(string name)
        {
            var conn = new SqlConnection(
      @"Data Source=DESKTOP-0QO838D\SQLEXPRESS;Initial Catalog=QLNHAHANG2;Integrated Security=True");

            conn.Open();

            var cmd = string.Format("SELECT * FROM MenuCategory WHERE Name LIKE '%{0}%'", name);
            var dataAdapter = new SqlDataAdapter(cmd, conn);

            var data = new DataSet();

            dataAdapter.Fill(data, "BillInFo");

            return data;
           
        }

        public void deleteMenuCate(int id)
        {
            string query = string.Format("DELETE MenuCategory WHERE Id={0}", id);

            connect.ExecuteNonQuery(query);
        }
    }
}