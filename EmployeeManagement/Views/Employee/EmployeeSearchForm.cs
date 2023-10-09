using EmployeeManagement.Controllers.Employee;
using EmployeeManagement.Helpers;
using EmployeeManagement.Helpers.EmployeeHelper;
using EmployeeManagement.Interfaces.Employee;
using EmployeeManagement.Models.Employee;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace EmployeeManagement.Views.Employee
{
    public partial class EmployeeSearchForm : Form
    {
        EmployeeSearch searchEmployeeController;
        public EmployeeSearchForm()
        {
            InitializeComponent();
            HideControls();
            searchEmployeeController = new EmployeeSearch();
        }

        private async void btnSearchAll_Click(object sender, EventArgs e)
        {
            txtSearchText.Text = string.Empty; 
            SearchEmployeeResponse employeeData = await searchEmployeeController.GetAllEmployees();
            FillControls(employeeData);
        }
        private void FillPaginationFields(MetaData metaData)
        {
            txtTotalPage.Text = (metaData.pagination != null) ? metaData.pagination.pages.ToString() : string.Empty;
            txtCurrentPage.Text = (metaData.pagination != null) ? metaData.pagination.page.ToString() : string.Empty;
            txtTotalRecords.Text = (metaData.pagination != null) ? metaData.pagination.total.ToString() : string.Empty;
            txtLimitPerPage.Text = (metaData.pagination != null) ? metaData.pagination.limit.ToString() : string.Empty;
        }

        private void FillControls(SearchEmployeeResponse employeeData)
        {
            if (employeeData != null && employeeData.meta != null)
            {
                gbSearchData.Visible = true;
                FillPaginationFields(employeeData.meta);
            }
            if (employeeData?.data.Count > 0)
            {
               ResetGrid();
                dgvSearchRecords.DataSource = employeeData.data;
                MakeReadOnlyColumnsGrid();

            }
        }

        private async void btnGoToPage_Click(object sender, EventArgs e)
        {
            txtSearchText.Clear();
            if(!CommonHelper.IsValidInt(txtGoToPage.Text.ToString()))
            {
                MessageBox.Show(EmployeeConstants.InvalidPage, EmployeeConstants.Validation);
                return;
            }

            int goToPageNumber = Convert.ToInt32(txtGoToPage.Text.ToString());
            if(goToPageNumber < 1 || goToPageNumber > Convert.ToInt32(txtTotalPage.Text.ToString())) 
            {
                MessageBox.Show(EmployeeConstants.InvalidPageGreaterThanTotalPage, EmployeeConstants.Validation);
                return;
            }
            dgvSearchRecords.DataSource = null;
            SearchEmployeeResponse employeePageData = await searchEmployeeController.GetEmployeesByPagenumber(goToPageNumber);
            FillControls(employeePageData);
        }

        private void HideControls()
        {
            gbSearchData.Visible = false;
        }

        private async void btnSearchByID_Click(object sender, EventArgs e)
        {
            if (IsFormValid())
            {
                int employeeId = Convert.ToInt32(txtSearchText.Text.ToString());
                SingleEmployeeResponse employeeIDData = await searchEmployeeController.GetEmployeeById(employeeId);
                FillControlsForSingleResponse(employeeIDData);
            }
            else
            {
                MessageBox.Show(EmployeeConstants.InvalidEmployeeId, EmployeeConstants.Validation);
                return;
            }

        }

        private void FillControlsForSingleResponse(SingleEmployeeResponse employee)
        {
            if(employee != null) 
            {
                if(employee.meta != null) 
                {
                    FillPaginationFields(employee.meta);
                }
                else
                {
                    ResetPaginationFields();
                }
               
            }
            // Status
            ShowStatusMessageForSingleResponse(employee);
            

        }

        private void ShowStatusMessageForSingleResponse(SingleEmployeeResponse singleEmployeeResponse)
        {
            if (singleEmployeeResponse.code == 200)
            {
                
                List<EmployeeRequest> employeeData = new List<EmployeeRequest> { singleEmployeeResponse.data };
                if (employeeData.Count > 0)
                {
                    gbSearchData.Visible = true;
                }
                ResetGrid();
                dgvSearchRecords.DataSource = employeeData;
                MakeReadOnlyColumnsGrid();
            }
            else if(singleEmployeeResponse.code == 404)
            {
                MessageBox.Show($"Employee Id: {txtSearchText.Text} not found");
            }
        }
        
        private void ResetPaginationFields()
        {
            txtCurrentPage.Clear();
            txtGoToPage.Clear();
            txtLimitPerPage.Clear();
            txtTotalPage.Clear();
            txtTotalRecords.Clear();
        }

        private void ResetGrid()
        {
            dgvSearchRecords.DataSource = null;
            dgvSearchRecords.Rows.Clear();
            dgvSearchRecords.Columns.Clear();
            
        }
        
        private bool IsFormValid()
        {
            return CommonHelper.IsValidInt(txtSearchText.Text.ToString());
        }

        private void MakeReadOnlyColumnsGrid()
        {
            foreach (DataGridViewColumn column in dgvSearchRecords.Columns)
            {
                column.ReadOnly = true;
            }
        }
    }
}
