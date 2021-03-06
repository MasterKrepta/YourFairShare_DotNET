﻿using DataLibrary.DataAccess;
using DataLibrary.Models;
using DataLibrary.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.BusinessLogic
{
    public static class BillProcessor
    {
        public static Action<int> OnBillPaid = (int id) => { };




        public static int CreateBill(string billName, decimal amount, DateTime duedate)
        {
            BillModel data = new BillModel
            {
                BillName = billName,
                AmountDue = amount,
                DueDate = duedate,
                IsCurrent = true
            };
            
            string sql = $"sp_AddNewBill '{data.BillName}', '{data.AmountDue}', '{data.DueDate}'";
            UpdatePayments(data.AmountDue);
            //TODO (CAN I REMOVE THIS YET)impliment this AssignedBillProcessor.AssignBill(data, roommate);
            return SqlDataAccess.SaveData(sql, data);
        }

        public static List<BillModel> LoadBills()
        {
            string sql = "sp_GetAllBills";
            
            return SqlDataAccess.LoadData<BillModel>(sql);
        }


        public static List<AssignedBillViewModel> LoadBillsByAssigned()
        {
            string sql = "sp_GetRoommatesAssignedToBill";

            return SqlDataAccess.LoadData<AssignedBillViewModel>(sql);
        }



        public static void UpdatePayments(decimal newBill = 0)
        {
            var data = LoadBills();
            var numRoommates = RoommateProcessor.LoadRoommates().Count;
            decimal newPayments = newBill;
            foreach (var item in data)
            {
                newPayments += item.AmountDue;
            }
            newPayments /= numRoommates; //TODO this may need to go now too
            string sql = $"sp_UpdatePayment '{newPayments}'";
            SqlDataAccess.SaveData(sql, newPayments);
            
        }


        public static BillModel GetBillById(int id)
        {
            string sql = $"sp_GetBillById '{id}'";
            
            var data = SqlDataAccess.LoadData<BillModel>(sql);

            BillModel bill = new BillModel
            {
                BillName = data[0].BillName,
                AmountDue = data[0].AmountDue,
                DueDate = data[0].DueDate
                
            };
            return bill;
        }

        public static void DeleteBill(int id)
        {
            BillModel bill = new BillModel{
                ID = id,
            };

            var sql = $"sp_RemoveBill '{bill.ID}'";
            SqlDataAccess.SaveData<BillModel>(sql, bill);
            UpdatePayments();
        }

        public static void UpdateBill(string name, decimal amount, DateTime dueDate)
        {
            BillModel data = new BillModel
            {
                BillName = name,
                AmountDue = amount,
                DueDate = dueDate
            };
            string sql = $"sp_UpdateBill '{name}', '{amount}', '{dueDate}'";
            SqlDataAccess.SaveData<BillModel>(sql, data);
            UpdatePayments();
            
        }

    }
}

