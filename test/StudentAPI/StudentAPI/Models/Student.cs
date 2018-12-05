using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentAPI.Models
{
    public class Student
    {
        string id;
        string name;
        string idLop;
        public Student()
        {
            this.id = "";
            this.name = "";
            this.idLop = "";
        }

        public string Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public string IdLop
        {
            get
            {
                return idLop;
            }

            set
            {
                idLop = value;
            }
        }
    }
}