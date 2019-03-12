using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseCalculatorWebApi.BusinessObjects;
using ExpenseCalculatorWebApi.Common;
using Common.Constants;

namespace ExpenseCalculatorWebApi.ExpenseCalculatorBusinessLogic
{
   public interface IExpenseCalculator
    {
        List<ExpenseData> GetExpenses(DateTime startDate, DateTime endDate);
        List<ExpenseData> GetExpenses(int expType, DateTime startDate, DateTime endDate);
        ExpenseData GetExpenseDetails(int id);
        bool CreateExpense(ExpenseData expData);
        string UpdateExpense(ExpenseData expData);
        string DeleteExpense(int id);
        List<ExpenseType> GetExpenseTypes();
        List<Store> GetStores();
        List<ReportType> GetReportTypes();
    }
}
