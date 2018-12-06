

using QLNhaHangApi.ENTITY;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace QLNhaHangApi.DAO
{
    class AccountDAO
    {
        DatabaseConnect connect = new DatabaseConnect();

        public List<Account> GetListAccount()
        {

            String query = "SELECT * FROM Account";
            DataTable data = connect.GETdata(query);
            List<Account> lsAcc = ConvertToListAccount(data);
            return lsAcc;
        }

        public List<Account> ConvertToListAccount(DataTable data)
        {
            List<Account> listAcc = new List<Account>();
            foreach (DataRow row in data.Select())
            {
                Account acc = new Account();
                if (row.ItemArray[0].ToString() != null) acc.UserName = row.ItemArray[0].ToString();
                if (row.ItemArray[1].ToString() != null) acc.PassWord = row.ItemArray[1].ToString();
                if (row.ItemArray[2].ToString() != null) acc.Type = Convert.ToInt16(row.ItemArray[2].ToString());
                if (row.ItemArray[3].ToString() != "") acc.IdEmployee = Convert.ToInt16(row.ItemArray[3].ToString());
                listAcc.Add(acc);
            }
            return listAcc;
        }

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