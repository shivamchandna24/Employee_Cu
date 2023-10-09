using EmployeeManagement.Helpers.EmployeeHelper;
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
    public class EmployeeUpdateService : IEmployeeUpdate
    {
        public HttpClient ServiceClient { get; set; }
        private const string ACCESS_TOKEN = "0bf7fb56e6a27cbcadc402fc2fce8e3aa9ac2b40d4190698eb4e8df9284e2023";


        public EmployeeUpdateService() 
        {
            ServiceClient = new HttpClient();
            ServiceClient.BaseAddress = new Uri(ConfigurationManager.AppSettings["BaseUrl"].ToString());
            ServiceClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ACCESS_TOKEN);

        }
        public EmployeeUpdateService(bool isUnitTest)
        {
            ServiceClient = new HttpClient();
            ServiceClient.BaseAddress = new Uri("https://gorest.co.in/public-api/");
            ServiceClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ACCESS_TOKEN);

        }

        //public Task<EmployeeRequest> EditEmployee(EmployeeRequest employeeRequest)
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<HttpResponseMessage> UpdateEmployee(EmployeeRequest employeeRequest)
        {
            try
            {
                string result = string.Empty;
                string jsonString = JsonConvert.SerializeObject(employeeRequest);
                var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
                HttpResponseMessage httpResponseMessage = await this.ServiceClient.PutAsync("users/" + employeeRequest.EmployeeId.ToString(), content);
                return httpResponseMessage;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, EmployeeConstants.APIException);
                return null;
            }
          
        }

        //public Task<string> UpdateEmployee(EmployeeRequest employee)
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<SingleEmployeeResponse> GetEmployeeById(int employeeId)
        {
            var response = (await this.ServiceClient.GetAsync("users/" + employeeId.ToString())).Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<SingleEmployeeResponse?>(response.Result.ToString());

        }
    }
}
