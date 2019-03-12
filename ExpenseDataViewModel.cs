using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExpenseCalculatorPresentation.Models;

namespace ExpenseCalculatorPresentation.ViewModel
{
    public class ExpenseDataViewModel
    {
        public ExpenseData ExpenseData { get; set; }
        public List<ExpenseData> ExpenseDatas { get; set; }
    }
}