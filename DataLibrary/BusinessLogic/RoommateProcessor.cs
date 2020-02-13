using System;
using System.Collections.Generic;
using System.Text;
using DataLibrary.DataAccess;
using DataLibrary.Models;

namespace DataLibrary.BusinessLogic
{
    public static class RoommateProcessor
    {
        public static int CreateRoommate(string firstName, string lastName)
        {
            RoommateModel data = new RoommateModel
            {
                FirstName = firstName,
                LastName = lastName
            };
            //string sql = @"insert into dbo.Roommates (FirstName, LastName)
            //                Values(@FirstName, @LastName);";

            
            string sql = $"sp_AddRoommate '{data.FirstName}','{data.LastName}'";

            return SqlDataAccess.SaveData<RoommateModel>(sql, data);
        }

        public static List<RoommateModel> LoadRoommates()
        {
            //string sql = @"select RoommateId, FirstName, LastName
            //              from dbo.Roommates;";

            string sql = "sp_GetAllRoommates";
            return SqlDataAccess.LoadData<RoommateModel>(sql);
        }
    }
}
