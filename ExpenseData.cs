﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExpenseCalculatorPresentation.Models
{
    public class ExpenseData
    {
        public int expenseDataId { get; set; }
        public int expenseTypeId { get; set; }
        public String expenseTypeName { get; set; }
        public int purchaseStoreId { get; set; }
        public String purchaseStoreName { get; set; }
        public DateTime expenseDate { get; set; }
        public Double spentAmount { get; set; }
    }
}