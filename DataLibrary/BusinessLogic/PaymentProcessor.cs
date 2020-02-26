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

            var data = SqlDataAccess.LoadData<Payment>(sql);
            return data;
        }

        public static int CreatePayment(int billId, int roommateId, decimal amountPaid)
        {
            var bills = BillProcessor.GetBillById(billId);
            var roommates = RoommateProcessor.GetRoommateById(roommateId);
            var data = new Payment{
                RoommateId = roommateId,
                BillId = billId,
                AmountPaid = amountPaid
            };

            //display payment
            string sql = $"sp_AddPayment '{billId}', '{roommateId}', '{amountPaid}'";
            SqlDataAccess.SaveData(sql, data);
            decimal newAmount = bills.AmountDue - amountPaid;
            ApplyPayment(newAmount, billId);
            return 0;

        }

        private static void ApplyPayment(decimal newAmount, int billId)
        {
            string sql = $"sp_ApplyPayment '{billId}', '{newAmount}'";
            var data = new BillModel
            {
                AmountDue = newAmount
            };
            SqlDataAccess.SaveData(sql, data);
            CheckForPayed(billId);
        }

        private static void CheckForPayed(int billId)
        {
            var bill = BillProcessor.GetBillById(billId);

            if (bill.AmountDue <= 0)
            {
                var data = new BillModel();
                string sql = $"spMarkPaid, {billId}";
                SqlDataAccess.SaveData(sql, data);
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

}
