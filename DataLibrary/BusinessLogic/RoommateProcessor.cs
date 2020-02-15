using System;
using System.Collections.Generic;
using System.Text;
using DataLibrary.DataAccess;
using DataLibrary.Models;

namespace DataLibrary.BusinessLogic
{
    public static class RoommateProcessor
    {
        public static int CreateRoommate(string firstName, string lastName, decimal payment)
        {
            RoommateModel data = new RoommateModel
            {
                FirstName = firstName,
                LastName = lastName,
                MonthlyPayment =  (decimal)CalculatePayment()
            };
            //string sql = @"insert into dbo.Roommates (FirstName, LastName)
            //                Values(@FirstName, @LastName);";

            
            string sql = $"sp_AddRoommate '{data.FirstName}','{data.LastName}', '{data.MonthlyPayment}'";

            return SqlDataAccess.SaveData<RoommateModel>(sql, data);
        }

        private static float CalculatePayment()
        {
            string sql = "sp_CalculatePayment";
            var data = SqlDataAccess.LoadData<float>(sql);
            float result = 0;
            foreach (var item in data)
            {
                result += item;
            }
            var roomates = LoadRoommates().Count;
            if (roomates > 1)
            {
                result = result / roomates;
            }
            
            return result;
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
