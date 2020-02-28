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
using System.Net.Http.Formatting;

namespace ExpenseCalculatorPresentation.Models
{
    public class ReportClient
    {
        


        private string _url = "http://localhost:61978/api/Report";

        
        public List<ReportType> GetReportTypes()
        {
            try
            {
                
                var client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync(new Uri($"{_url}/GetReportTypes")).Result;

                if (response.IsSuccessStatusCode)
                    return response.Content.ReadAsAsync<List<ReportType>>().Result;

                return null;
            }
            catch
            {
                return null;
            }
        }

    }
}
