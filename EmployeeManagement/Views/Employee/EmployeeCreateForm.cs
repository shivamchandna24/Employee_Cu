﻿using EmployeeManagement.Controllers.Employee;
using EmployeeManagement.Helpers;
using EmployeeManagement.Helpers.EmployeeHelper;
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

namespace EmployeeManagement.Views.Employee
{
    public partial class EmployeeCreateForm : Form
    {
        public EmployeeCreateForm()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (!IsValidForm())
            {
                return;
            }
            EmployeeRequest createFormData = MapFormData();
            EmployeeCreate controller = new EmployeeCreate();
            controller.CreateNewEmployee(createFormData);
            DisableFields();
        }



        private void DisableFields()
        {
            btnCreate.Enabled = false;
        }
        private EmployeeRequest MapFormData()
        {
            return new EmployeeRequest
            {
                EmployeeId = 0,
                Name = txtName.Text.ToString(),
                Email = txtEmail.Text.ToString(),
                Gender = cbGender.Text.ToString(),
                Status = rbActive.Text.ToString()
            };

        }
        private void btnResetCreateEmployee_Click(object sender, EventArgs e)
        {
            ResetForm();
        }
        private void ResetForm()
        {
            txtEmployeeId.Text = "";
            txtEmail.Text = string.Empty;
            txtName.Text = string.Empty;
            cbGender.Text = string.Empty;
            btnCreate.Enabled = true;

        }

        private bool IsValidForm()
        {
            if (!CommonHelper.IsNotEmptyText(txtName.Text.ToString()))
            {
                MessageBox.Show(EmployeeConstants.InvalidName, EmployeeConstants.Validation);
                return false;
            }
            else if (!CommonHelper.IsNotEmptyText(txtEmail.Text.ToString()))
            {
                MessageBox.Show(EmployeeConstants.InvalidEmail, EmployeeConstants.Validation);
                return false;
            }
            else if (!CommonHelper.IsValidEmail(txtEmail.Text.ToString()))
            {
                MessageBox.Show(EmployeeConstants.InvalidEmail, EmployeeConstants.Validation);
                return false;
            }
            else if (!CommonHelper.IsValueSelected(cbGender))
            {
                MessageBox.Show(EmployeeConstants.InvalidGender, EmployeeConstants.Validation);
                return false;
            }
            else
            {
                return true;
            }

        }

    }
}
