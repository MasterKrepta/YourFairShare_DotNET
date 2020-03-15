using DataLibrary.DataAccess;
using DataLibrary.Models;
using DataLibrary.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.BusinessLogic
{
    public class AssignedBillProcessor
    {
        public static int AssignBill(int bill, int roommateId)
        {
            var data = new AssignedBillViewModel();
            
            
            string sql = $"sp_AssignBillToRoommate '{bill}', '{roommateId}'";
            
            return SqlDataAccess.SaveData(sql, data);
        }

        public static List<BillModel> LoadAssignedBills()
        {
            throw new NotImplementedException();
        }
    }
}
