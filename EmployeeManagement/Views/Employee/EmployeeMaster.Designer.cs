namespace EmployeeManagement.Views.Employee
{
    partial class EmployeeMaster
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            gbSelectEmployeeOperation = new GroupBox();
            btnSearch = new Button();
            btnDeleteEmployeeMaster = new Button();
            btnCreateEmploye = new Button();
            btnUpdateEmployeeMaster = new Button();
            gbSelectEmployeeOperation.SuspendLayout();
            SuspendLayout();
            // 
            // gbSelectEmployeeOperation
            // 
            gbSelectEmployeeOperation.Controls.Add(btnUpdateEmployeeMaster);
            gbSelectEmployeeOperation.Controls.Add(btnSearch);
            gbSelectEmployeeOperation.Controls.Add(btnDeleteEmployeeMaster);
            gbSelectEmployeeOperation.Controls.Add(btnCreateEmploye);
            gbSelectEmployeeOperation.Location = new Point(96, 51);
            gbSelectEmployeeOperation.Name = "gbSelectEmployeeOperation";
            gbSelectEmployeeOperation.Size = new Size(1038, 204);
            gbSelectEmployeeOperation.TabIndex = 0;
            gbSelectEmployeeOperation.TabStop = false;
            gbSelectEmployeeOperation.Text = "Select Operation";
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(63, 141);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(265, 34);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "Search ";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnDeleteEmployeeMaster
            // 
            btnDeleteEmployeeMaster.Location = new Point(442, 69);
            btnDeleteEmployeeMaster.Name = "btnDeleteEmployeeMaster";
            btnDeleteEmployeeMaster.Size = new Size(265, 34);
            btnDeleteEmployeeMaster.TabIndex = 1;
            btnDeleteEmployeeMaster.Text = "Delete Employee";
            btnDeleteEmployeeMaster.UseVisualStyleBackColor = true;
            btnDeleteEmployeeMaster.Click += btnDeleteEmployeeMaster_Click;
            // 
            // btnCreateEmploye
            // 
            btnCreateEmploye.Location = new Point(63, 69);
            btnCreateEmploye.Name = "btnCreateEmploye";
            btnCreateEmploye.Size = new Size(234, 34);
            btnCreateEmploye.TabIndex = 0;
            btnCreateEmploye.Text = "Create Employee";
            btnCreateEmploye.UseVisualStyleBackColor = true;
            btnCreateEmploye.Click += btnCreateEmploye_Click;
            // 
            // btnUpdateEmployeeMaster
            // 
            btnUpdateEmployeeMaster.Location = new Point(442, 141);
            btnUpdateEmployeeMaster.Name = "btnUpdateEmployeeMaster";
            btnUpdateEmployeeMaster.Size = new Size(265, 34);
            btnUpdateEmployeeMaster.TabIndex = 3;
            btnUpdateEmployeeMaster.Text = "Update";
            btnUpdateEmployeeMaster.UseVisualStyleBackColor = true;
            btnUpdateEmployeeMaster.Click += btnUpdateEmployeeMaster_Click;
            // 
            // EmployeeMaster
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1233, 579);
            Controls.Add(gbSelectEmployeeOperation);
            Name = "EmployeeMaster";
            Text = "EmployeeMaster";
            gbSelectEmployeeOperation.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox gbSelectEmployeeOperation;
        private Button btnCreateEmploye;
        private Button btnDeleteEmployeeMaster;
        private Button btnSearch;
        private Button btnUpdateEmployeeMaster;
    }
}