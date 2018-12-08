using QLNhaHangApi.ENTITY;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace QLNhaHangApi.DAO
{
    public class MenuDAO
    {
        DatabaseConnect dbConnect = new DatabaseConnect();
        // hiển thị menu theo category
        public List<Menu> getListMenuByIdCategory(int idCategory)
        {
            string query = String.Format("select * from Menu where IdCategory= {0}", idCategory);
            DataTable data = dbConnect.GETdata(query);
            return ConvertToListMenu(data);
        }
        public List<Menu> ConvertToListMenu(DataTable data)
        {
            List<Menu> listmenu = new List<Menu>();
            foreach (DataRow row in data.Select())
            {
                Menu menu = new Menu();
                if (row.ItemArray[0].ToString() != null) menu.Id =Convert.ToInt32( row.ItemArray[0].ToString());
                if (row.ItemArray[1].ToString() != "") menu.Name = row.ItemArray[1].ToString();
                if (row.ItemArray[2].ToString() != null) menu.Price = Convert.ToInt32(row.ItemArray[2].ToString());
                if (row.ItemArray[3].ToString() != "") menu.Status = (row.ItemArray[3].ToString());
                if (row.ItemArray[4].ToString() != null) menu.IdCategory = Convert.ToInt32(row.ItemArray[4].ToString());
                listmenu.Add(menu);
            }
            return listmenu;
        }
        public void InsertMenu(Menu mn)
        {
            string query = String.Format("INSERT Menu  VALUES(N'{0}', N'{1}', N'{2}',{3})", mn.Name, mn.Price, mn.Status, mn.IdCategory);
            //DataTable data = dbConnect.GETdata(query);
            dbConnect.ExecuteNonQuery(query);
        }
        public void UpdateMenu(Menu mn)
        {
            string query = string.Format(" UPDATE  Menu SET Name = N'{0}', Price = '{1}', Status = N'{2}' WHERE Id = '{3}'", mn.Name, mn.Price, mn.Status, mn.Id);

            dbConnect.ExecuteNonQuery(query);
        }

        public DataSet searchMenu(string name)
        {
            var conn = new SqlConnection(
        @"Data Source=DESKTOP-0QO838D\SQLEXPRESS;Initial Catalog=QLNHAHANG2;Integrated Security=True");

            conn.Open();

            var cmd = string.Format("SELECT * FROM Menu WHERE Name LIKE '%{0}%'", name);
            var dataAdapter = new SqlDataAdapter(cmd, conn);

            var data = new DataSet();

            dataAdapter.Fill(data, "BillInFo");

            return data;
           
        }

        public void deleteMenu(int id)
        {
            string query = string.Format("DELETE dbo.Menu WHERE Id={0}", id);

            dbConnect.ExecuteNonQuery(query);
        }
    }
}