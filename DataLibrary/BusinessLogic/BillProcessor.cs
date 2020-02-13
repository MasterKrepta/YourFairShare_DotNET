using DataLibrary.DataAccess;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.BusinessLogic
{
    public static class BillProcessor
    {
        public static int CreateBill(string billName, decimal amount, DateTime duedate)
        {
            BillModel data = new BillModel
            {
                Name = billName,
                Amount = amount,
                DueDate = duedate
            };
            
            //string sql = @"insert into dbo.Bills (Name, Amount, DueDate)
            //                Values(@Name, @Amount, @DueDate);";
            string sql = $"sql_AddNewBill '{data.Name}', '{data.Amount}', '{data.DueDate}'";
            return SqlDataAccess.SaveData(sql, data);
        }

        public static List<BillModel> LoadBills()
        {
            //string sql = @"select Id, Name, Amount, DueDate
            //              from dbo.Bills;";

            string sql = "sp_GetAllBills";
            return SqlDataAccess.LoadData<BillModel>(sql);
        }
    }
}
