using QLNhaHangApi.DAO;
using QLNhaHangApi.ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace QLNhaHangApi.Controllers
{
    public class EmployeeController : ApiController
    {
        // GET: api/Employee
        // GET: api/Employee
        public List<Employee> Get()
        {
            EmployeeDAO employeeDAO = new EmployeeDAO();
            return employeeDAO.getListEmployee();
        }

        // GET: api/Employee/5
        public List<Employee> Get(string name)
        {
            EmployeeDAO employeeDAO = new EmployeeDAO();
            return employeeDAO.searchEmployee(name);
        }

        // POST: api/Employee
        public void Post([FromBody]Employee employee)
        {
            EmployeeDAO employeeDAO = new EmployeeDAO();
            employeeDAO.InsertEmployee(employee);
        }

        // PUT: api/Employee/5
        public void Put(int id, [FromBody]Employee employee)
        {
            EmployeeDAO employeeDAO = new EmployeeDAO();
            employeeDAO.editEmployee(id, employee)
;
        }

        // DELETE: api/Employee/5
        public void Delete(int id)
        {
            EmployeeDAO employeeDAO = new EmployeeDAO();
            employeeDAO.deleteEmployee(id);
        }
    }
}
