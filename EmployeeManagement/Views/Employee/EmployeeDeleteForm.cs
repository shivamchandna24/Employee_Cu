using EmployeeManagement.Controllers.Employee;
using EmployeeManagement.Helpers;
using EmployeeManagement.Helpers.EmployeeHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeManagement.Views.Employee
{
    public partial class EmployeeDeleteForm : Form
    {

        public EmployeeDeleteForm()
        {
            InitializeComponent();
        }

        private void btnDeleteReset_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void btnEmployeeDelete_Click(object sender, EventArgs e)
        {
            string message = string.Empty;
            if (IsFormValid())
            {
                EmployeeDelete employeeDelete = new EmployeeDelete();
                employeeDelete.DeleteEmployee(Convert.ToInt32(txtDeleteEmployeeId.Text.ToString()));
                //employeeDelete.Delete(Convert.ToInt32(txtDeleteEmployeeId.Text.ToString()));
                txtDeleteEmployeeId.Enabled = false;
            }
            else
            {
                MessageBox.Show(EmployeeConstants.InvalidEmployeeId, EmployeeConstants.Validation);
            }
        }

        private void ClearForm()
        {
            txtDeleteEmployeeId.Text = string.Empty;
            txtDeleteEmployeeId.Enabled = true;
        }
        private bool IsFormValid()
        {
            return CommonHelper.IsValidInt(txtDeleteEmployeeId.Text.ToString());
        }

    }
}
