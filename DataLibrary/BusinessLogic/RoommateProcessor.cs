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
            RoomateModel data = new RoomateModel
            {
                FirstName = firstName,
                LastName = lastName
            };
            string sql = @"insert into dbo.Roommates (FirstName, LastName)
                            Values(@FirstName, @LastName);";
            return SqlDataAccess.SaveData(sql, data);
        }

        public static List<RoomateModel> LoadRoommates()
        {
            string sql = @"select RoommateId, FirstName, LastName
                          from dbo.Roommates;";

            return SqlDataAccess.LoadData<RoomateModel>(sql);
        }
    }
}
