using System.Collections.Generic;
using System.Web.Mvc;
using YFS_MVC.Models;
using YFS_MVC.ViewModels;
using static DataLibrary.BusinessLogic.BillProcessor;
using static DataLibrary.BusinessLogic.AssignedBillProcessor;
using DataLibrary.DataAccess;

namespace YFS_MVC.Controllers
{
    public class BillController : Controller
    {
        
        // GET: Bill
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewBills()
        {
            var billData = LoadBills();
            List<BillModel> bills = new List<BillModel>();
            foreach (var item in billData)
            {
                bills.Add(new BillModel
                {
                    ID = item.ID,
                    BillName = item.BillName,
                    Amount = item.AmountDue,
                    DueDate = item.DueDate, 
                    IsCurrent = item.IsCurrent
                });
            }
            return View(bills);
        }
        public ActionResult AddBill()
        {
            ViewBag.Message = "Add A New Bill";
            var data = DataLibrary.BusinessLogic.RoommateProcessor.LoadRoommates();
            var newBill = new BillModel();
            //TODO this might change
            foreach (var item in data)
            {
                newBill.Roommates.Add(new RoommateModel{
                    RoommateId = item.RoommateId,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    MonthlyPayment = item.MonthlyPayment,
                    IsSelected = false
                });;
            }

            return View(newBill);
        }


        public ActionResult ViewBillsWithAssigned()
        {
            var billData = LoadBills();
            var assignedRoommates = LoadBillsByAssigned();
            List<BillModel> bills = new List<BillModel>();
            
            foreach (var item in billData)
            {
                bills.Add(new BillModel
                {
                    ID = item.ID,
                    BillName = item.BillName,
                    Amount = item.AmountDue,
                    DueDate = item.DueDate,
                    IsCurrent = item.IsCurrent
                    
                }); ;
            }

            
            var final = new List<BillWithAssignedViewModel>();
            
            foreach (var b in bills)
            {
                
                var temp = new List<RoommateModel>();
                foreach (var r in assignedRoommates)
                {
                    if (r.BillName == b.BillName) //TODO this is kinda strange, refactor it to be done with SQL. 
                    {
                        temp.Add(new RoommateModel
                        {
                            RoommateId = r.RoommateId,
                            FirstName = r.FirstName,
                            LastName = r.LastName,
                            
                            
                        });
                        foreach (var payment in temp)
                        {
                            payment.MonthlyPayment = b.Amount / temp.Count; //TODO (Here is the bug!)think about where to track the payment due
                        }
                    }
                
                }

                final.Add(new BillWithAssignedViewModel
                {
                    Bill = b,
                    Roommates = temp
                }); ;

                //TODO Hacky and needs fixed
                foreach (var bill in final)
                {
                    bill.Bill.Roommates = bill.Roommates;
                }
            }

            return View(final);
            //return View(bills);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddBill(BillModel bill)
        {
            
            if (ModelState.IsValid)
            {
                int recordsCreated = CreateBill(
                                bill.BillName,
                                bill.Amount,
                                bill.DueDate);
                
                //TODO refactor this hacky code                
                string sql = $"sp_GetBillByName '{bill.BillName}'";
                var data = SqlDataAccess.LoadData<BillModel>(sql);
                bill.ID = data[0].ID;


                foreach (var r in bill.Roommates)
                {
                    if (r.IsSelected)
                    {
                        AssignBill(bill.ID, r.RoommateId);
                    }
                }

                return RedirectToAction("ViewBillsWithAssigned");
            }

            return View();
        }
        
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var data = GetBillById(id);
            BillModel model = new BillModel
            {
                ID = id,
                BillName = data.BillName,
                Amount = data.AmountDue,
                DueDate = data.DueDate

            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(BillModel model)
        {
            if (ModelState.IsValid)
            {
                DeleteBill(model.ID);
                UpdatePayments(model.Amount);
                return RedirectToAction("ViewBillsWithAssigned");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = GetBillById(id);
            //Todo should be mapping this to datalibrary model
            BillModel b = new BillModel
            {
                ID = data.ID,
                BillName = data.BillName,
                Amount = data.AmountDue,
                DueDate = data.DueDate
            };

            return View(b);
        }

        [HttpPost]
        public ActionResult Edit(BillModel model)
        {
            if (ModelState.IsValid)
            {
                UpdateBill(model.BillName, model.Amount, model.DueDate);
            }
            return RedirectToAction("ViewBillsWithAssigned");

        }

        
    }
}