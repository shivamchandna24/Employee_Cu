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
    public class EmployeeCreateService : IEmployeeCreate
    {
        public HttpClient ServiceClient { get; set; }
        private const string ACCESS_TOKEN = "0bf7fb56e6a27cbcadc402fc2fce8e3aa9ac2b40d4190698eb4e8df9284e2023";

        public EmployeeCreateService()
        {
            ServiceClient = new HttpClient();
            ServiceClient.BaseAddress = new Uri(ConfigurationManager.AppSettings["BaseUrl"].ToString());
            ServiceClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ACCESS_TOKEN);
        }

        public EmployeeCreateService(bool unitTest)
        {
            ServiceClient = new HttpClient();
            ServiceClient.BaseAddress = new Uri("https://gorest.co.in/public/v2/");
            ServiceClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ACCESS_TOKEN);
        }

        public async Task<string> CreateNewEmployee(EmployeeRequest employeeRequest)
        {
            string jsonString = JsonConvert.SerializeObject(employeeRequest);
            string result = string.Empty;
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var response = await this.ServiceClient.PostAsync("users", content);
            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsStringAsync();
                CreateEmployeeResponse? obj = JsonConvert.DeserializeObject<CreateEmployeeResponse>(result);
                if (obj == null)
                    result = EmployeeConstants.SucessStatus;
                else
                {
                    result = obj.code == 201 ? EmployeeConstants.SucessStatus
                        : obj.code == 422 ? ("Please enter all employee information to create new Emplooyee. ") : obj.data.ToString();//objData.ToString()

                    employeeRequest.EmployeeId = (obj.code == 201) ? JsonConvert.DeserializeObject<EmployeeRequest>(obj.data.ToString()).EmployeeId : 0;
                }

            }
            return result;

            
        }

        //public async Task<HttpResponseMessage> CreateEmployee(EmployeeRequest employeeRequest)
        //{
        //    HttpResponseMessage response = new HttpResponseMessage();
        //    try
        //    {
        //        string jsonString = JsonConvert.SerializeObject(employeeRequest);
        //        string result = string.Empty;
        //        var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
        //        response = await this.ServiceClient.PostAsync("users", content);
        //        return response;
        //    }
        //    catch (Exception ex) 
        //    {
        //        MessageBox.Show(ex.Message, EmployeeConstants.APIException);
        //        return response;
        //    }
        //    finally 
        //    {
              
        //    }
        //}


       
    }
}
