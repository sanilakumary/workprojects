using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseCalculatorWebApi.Common
{
   public  class Utilities
    {
        public static void HandleError(Exception exception)
        {
            //ExceptionPolicy.HandleException(exception, "Log Only Policy");
        }
    }
}
