using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Net.Http.Headers;

using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using ExpenseCalculatorPresentation.ViewModel;
using Newtonsoft.Json;
using System.Globalization;
//using ExpenseCalculatorPresentation.Models;


namespace ExpenseCalculatorPresentation.Models
{
    public class ExpenseDataClient
    {
        private string _url;

        public ExpenseDataClient(string url)
        {
            _url = url;
        }
        public  List<ExpenseData> GetExpenses(DateTime startDate, DateTime endDate)
        {
            try
            {
                var client = new HttpClient();               
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
               
                var response = client.GetAsync(new Uri($"{_url}/GetExpenses?startDate={startDate.ToString("o", CultureInfo.InvariantCulture)}&endDate={endDate.ToString("o", CultureInfo.InvariantCulture)}")).Result;
               

                if (response.IsSuccessStatusCode)
                    return response.Content.ReadAsAsync<List<ExpenseData>>().Result;
                
                return null;
            }
            catch
            {
                return null;
            }
        }
        public ExpenseData GetExpenseDetails(int id)
        {
            try
            {
                var client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                
                var response = client.GetAsync(new Uri($"{_url}/GetExpenseDetails?id={id}")).Result;
                

                if (response.IsSuccessStatusCode)
                    return response.Content.ReadAsAsync<ExpenseData>().Result;

                return null;
            }
            catch
            {
                return null;
            }
        }


        public List<ExpenseData> GetExpenses(int expType, DateTime startDate, DateTime endDate)
        {
            try
            {
                var client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var url = $"{_url}/GetExpenses?expType={expType}&startDate={startDate.ToString("o", CultureInfo.InvariantCulture)}&endDate={endDate.ToString("o", CultureInfo.InvariantCulture)}";
                var response = client.GetAsync(new Uri(url)).Result;

                if (response.IsSuccessStatusCode)
                    return response.Content.ReadAsAsync<List<ExpenseData>>().Result;
                return null;
            }
            catch
            {
                return null;
            }
        }
       
        public bool CreateExpense(ExpenseData expensedata)        
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(_url);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var stringContent = new StringContent(JsonConvert.SerializeObject(expensedata), Encoding.UTF8, "application/json");
                //HttpResponseMessage response = client.PostAsync("CreateExpense", stringContent).Result;
                HttpResponseMessage response = client.PostAsync(new Uri($"{_url}/CreateExpense"), stringContent).Result;
               
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
        public bool UpdateExpense(ExpenseData expensedata)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(_url);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var stringContent = new StringContent(JsonConvert.SerializeObject(expensedata), Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PutAsync(new Uri($"{_url}/UpdateExpense"), stringContent).Result;
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteExpense(int id)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(_url);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.DeleteAsync(new Uri($"{_url}/DeleteExpense?id={id}")).Result;
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
        public List<ExpenseType> GetExpenseTypes()
        {
            try
            {
                var client = new HttpClient();
                //client.BaseAddress = new Uri(_url + "types");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync(new Uri($"{_url}/types")).Result;

                if (response.IsSuccessStatusCode)
                    return response.Content.ReadAsAsync<List<ExpenseType>>().Result;
                return null;
            }
            catch
            {
                return null;
            }
        }
    }
}
