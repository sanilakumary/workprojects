﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExpenseCalculatorPresentation.Models;

namespace ExpenseCalculatorPresentation.ViewModel
{
    public class ReportViewModel
    {
        
        public List<ReportType> ReportTypes { get; set; }
        public List<ExpenseType> ExpenseTypes { get; set; }
        public List<ExpenseData> ExpenseData { get; set; }
        

    }
}
