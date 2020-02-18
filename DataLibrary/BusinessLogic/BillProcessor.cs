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
                BillName = billName,
                Amount = amount,
                DueDate = duedate
            };
            
            string sql = $"sp_AddNewBill '{data.BillName}', '{data.Amount}', '{data.DueDate}'";
            UpdatePayments(data.Amount);
            return SqlDataAccess.SaveData(sql, data);
        }

        public static List<BillModel> LoadBills()
        {
            string sql = "sp_GetAllBills";
            
            return SqlDataAccess.LoadData<BillModel>(sql);
        }

        public static void UpdatePayments(decimal newBill = 0)
        {
            var data = LoadBills();
            var numRoommates = RoommateProcessor.LoadRoommates().Count;
            decimal newPayments = newBill;
            foreach (var item in data)
            {
                newPayments += item.Amount;
            }
            newPayments /= numRoommates;
            string sql = $"sp_UpdatePayment '{newPayments}'";
            SqlDataAccess.SaveData(sql, newPayments);
        }


        public static BillModel GetBill(string Name)
        {
            string sql = $"sp_GetBillByName '{Name}'";
            
            var data = SqlDataAccess.LoadData<BillModel>(sql);

            BillModel bill = new BillModel
            {
                BillName = data[0].BillName,
                Amount = data[0].Amount,
                DueDate = data[0].DueDate
                
            };
            return bill;
        }

        public static void DeleteBill(string billName, decimal amount, DateTime duedate)
        {
            BillModel bill = new BillModel{
                BillName = billName,
                Amount = amount,
                DueDate = duedate
            };

            var sql = $"sp_RemoveBill '{bill.BillName}'";
            SqlDataAccess.SaveData<BillModel>(sql, bill);
            UpdatePayments();
        }

        public static void UpdateBill(string name, decimal amount, DateTime dueDate)
        {
            BillModel data = new BillModel
            {
                BillName = name,
                Amount = amount,
                DueDate = dueDate
            };
            string sql = $"sp_UpdateBill '{name}', '{amount}', '{dueDate}'";
            SqlDataAccess.SaveData<BillModel>(sql, data);
            UpdatePayments();
        }
    }
}
