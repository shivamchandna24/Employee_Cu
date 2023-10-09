using EmployeeManagement.Interfaces.Employee;
using EmployeeManagement.Models.Employee;
using EmployeeManagement.Services.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Controllers.Employee
{
    public class EmployeeSearch
    {
        private IEmployeeSearch iEmployeeSearchService;
        public EmployeeSearch()
        {
            iEmployeeSearchService = new EmployeeSearchService();
        }

        public async Task<SearchEmployeeResponse> GetAllEmployees()
        {
            SearchEmployeeResponse searchEmployeeResponse =  await iEmployeeSearchService.GetEmployees();
            return searchEmployeeResponse;
        }
        public async Task<SearchEmployeeResponse> GetEmployeesByPagenumber(int pageNumber)
        {
            SearchEmployeeResponse searchEmployeeResponse = await iEmployeeSearchService.GetEmployeeByPagenumber(pageNumber);
            return searchEmployeeResponse;
        }
        public async Task<SingleEmployeeResponse> GetEmployeeById(int employeeId)
        {
            SingleEmployeeResponse searchEmployeeIdResponse = await iEmployeeSearchService.GetEmployeeById(employeeId);
            return searchEmployeeIdResponse;
        }

    }
}
