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

        public static RoommateModel GetRoommateById(int roommateId)
        {
            string sql = $"sp_GetRoommateById '{roommateId}'";
            var data = SqlDataAccess.LoadData<RoommateModel>(sql);
            RoommateModel result = new RoommateModel();
            foreach (var item in data)
            {
                result = new RoommateModel
                {
                    RoommateId = item.RoommateId,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    MonthlyPayment = item.MonthlyPayment
                    
                };
            }
            return result;

        }
        public static float CalculatePayment()
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

        public static void DeleteRoommate(int id)
        {
            RoommateModel roommate = new RoommateModel
            {
                RoommateId = id,
           
            };

            var sql = $"sp_RemoveRoommate '{id}'";
            SqlDataAccess.SaveData<RoommateModel>(sql, roommate);
        }
    }
}
