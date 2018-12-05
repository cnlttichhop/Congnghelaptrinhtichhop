using QuanLiNhaHang.ENTITY;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiNhaHang.DAL
{
    class AccountDAL
    {

    
      

        //************************an
        DatabaseConnect dtconnect = new DatabaseConnect();
        public DataTable GetAccount()
        {
            string query = "SELECT* FROM dbo.Account";
            return dtconnect.GETdata(query);
        }
        public void insertAcc(Account acc, int id)
        {
            string query = string.Format(" insert Account (UserName,PassWords, Type, IdEmployee) values('{0}','{1}',{2} , {3})", acc.UserName, acc.PassWord, acc.Type, id);
            dtconnect.ExecuteNonQuery(query);
        }
        //**************************
        public void doiMatKhau(string username, string oldpassword, string newpassword)
        {
            string query = string.Format("UPDATE dbo.Account SET PassWords='{0}' WHERE UserName='{1}'AND PassWords='{2}'", newpassword, username, oldpassword);
            dtconnect.ExecuteNonQuery(query);
        }

        // ma hoa password md5
        public string encodeMD5(string input)
        {
            //Tạo MD5 
            MD5 mh = MD5.Create();
            //Chuyển kiểu chuổi thành kiểu byte
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            //mã hóa chuỗi đã chuyển
            byte[] hash = mh.ComputeHash(inputBytes);
            //tạo đối tượng StringBuilder (làm việc với kiểu dữ liệu lớn)
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            Console.WriteLine(sb.ToString());


            string output = sb.ToString();
            return output;
        }
    }
}
