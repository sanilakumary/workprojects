using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseCalculatorWebApi.BusinessObjects;
using ExpenseCalculatorWebApi.Common;
using System.Data;
using System.Data.Common;
using Common.Constants;

namespace ExpenseCalculatorWebApi.ExpenseCalculatorDataAccess
{
   public interface IExpenseCalculatorRepository
    {
        List<ExpenseData> GetExpenses(DateTime startDate, DateTime endDate);
        List<ExpenseData> GetExpenses(int expType, DateTime startDate, DateTime endDate);
        ExpenseData GetExpenseDetails(int id);
        bool CreateExpense(ExpenseData expData);
        String UpdateExpense(ExpenseData expData);
        String DeleteExpense(int id);
        List<ExpenseType> GetExpenseTypes();
        List<Store> GetStores();
        List<ReportType> GetReportTypes();

    }
}
