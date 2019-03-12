using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ExpenseCalculatorWebApi.ExpenseCalculatorBusinessLogic;
using ExpenseCalculatorWebApi.BusinessObjects;
using ExpenseCalculatorWebApi.Common;
using ExpenseCalculatorWebApi.ExpenseCalculatorDataAccess;

namespace ExpenseCalculatorWebApi.Controllers
{
    public class StoreController : ApiController
    {
        private IExpenseCalculator _expenseCalculator = new ExpenseCalculator(new ExpenseCalculatorRepository());
        [HttpGet]
        public List<Store> GetStores()
        {
            List<Store> storeCollection = new List<Store>();

            try
            {
                storeCollection = _expenseCalculator.GetStores();

            }
            catch (ApplicationException ex)
            {
                throw new HttpResponseException(new HttpResponseMessage { StatusCode = HttpStatusCode.BadRequest, ReasonPhrase = ex.Message });
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(new HttpResponseMessage { StatusCode = HttpStatusCode.BadGateway, ReasonPhrase = ex.Message });
            }

            return storeCollection;
        }
    }
}
