using EmployeeManagement.Helpers.EmployeeHelper;
using EmployeeManagement.Interfaces.Employee;
using EmployeeManagement.Models.Employee;
using EmployeeManagement.Services.Employee;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Controllers.Employee
{
    public class EmployeeCreate
    {
       
        public IEmployeeCreate iEmployeeCreate { get; set; }

        public EmployeeCreate()
        {
            iEmployeeCreate = new EmployeeCreateService();
        }

        public async void CreateNewEmployee(EmployeeRequest employeeRequest)
        {
            try
            {
                string result = string.Empty, message = string.Empty;
                var response = await this.iEmployeeCreate.CreateNewEmployee(employeeRequest);
                ShowMessage(employeeRequest.EmployeeId, message);
            }
            catch (Exception)
            {
                MessageBox.Show(EmployeeConstants.CreateEmployee, EmployeeConstants.Exception);
            }
            finally
            {

            }
        }

        private string CreateDisplayMessage(CreateEmployeeResponse responseObject)
        {
            if (responseObject == null)
            {
                return string.Empty;
            }
            else if (responseObject.code == 201 || responseObject.code == 204)
            {
                return EmployeeConstants.SucessStatus;
            }
            else if (responseObject.code == 422)
            {
                return EmployeeConstants.ValidationErrors;
            }
            else
            {
                return responseObject.data.ToString();
            }

           

        }

        private void ShowMessage(int employeeId, string message) 
        {
            if(employeeId>0)
            {
                MessageBox.Show($"Employee created with ID {employeeId}", "NEW");

            }
            else
            {
                MessageBox.Show($"New employee not created. Message from service - {message}","NEW");
            }


        }
    }
}
