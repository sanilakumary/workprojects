
using System.Web.Mvc;
using ExpenseCalculatorPresentation.ViewModel;
using ExpenseCalculatorPresentation.Models;
using System.Configuration;
using System;
using System.Globalization;
using System.Collections;
using System.Collections.Generic;

namespace ExpenseCalculatorPresentation.Controllers
{
    public class ExpenseCalculatorController : Controller
    {
        // GET: ExpenseCalculatorView
        private string _url = ConfigurationManager.AppSettings["Url"].ToString();
        public ActionResult Home()
        {
            return View("Home");
        }
        public ActionResult Index()
        {
            var model = new ExpenseCalculatorViewModel();
            var expenseTypeClient = new ExpenseDataClient(_url);
            model.ExpenseTypes = expenseTypeClient.GetExpenseTypes();
            
            var storeClient = new StoreClient();
            model.Stores = storeClient.GetStores(); 

            return View("Index",model);
        }
       
        [HttpGet]
        public ActionResult Get()
        {
            return View("Details");
        }
        [HttpPost]
        public ActionResult GetExpenses()
        {
            CultureInfo ci = CultureInfo.InvariantCulture;            
            var model = new ExpenseDataViewModel();
            
            var startDate = new DateTime();
            var endDate = new DateTime();
            startDate = Convert.ToDateTime(Request.Form["StartDate"]).ToUniversalTime();
            endDate = Convert.ToDateTime(Request.Form["EndDate"]).ToUniversalTime();
            var expenseDataClient = new ExpenseDataClient(_url);
            model.ExpenseDatas = expenseDataClient.GetExpenses(startDate, endDate);
            return View("Details",model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View("Create");
        }
        [HttpPost]
        public ActionResult Create(ExpenseCalculatorViewModel model)
        {
            var expenseDataClient = new ExpenseDataClient(_url);
            model.ExpenseDatas.expenseTypeId = Convert.ToInt32(Request.Form["ddlExpense"]);
            model.ExpenseDatas.purchaseStoreId = Convert.ToInt32(Request.Form["ddlStores"]);
            expenseDataClient.CreateExpense(model.ExpenseDatas);
            ViewBag.result = "Record Inserted Successfully!";
            return RedirectToAction("Index");
        }

        
       
       
        public ActionResult Delete(int id)
        {
            var expenseDataClient = new ExpenseDataClient(_url);
            expenseDataClient.DeleteExpense(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var expenseDataClient = new ExpenseDataClient(_url);
            var model = new ExpenseCalculatorViewModel();
            
            model.ExpenseTypes = expenseDataClient.GetExpenseTypes();
            var storeClient = new StoreClient();
            model.Stores = storeClient.GetStores();
            model.ExpenseDatas = expenseDataClient.GetExpenseDetails(id);
            return View("Edit", model);
        }
        [HttpPost]
        public ActionResult Edit(ExpenseCalculatorViewModel model)
        {

            var expenseDataClient = new ExpenseDataClient(_url);
            model.ExpenseDatas.expenseDataId = Convert.ToInt32(Request.Form["ExpenseDataId"]);
            model.ExpenseDatas.expenseTypeId = Convert.ToInt32(Request.Form["ExpenseTypeId"]);
            model.ExpenseDatas.purchaseStoreId = Convert.ToInt32(Request.Form["PurchaseStoreId"]);            
            model.ExpenseDatas.expenseDate = Convert.ToDateTime(Request.Form["DateofExpense"]).ToUniversalTime();
            model.ExpenseDatas.spentAmount = Convert.ToInt32(Request.Form["spentAmount"]);
            expenseDataClient.UpdateExpense(model.ExpenseDatas);
            return RedirectToAction("Index");
        }
        
    }
}
