using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Net.Http.Headers;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using ExpenseCalculatorPresentation.ViewModel;
using ExpenseCalculatorPresentation.Models;

namespace ExpenseCalculatorPresentation.Models
{
    public class StoreClient
    {
        
        private string _url = "http://localhost:9001/api/Store";
       
        public List<Store> GetStores()
        {
            try
            {
                HttpClient client = new HttpClient();
                
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync(new Uri($"{_url}/GetStores")).Result;
                if (response.IsSuccessStatusCode)
                    return response.Content.ReadAsAsync<List<Store>>().Result;               

                return null;
            }
            catch
            {
                return null;
            }
        }  }
}
