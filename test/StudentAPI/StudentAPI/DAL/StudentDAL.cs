using StudentAPI.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace StudentAPI.DAL
{
    public class StudentDAL
    {
        private string _connectString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        SqlCommand cmd;
        SqlDataReader reader;
        public List<Student> GetListStudent()
        {
            List<Student> lsStu = new List<Student>();
            SqlConnection _Connection = new SqlConnection(_connectString);
            try {
                if (_Connection.State == ConnectionState.Closed)
                {
                    _Connection.Open();
                }
                cmd = _Connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM student";
                cmd.CommandType = CommandType.Text;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Student s = new Student();
                    s.Id = reader[0].ToString();
                    s.Name = reader[1].ToString();
                    s.IdLop = reader[2].ToString();
                    lsStu.Add(s);
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
            return lsStu;
        }

        public void InsertStudent(Student stu)
        {

            SqlConnection _Connection = new SqlConnection(_connectString);
            try
            {
                if (_Connection.State == ConnectionState.Closed)
                {
                    _Connection.Open();
                }
                cmd = _Connection.CreateCommand();
                string sql = string.Format("INSERT student values('{0}','{1}','{2}')", stu.Id,stu.Name,stu.IdLop);
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.Write("loi");
            }
            finally
            {
                cmd.Dispose();
                _Connection.Close();
            }
        }
    }
}