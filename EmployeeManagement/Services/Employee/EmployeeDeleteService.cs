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
    public class EmployeeDeleteService : IEmployeeDelete
    {
        public HttpClient ServiceClient { get; set; }
        private const string ACCESS_TOKEN = "0bf7fb56e6a27cbcadc402fc2fce8e3aa9ac2b40d4190698eb4e8df9284e2023";

        public EmployeeDeleteService()
        {
            ServiceClient = new HttpClient();
            ServiceClient.BaseAddress = new Uri(Convert.ToString(ConfigurationManager.AppSettings["BaseUrl"]));
            ServiceClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ACCESS_TOKEN);
        }
        public EmployeeDeleteService(bool isUnitTest)
        {
            ServiceClient = new HttpClient();
            ServiceClient.BaseAddress = new Uri("https://gorest.co.in/public-api/");
            ServiceClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ACCESS_TOKEN);
        }
        public async Task<string> DeleteEmployee(int employeeId)
        {
            string result = string.Empty;
            HttpRequestMessage request = new HttpRequestMessage();
            request.RequestUri = new Uri(this.ServiceClient?.BaseAddress?.ToString() + "users/" + employeeId.ToString());
            request.Method = HttpMethod.Delete;
            var response = await this.ServiceClient.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsStringAsync();
                DeleteEmployeeResponse obj = JsonConvert.DeserializeObject<DeleteEmployeeResponse>(result);
                if (obj.data == null && obj.code == 204)
                {
                    result = EmployeeConstants.SucessStatus;
                }
                else if (obj.code == 404)
                {
                    result = EmployeeConstants.NotFound;
                }

            }
            return result;
        }

        public async Task<HttpResponseMessage> DeleteEmployeeMember(int empId)
        {
            HttpRequestMessage request = new HttpRequestMessage();
            request.RequestUri = new Uri(this.ServiceClient.BaseAddress.ToString() + "users/" + empId.ToString());
            request.Method = HttpMethod.Delete;
            return await this.ServiceClient.SendAsync(request);
        }
    }
}
