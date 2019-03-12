using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using ExpenseCalculatorWebApi.ExpenseCalculatorDataAccess;
using System.Data.SqlClient;
using ExpenseCalculatorWebApi.BusinessObjects;
using ExpenseCalculatorWebApi.Common;

namespace ExpenseCalculator.Test
{
    [TestFixture]
    class ExpenseCalculatorMoqTest
    {
        //private IExpenseCalculatorRepository _expenseCalculatorRepository;
        //public ExpenseCalculatorMoqTest(IExpenseCalculatorRepository expenseCalculatorRepository)
        //{
        //    _expenseCalculatorRepository = new ExpenseCalculatorRepository();
        //}

        [TestCase]
        public void Test_CreateExpense()
        {
            bool recordInserted;
            var mock = new Mock<ExpenseCalculatorRepository>();
           

            //Player player = Player.CreateNewPlayer("Test", mock.Object);
            ExpenseData expenseData = new ExpenseData();
            expenseData.expenseTypeId = 1;
            expenseData.purchaseStoreId = 2;
            expenseData.expenseDate = Convert.ToDateTime("01/02/2017");
            expenseData.spentAmount = 290;
            recordInserted = mock.Object.CreateExpense(expenseData);

            //int result = helper.Add(20, 10);
            Assert.AreEqual(recordInserted, true);
            
        }
    }
}
