using System.Web.Mvc;
using ExpenseCalculatorPresentation.ViewModel;
using ExpenseCalculatorPresentation.Models;
using System.Configuration;
using System;
using System.Globalization;

namespace ExpenseCalculatorPresentation.Controllers
{
    public class ReportController : Controller
    {
        // GET: Report
        private string _url = ConfigurationManager.AppSettings["Url"].ToString();
        public ActionResult Index()
        {
            var model = new ReportViewModel();
            var reportTypeClient = new ReportClient();
            model.ReportTypes = reportTypeClient.GetReportTypes();
            var expenseTypeClient = new ExpenseDataClient(_url);
            model.ExpenseTypes = expenseTypeClient.GetExpenseTypes();
            return View ("GetReport",model);
            
        }

        [HttpPost]
        public ActionResult GetReports()
        {
            var model = new ReportViewModel();
            
            var startDate = new DateTime();
            var endDate = new DateTime();
            

            var expenseTypeId = Convert.ToInt32(Request.Form["ddlExpense"]);
            var reportType = Request.Form["ddlReport"];
            

            switch (reportType)
            {
                case "MM":
                    startDate = Convert.ToDateTime(DateTime.Now.Month.ToString() + "/1/" + DateTime.Now.Year.ToString());
                    endDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                    break;

                case "YY":
                    startDate = Convert.ToDateTime("1/1/" + DateTime.Now.Year.ToString());
                    endDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                    break;

                case "QQ":
                    startDate = Convert.ToDateTime(DateTime.Now.AddMonths(-3).Month.ToString() + "/1/" + DateTime.Now.Year.ToString());
                    endDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                    break;

                case "MD":
                    startDate = Convert.ToDateTime(DateTime.Now.Month.ToString() + "/1/" + DateTime.Now.Year.ToString());
                    endDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                    break;

                case "YD":
                    startDate = Convert.ToDateTime("1/1/" + DateTime.Now.Year.ToString());
                    endDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                    break;

                case "OO":
                    startDate = Convert.ToDateTime(Request.Form["StartDate"]).ToUniversalTime(); 
                    endDate = Convert.ToDateTime(Request.Form["EndDate"]).ToUniversalTime(); 
                    break;
                default:
                    throw new ArgumentException($"Report Type '{reportType}' not supported.");

            }

            var expenseDataClient = new ExpenseDataClient(_url);
            model.ExpenseData = expenseDataClient.GetExpenses(expenseTypeId, startDate, endDate);

            return View("Details", model);
            

        }
        
       
    }
}
