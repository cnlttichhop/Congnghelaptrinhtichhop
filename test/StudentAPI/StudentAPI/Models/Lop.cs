using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentAPI.Models
{
    public class Lop
    {
        string id;
        string name;
        public Lop()
        {
            this.id = "";
            this.name = "";
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
    }
}