using StudentAPI.DAL;
using StudentAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StudentAPI.Controllers
{
    public class StudentController : ApiController
    {
        // GET: api/Student

        public List<Student> Get()
        {
            StudentDAL stuDAL = new StudentDAL();
            return stuDAL.GetListStudent();
        }


        // GET: api/Student/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Student
        public void Post(Student stu )
        {
            StudentDAL stuDAL = new StudentDAL();
            stuDAL.InsertStudent(stu);
        }

        // PUT: api/Student/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Student/5
        public void Delete(int id)
        {

        }
    }
}
