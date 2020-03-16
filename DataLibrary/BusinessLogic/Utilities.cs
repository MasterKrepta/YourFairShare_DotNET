using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataLibrary.BusinessLogic
{
    public static class Utilities
    {
        public static Action<int> OnBillPaid = (int id) => { };
    }
}