using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Constants;
using ExpenseCalculatorWebApi.BusinessObjects;
using ExpenseCalculatorWebApi.Common;
using ExpenseCalculatorWebApi.ExpenseCalculatorDataAccess;


namespace ExpenseCalculatorWebApi.ExpenseCalculatorBusinessLogic
{
  public  class ExpenseCalculator : IExpenseCalculator
    {
        private IExpenseCalculatorRepository _expenseCalculatorRepository;
        public ExpenseCalculator (IExpenseCalculatorRepository expenseCalculatorRepository)
        {
            _expenseCalculatorRepository = expenseCalculatorRepository;
        }
       public List<ExpenseData> GetExpenses(DateTime startDate, DateTime endDate)
        {
           return _expenseCalculatorRepository.GetExpenses(startDate,  endDate);
        }
        public List<ExpenseData> GetExpenses(int expType, DateTime startDate, DateTime endDate)
        {
            return _expenseCalculatorRepository.GetExpenses(expType, startDate, endDate);
        }
       public ExpenseData GetExpenseDetails(int id)
        {
            return _expenseCalculatorRepository.GetExpenseDetails(id);
        }
        public bool CreateExpense(ExpenseData expData)
        {
            return _expenseCalculatorRepository.CreateExpense(expData);
        }
        public string UpdateExpense(ExpenseData expData)
        {
           return  _expenseCalculatorRepository.UpdateExpense(expData);
        }
        public string DeleteExpense(int id)
        {
            return _expenseCalculatorRepository.DeleteExpense(id);
        }
        public List<ExpenseType> GetExpenseTypes()
        {
            return _expenseCalculatorRepository.GetExpenseTypes();
        }
        public List<Store> GetStores()
        {
            return _expenseCalculatorRepository.GetStores();
        }
        public List<ReportType> GetReportTypes()
        {
            return _expenseCalculatorRepository.GetReportTypes();
        }
    }
}
