using QuanLiNhaHang.ENTITY;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace QuanLyNhaHangServiceAPI.DAO
{
    class TableDAO
    {

        private string _connectString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        SqlCommand cmd;
        SqlDataReader reader;

        public List<Table> GetListTable()
        {
            List<Table> lsTable = new List<Table>();
            SqlConnection _Connection = new SqlConnection(_connectString);
            try
            {
                if (_Connection.State == ConnectionState.Closed)
                {
                    _Connection.Open();
                }
                cmd = _Connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM TableMenu";
                cmd.CommandType = CommandType.Text;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Table t = new Table();
                    t.Id =Convert.ToInt32(reader[0].ToString());
                    t.TableName = reader[1].ToString();
                    t.Status = Convert.ToInt32(reader[2].ToString());
                    t.Area = reader[3].ToString();
                    lsTable.Add(t);
                }

            }
            catch
            {
                throw new Exception();
            }
            finally
            {
                cmd.Dispose();
                _Connection.Close();
            }
            return lsTable;
        }

        public void InsertTable(Table Table)
        {

        }
    }
}