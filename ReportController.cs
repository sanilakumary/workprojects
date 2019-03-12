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
    public class ReportController : ApiController
    {
        private IExpenseCalculator _expenseCalculator = new ExpenseCalculator(new ExpenseCalculatorRepository());
        [HttpGet]
        public List<ReportType> GetReportTypes()
        {
            List<ReportType> reportCollection = new List<ReportType>();

            try
            {
                reportCollection = _expenseCalculator.GetReportTypes();

            }
            catch (ApplicationException ex)
            {
                throw new HttpResponseException(new HttpResponseMessage { StatusCode = HttpStatusCode.BadRequest, ReasonPhrase = ex.Message });
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(new HttpResponseMessage { StatusCode = HttpStatusCode.BadGateway, ReasonPhrase = ex.Message });
            }

            return reportCollection;
        }
    }
}
