using QuanLiNhaHang.ENTITY;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiNhaHang.DAL
{
    class MenuDAL
    {   // do

        DatabaseConnect dbConnect = new DatabaseConnect();
        // hiển thị menu theo category
        public DataTable getListMenuByIdCategory(int idCategory)
        {
            string query = String.Format("select * from Menu where IdCategory= {0}", idCategory);
            return dbConnect.GETdata(query);
        }

        // lấy id Category theo


        // ********************************************************************************************
        // nhan

        //hien thi menu theo cate
        public DataTable LoadDSMenuByCate(int idCate)
        {
            string query = String.Format("SELECT mn.Id, mn.Name, mn.Price, mn.Status FROM Menu mn, MenuCategory mnc WHERE mn.Idcategory = mnc.Id and IdCategory ='{0}' ", idCate);
            return dbConnect.GETdata(query);
        }

        public void insertMenu(Menu mn)
        {
            string query = string.Format("INSERT Menu  VALUES (N'{0}', N'{1}', N'{2}',{3})", mn.Name, mn.Price, mn.Status, mn.IdCategory);

            dbConnect.ExecuteNonQuery(query);
        }

        internal object LoadDSMenuByCate(object idCate)
        {
            throw new NotImplementedException();
        }

        public void deleteMenu(int id)
        {
            string query = string.Format("DELETE dbo.Menu WHERE Id={0}", id);

            dbConnect.ExecuteNonQuery(query);
        }

        public void UpdateMenu(Menu mn)
        {
            string query = string.Format(" UPDATE  Menu SET Name = N'{0}', Price = '{1}', Status = N'{2}' WHERE Id = '{3}'", mn.Name, mn.Price, mn.Status, mn.Id);

            dbConnect.ExecuteNonQuery(query);
        }

        public DataTable searchMenu(string name)
        {
            string query = string.Format("SELECT * FROM Menu WHERE Name LIKE '%{0}%'", name);
            return dbConnect.GETdata(query);
        }

        internal object LoadDSMenuByCate()
        {
            throw new NotImplementedException();
        }
    }
}
