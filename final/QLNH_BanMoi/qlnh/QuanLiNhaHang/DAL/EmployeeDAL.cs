using QuanLiNhaHang.ENTITY;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiNhaHang.DAL
{
    class EmployeeDAL
    {
        DatabaseConnect dbConnect = new DatabaseConnect();
        public DataTable getListEmployee()
        {
            string query = " select e.Id, e.Name, e.Address, e.Age, e.PhoneNumber from Employee  e ";
            return dbConnect.GETdata(query);
        }

        // them nhan vien

        public void insertEmployee(Employee emp)
        {
            string query = string.Format("insert Employee(Name, Address, Age, PhoneNumber) values('{0}','{1}',{2},'{3}')",emp.Name, emp.Address, emp.Age, emp.PhoneNumber);
            dbConnect.ExecuteNonQuery(query);
        }

        // sua nhan vien

        public void editEmployee(Employee emp)
        {
            string query = string.Format(" update Employee set Name='{1}', Address= '{2}', Age= {3}, PhoneNumber='{4}' where Id={0}", emp.Id, emp.Name, emp.Address, emp.Age, emp.PhoneNumber);
            dbConnect.ExecuteNonQuery(query);
        }
        // xoa nhan vien
        public void deleteEmployee(int id)
        {
            string query = string.Format(" delete Employee where Id={0} ", id);
            dbConnect.ExecuteNonQuery(query);
        }

        // kiểm tra nhân viên đã có tài khaorn chưa

        public bool CheckHaveAccount(int idEmp)
        {
            string query = "select * from Account";
            DataTable data = dbConnect.GETdata(query);
        
            // chọn từng dòng trong bảng dữ liệu
            foreach (DataRow item in data.Rows)
            {
                if (idEmp.ToString() == item.ItemArray[3].ToString())
                    return false;
                // bên class table đã khởi tạo contructor
            }
            return true;
        }

        // tim kiem 

        public DataTable searchEmployee(string name)
        {
            string query = string.Format(" SELECT * FROM Employee WHERE Name LIKE '%{0}%' ", name);
            return dbConnect.GETdata(query);
        }

    }
}
