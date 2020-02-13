using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;


namespace DataLibrary.DataAccess
{
    public static class SqlDataAccess
    {
        public static string GetCnnString(string connName = "YourFairShareDB")
        {
            
            string result = ConfigurationManager.ConnectionStrings[connName].ConnectionString;
            return result;
        }

        public static List<T> LoadData<T>(string sql)
        {
            using (IDbConnection cnn = new SqlConnection(GetCnnString()))
            {
                return cnn.Query<T>(sql).ToList();
            }
        }

        public static int SaveData<T>(string sql, T data)
        {
            using (IDbConnection cnn = new SqlConnection(GetCnnString()))
            {
                return cnn.Execute(sql, data);
            }
        }

     
    }
}
