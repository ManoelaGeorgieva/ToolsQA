using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolsQA.Models
{
    public class AccessExcelData
    {
        public static string TestDataFileConnection()
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\TestData\");
            var filename = "TestData.xlsx";
            var con = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;
		                              Data Source = {0}; 
		                              Extended Properties=Excel 12.0;", path + filename);
            return con;
        }

        public static RegistrationUser GetUserData(string keyName)
        {
            using (var connection = new OleDbConnection(TestDataFileConnection()))
            {
                connection.Open();
                var query = string.Format("select * from [RegistrationUserData$] where key = '{0}'", keyName);
                var value = connection.Query<RegistrationUser>(query).FirstOrDefault();
                connection.Close();
                return value;
            }
        }
    }
}
