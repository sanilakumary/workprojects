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
    public class ExpenseCalculatorController : ApiController
    {
        private IExpenseCalculator _expenseCalculator = new ExpenseCalculator(new ExpenseCalculatorRepository());
           
            
        [HttpGet]
        public List<ExpenseData> GetExpenses(DateTime startDate, DateTime endDate)
        {
            List<ExpenseData> expenseCollection = new List<ExpenseData>();

            try
            {
                expenseCollection = _expenseCalculator.GetExpenses(startDate, endDate);

            }
            catch (ApplicationException ex)
            {
                throw new HttpResponseException(new HttpResponseMessage { StatusCode = HttpStatusCode.BadRequest, ReasonPhrase = ex.Message });
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(new HttpResponseMessage { StatusCode = HttpStatusCode.BadGateway, ReasonPhrase = ex.Message });
            }

            return expenseCollection;

        }

        [HttpGet]
        public List<ExpenseData> GetExpenses(int expType, DateTime startDate, DateTime endDate)
        {
            List<ExpenseData> expenseCollection = new List<ExpenseData>();

            try
            {
                expenseCollection = _expenseCalculator.GetExpenses(expType, startDate, endDate);

            }
            catch (ApplicationException ex)
            {
                throw new HttpResponseException(new HttpResponseMessage { StatusCode = HttpStatusCode.BadRequest, ReasonPhrase = ex.Message });
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(new HttpResponseMessage { StatusCode = HttpStatusCode.BadGateway, ReasonPhrase = ex.Message });
            }

            return expenseCollection;

        }
        [HttpGet]
       public ExpenseData GetExpenseDetails(int id)
        {
            ExpenseData expenseData = new ExpenseData();
            try
            {
                expenseData = _expenseCalculator.GetExpenseDetails(id);

            }
            catch (ApplicationException ex)
            {
                throw new HttpResponseException(new HttpResponseMessage { StatusCode = HttpStatusCode.BadRequest, ReasonPhrase = ex.Message });
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(new HttpResponseMessage { StatusCode = HttpStatusCode.BadGateway, ReasonPhrase = ex.Message });
            }

            return expenseData;

        }
        [HttpPost]
        public bool CreateExpense(ExpenseData expData)
        {
            try
            {
               return _expenseCalculator.CreateExpense(expData);

            }
            catch (ApplicationException ex)
            {
                throw new HttpResponseException(new HttpResponseMessage { StatusCode = HttpStatusCode.BadRequest, ReasonPhrase = ex.Message });
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(new HttpResponseMessage { StatusCode = HttpStatusCode.BadGateway, ReasonPhrase = ex.Message });
            }
        }
        [HttpPut]
        public string UpdateExpense(ExpenseData expData)
        {
            try
            {
                return _expenseCalculator.UpdateExpense(expData);

            }
            catch (ApplicationException ex)
            {
                throw new HttpResponseException(new HttpResponseMessage { StatusCode = HttpStatusCode.BadRequest, ReasonPhrase = ex.Message });
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(new HttpResponseMessage { StatusCode = HttpStatusCode.BadGateway, ReasonPhrase = ex.Message });
            }

        }
        [HttpDelete]
        public string DeleteExpense(int id)
        {
            try
            {
                return _expenseCalculator.DeleteExpense(id);

            }
            catch (ApplicationException ex)
            {
                throw new HttpResponseException(new HttpResponseMessage { StatusCode = HttpStatusCode.BadRequest, ReasonPhrase = ex.Message });
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(new HttpResponseMessage { StatusCode = HttpStatusCode.BadGateway, ReasonPhrase = ex.Message });
            }

        }
        [Route("api/ExpenseCalculator/types")]
        [HttpGet]
        public List<ExpenseType> GetExpenseTypes()
        {
            List<ExpenseType> expenseTypeCollection = new List<ExpenseType>();

            try
            {
                expenseTypeCollection = _expenseCalculator.GetExpenseTypes();

            }
            catch (ApplicationException ex)
            {
                throw new HttpResponseException(new HttpResponseMessage { StatusCode = HttpStatusCode.BadRequest, ReasonPhrase = ex.Message });
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(new HttpResponseMessage { StatusCode = HttpStatusCode.BadGateway, ReasonPhrase = ex.Message });
            }

            return expenseTypeCollection;
        }
        //[HttpGet]
        //public List<Store> GetStores()
        //{
        //    List<Store> storeCollection = new List<Store>();

        //    try
        //    {
        //        storeCollection = _expenseCalculator.GetStores();

        //    }
        //    catch (ApplicationException ex)
        //    {
        //        throw new HttpResponseException(new HttpResponseMessage { StatusCode = HttpStatusCode.BadRequest, ReasonPhrase = ex.Message });
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new HttpResponseException(new HttpResponseMessage { StatusCode = HttpStatusCode.BadGateway, ReasonPhrase = ex.Message });
        //    }

        //    return storeCollection;
        //}
        //[HttpGet]
        //public List<ReportType> GetReportTypes()
        //{
        //    List<ReportType> reportCollection = new List<ReportType>();

        //    try
        //    {
        //        reportCollection = _expenseCalculator.GetReportTypes();

        //    }
        //    catch (ApplicationException ex)
        //    {
        //        throw new HttpResponseException(new HttpResponseMessage { StatusCode = HttpStatusCode.BadRequest, ReasonPhrase = ex.Message });
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new HttpResponseException(new HttpResponseMessage { StatusCode = HttpStatusCode.BadGateway, ReasonPhrase = ex.Message });
        //    }

        //    return reportCollection;
        //}
    }
}
