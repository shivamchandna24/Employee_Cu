using EmployeeManagement.Interfaces.Employee;
using EmployeeManagement.Models.Employee;
using EmployeeManagement.Services.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using EmployeeManagement.Helpers.EmployeeHelper;

namespace EmployeeManagement.Controllers.Employee
{
    public class EmployeeDelete
    {
        private IEmployeeDelete iEmployeeDelete { get; set; }
        public EmployeeDelete()
        {
            iEmployeeDelete = new EmployeeDeleteService();
        }

        public async void DeleteEmployee(int employeeId)//(EmployeeRequest employeeRequest)
        {
            try
            {
                EmployeeRequest employeeRequest = new EmployeeRequest()
                {
                    EmployeeId = employeeId
                };
                string responseStatus = string.Empty;
                responseStatus = await this.iEmployeeDelete.DeleteEmployee(employeeRequest.EmployeeId);

                MessageBox.Show($"Employee ID {employeeId} : {responseStatus}", "DELETE");
            }
            catch (Exception ) 
            {
                MessageBox.Show(EmployeeConstants.DeleteEmployee, EmployeeConstants.Exception);
            }
        }

        public async void DeleteEmployee_1(int employeeId)//(EmployeeRequest employeeRequest)
        {
            try
            {
                string? result = string.Empty;
                EmployeeRequest employeeRequest = new EmployeeRequest()
                {
                    EmployeeId = employeeId
                };
                DeleteEmployeeResponse? obj;
                var response = await this.iEmployeeDelete.DeleteEmployeeMember(employeeRequest.EmployeeId);
                if (response != null)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        result = await response.Content.ReadAsStringAsync();
                        obj = JsonConvert.DeserializeObject<DeleteEmployeeResponse>(result);
                        CreateMessage(obj);
                    }
                    else
                    {
                        obj = new DeleteEmployeeResponse();
                        obj.Message = Convert.ToString(response.StatusCode);
                    }
                   
                }
                else
                {
                    obj = new DeleteEmployeeResponse();
                    obj.Message = Convert.ToString(response.StatusCode);

                }
                MessageBox.Show($"Employee ID {employeeId} : {obj?.Message}", "DELETE");
            }
            catch (Exception)
            {
                MessageBox.Show(EmployeeConstants.DeleteEmployee, EmployeeConstants.Exception);
            }
        }

        private void CreateMessage(DeleteEmployeeResponse obj)
        {
            if ((obj.data == null && obj.code == 204) || obj.code == 200)
            {
                obj.Message = EmployeeConstants.SucessStatus;

            }
            else if (obj.code == 404)
            {
                obj.Message = EmployeeConstants.NotFound;
            }


        }
    }
}
