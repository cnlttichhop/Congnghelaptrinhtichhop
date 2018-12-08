using QLNhaHangApi.ENTITY;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace QLNhaHangApi.DAO
{
    public class EmployeeDAO
    {
        DatabaseConnect dbConnect = new DatabaseConnect();
            
        public List<Employee> getListEmployee()
        {
            string query = String.Format("select * from Employee");
            DataTable data = dbConnect.GETdata(query);
            return ConvertToListEmployee(data);
        }

        public void InsertEmployee(Employee employee)
        {
            string query = string.Format("INSERT dbo.Employee(Name , Age, Address, PhoneNumber) VALUES(N'{0}' ,{1}, N'{2}', N'{3}')",employee.Name, employee.Age, employee.Address, employee.PhoneNumber);
            dbConnect.ExecuteNonQuery(query);
        }

        public void editEmployee(int id, Employee emp)
        {
            string query = string.Format(" update Employee set Name=N'{1}', Address= N'{2}', Age= {3}, PhoneNumber='{4}' where Id={0}", id, emp.Name, emp.Address, emp.Age, emp.PhoneNumber);
            dbConnect.ExecuteNonQuery(query);
        }
        // xoa nhan vien
        public void deleteEmployee(int id)
        {
            string query = string.Format(" delete Employee where Id={0} ", id);
            dbConnect.ExecuteNonQuery(query);
        }

        public List<Employee> searchEmployee(string name)
        {
            string query = string.Format(" SELECT * FROM Employee WHERE Name LIKE '%{0}%' ", name);
            DataTable data = dbConnect.GETdata(query);
            return ConvertToListEmployee(data);
        }

        public List<Employee> ConvertToListEmployee(DataTable data)
        {
            List<Employee> listEmployee = new List<Employee>();
            foreach (DataRow row in data.Select())
            {
                Employee employee = new Employee();
                if (row.ItemArray[0].ToString() != null) employee.Id = Convert.ToInt32(row.ItemArray[0].ToString());
                if (row.ItemArray[1].ToString() != "") employee.Name = row.ItemArray[1].ToString();
                if (row.ItemArray[2].ToString() != null) employee.Age = Convert.ToInt32(row.ItemArray[2].ToString());
                if (row.ItemArray[3].ToString() != "") employee.Address = (row.ItemArray[3].ToString());
                if (row.ItemArray[4].ToString() != null) employee.PhoneNumber = row.ItemArray[4].ToString();
                listEmployee.Add(employee);
            }
            return listEmployee;
        }
    }
}