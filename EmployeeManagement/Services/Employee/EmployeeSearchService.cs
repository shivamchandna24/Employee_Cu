using EmployeeManagement.Interfaces.Employee;
using EmployeeManagement.Models.Employee;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Services.Employee
{
    public class EmployeeSearchService: IEmployeeSearch
    {
        public HttpClient ServiceClient { get; set; }
        private const string ACCESS_TOKEN = "0bf7fb56e6a27cbcadc402fc2fce8e3aa9ac2b40d4190698eb4e8df9284e2023";

        public EmployeeSearchService()
        {
            ServiceClient = new HttpClient();
            ServiceClient.BaseAddress = new Uri(ConfigurationManager.AppSettings["BaseUrl"].ToString());
            ServiceClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ACCESS_TOKEN);

        }

        public EmployeeSearchService(bool isUnitTest)
        {
            ServiceClient = new HttpClient();
            ServiceClient.BaseAddress = new Uri("https://gorest.co.in/public-api/");
            ServiceClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ACCESS_TOKEN);

        }

        public async Task<SearchEmployeeResponse> GetEmployees()
        {
            var response = (await this.ServiceClient.GetAsync("users")).Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<SearchEmployeeResponse>(response?.Result.ToString());
            
        }

        public async Task<SearchEmployeeResponse> GetEmployeeByPagenumber(int pageNumber)
        {
            var response = (await this.ServiceClient.GetAsync("users?page=" + pageNumber.ToString())).Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<SearchEmployeeResponse>(response.Result?.ToString());
        }

        public async Task<SingleEmployeeResponse> GetEmployeeById(int employeeId)
        {
            var response = (await this.ServiceClient.GetAsync("users/" + employeeId.ToString())).Content.ReadAsStringAsync();
            return  JsonConvert.DeserializeObject<SingleEmployeeResponse?>(response.Result.ToString());
            
        }
    }
}
