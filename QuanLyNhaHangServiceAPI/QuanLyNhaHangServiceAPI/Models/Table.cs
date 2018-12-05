using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiNhaHang.ENTITY
{
    class Table
    {

        private int id;
        private string tableName;
        private int status;
        private string area;

        public int Id
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

        public string TableName
        {
            get
            {
                return tableName;
            }

            set
            {
                tableName = value;
            }
        }

        public int Status
        {
            get
            {
                return status;
            }

            set
            {
                status = value;
            }
        }

        public string Area
        {
            get
            {
                return area;
            }

            set
            {
                area = value;
            }
        }

        public Table()
        {
            this.Id = 0;
            this.TableName = "";
            this.Status = 0;
            this.Area = "";
        }

        public Table(int Id, string TableName, int Status, string Area) {
            this.Id = Id;
            this.TableName = TableName;
            this.Status = Status;
            this.Area = Area;
        }

        public Table(DataRow row)
        {
            this.Id = (int)row["Id"];
            this.TableName = row["TableName"].ToString();
            this.Status = (int)row["Status"];
            this.Area = row["Area"].ToString();
        }
    }
}
