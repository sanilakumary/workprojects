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
       

        [TestCase]
        public void Test_CreateExpense()
        {
            bool recordInserted;
            var mock = new Mock<ExpenseCalculatorRepository>();
           

           
            ExpenseData expenseData = new ExpenseData();
            expenseData.expenseTypeId = 1;
            expenseData.purchaseStoreId = 2;
            expenseData.expenseDate = Convert.ToDateTime("01/02/2017");
            expenseData.spentAmount = 290;
            recordInserted = mock.Object.CreateExpense(expenseData);

           
            Assert.AreEqual(recordInserted, true);
            
        }
    }
}
