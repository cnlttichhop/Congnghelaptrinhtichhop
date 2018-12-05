using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinformStudentAPItest
{
    class Student
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
        public DataTable ToDataTable<Student>(List<Student> data)
        {
            PropertyDescriptorCollection properties =
                TypeDescriptor.GetProperties(typeof(Student));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (Student item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }
    }
}
