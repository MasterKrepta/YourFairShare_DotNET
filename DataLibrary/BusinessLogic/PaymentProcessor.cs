using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLibrary.DataAccess;
using DataLibrary.Models;

namespace DataLibrary.BusinessLogic
{
    public static class PaymentProcessor
    {
        public static List<Payment> LoadPayments()
        {
            string sql = "sp_GetAllPayments";

            return SqlDataAccess.LoadData<Payment>(sql);
        }
    }

    //public static int CreateBill(string billName, decimal amount, DateTime duedate)
    //{
    //    BillModel data = new BillModel
    //    {
    //        BillName = billName,
    //        Amount = amount,
    //        DueDate = duedate
    //    };

    //    string sql = $"sp_AddNewBill '{data.BillName}', '{data.Amount}', '{data.DueDate}'";
    //    UpdatePayments(data.Amount);
    //    return SqlDataAccess.SaveData(sql, data);
    //}
}
