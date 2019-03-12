using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExpenseCalculatorPresentation.Models;
using System.Web.Mvc;
using System.Collections;

namespace ExpenseCalculatorPresentation.ViewModel
{
    public class ExpenseCalculatorViewModel
    { 
        public List<ExpenseType> ExpenseTypes { get; set; }
        public List<Store> Stores { get; set; }
        public ExpenseData ExpenseDatas { get; set; }
        public List<ExpenseData> ExpenseDataItems { get; set; }

        
        public SelectList Expenses { get; set; }

        public SelectList StoreDetails { get; set; }
        
    }
}