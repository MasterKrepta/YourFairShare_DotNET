using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace YFS_MVC.Controllers
{
    public class PaymentController : Controller
    {
        // GET: Payment
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListPayments()
        {
            return View();
        }

        public ActionResult AddPayment()
        {
            return View();
        }

        public ActionResult EditPayment()
        {
            return View();
        }
    }
}