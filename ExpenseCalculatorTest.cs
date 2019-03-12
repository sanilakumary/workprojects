using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseCalculatorWebApi.ExpenseCalculatorDataAccess;
using System.Data.SqlClient;
using ExpenseCalculatorWebApi.BusinessObjects;
using ExpenseCalculatorWebApi.Common;


namespace ExpenseCalculator.Test
{
    [TestFixture]
    public class ExpenseCalculatorTest 
    {

        private IExpenseCalculatorRepository _expenseCalculatorRepository;
        //public ExpenseCalculatorTest(IExpenseCalculatorRepository expenseCalculatorRepository)
        //{
        //    _expenseCalculatorRepository = expenseCalculatorRepository;
        //}

        public ExpenseCalculatorTest()
        {
            _expenseCalculatorRepository = new ExpenseCalculatorRepository();
        }
        [TestCase]
        public void CreateExpense()
        {
            bool recordInserted;
            ExpenseData expenseData = new ExpenseData();
            //expenseData.expenseDataId = 1;
            expenseData.expenseTypeId = 2;
            //expenseData.expenseTypeName = "Grocery";
            expenseData.expenseDate = Convert.ToDateTime("01/10/2017");
            expenseData.purchaseStoreId = 12;
            expenseData.spentAmount = 1200;
            recordInserted = _expenseCalculatorRepository.CreateExpense(expenseData);
            
            //int result = helper.Add(20, 10);
            Assert.AreEqual(recordInserted, true);
        }
    }
}
