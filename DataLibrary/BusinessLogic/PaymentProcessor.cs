using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLibrary.DataAccess;
using DataLibrary.Models;
using DataLibrary.ViewModels;

namespace DataLibrary.BusinessLogic
{
    public static class PaymentProcessor
    {

        public static List<AssignedBillViewModel> GetUnpaidBills()
        {
            string sql = "sp_GetUnpaidBills";

            var data = SqlDataAccess.LoadData<AssignedBillViewModel>(sql);
            return data;
        }

        public static List<AssignedBillViewModel> GetPaidBills()
        {
            string sql = "sp_GetAllPayments";

            var data = SqlDataAccess.LoadData<AssignedBillViewModel>(sql);
            return data;
        }



        public static int CreatePayment(int billId, int roommateId, decimal amountPaid)
        {
            var bills = BillProcessor.GetBillById(billId);
            var roommates = RoommateProcessor.GetRoommateById(roommateId);
            var data = new PaymentModel{
                RoommateId = roommateId,
                BillId = billId,
                AmountPaid = amountPaid
            };

            //display payment
            string sql = $"sp_AddPayment '{billId}', '{roommateId}', '{amountPaid}'";
            SqlDataAccess.SaveData(sql, data);
            decimal newAmount = bills.AmountDue - amountPaid;
            ApplyPayment(newAmount, billId);
            RemoveAssignedBill(billId, roommateId);
            Utilities.OnBillPaid(billId);
            return 0;

        }

        private static void RemoveAssignedBill(int billId, int roommateId)
        {
            //TODO debug this query is not running correctly
            string sql = $"sp_RemoveAssignedBill '{billId}', '{roommateId}'";
            SqlDataAccess.ExecuteQuery(sql);
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
                var data = new BillModel{
                    ID = billId,
                    BillName = bill.BillName,
                    AmountDue = bill.AmountDue,
                    DueDate = bill.DueDate,
                    IsCurrent = bill.IsCurrent,
                    Roommates = bill.Roommates
                };

                string sql = $"spMarkPaid {billId}";
                SqlDataAccess.SaveData(sql, data);
            }
        }

        public static List<PaymentModel> GetBillsByWithPayers()
        {
            string sql = $"sp_GetBillsByWhoPaid";
            var data = SqlDataAccess.LoadData<PaymentModel>(sql);


            return data;
        }

        public static PaymentModel GetPaymentById(int id)
        {
            string sql = $"sp_GetPaymentById '{id}'";
            var data = SqlDataAccess.LoadData<PaymentModel>(sql);
            PaymentModel result = new PaymentModel();
            foreach (var item in data)
            {
                result = new PaymentModel
                {
                    Id = item.Id,
                    RoommateId = item.RoommateId,
                    BillId = item.BillId,
                    AmountPaid = item.AmountPaid,
                    DatePaid = item.DatePaid

                };
            }
            return result;

        }
    }

}