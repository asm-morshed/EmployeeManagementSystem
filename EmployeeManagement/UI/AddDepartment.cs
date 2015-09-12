using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using EmployeeManagement.DLL.DAO;
using EmployeeManagement.BLL;

namespace EmployeeManagement.UI
{
    public partial class AddDepartment : Form
    {
        private DepartmentManager departmentManager = new DepartmentManager();
        public AddDepartment()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            Department aDepartment = new Department();
            aDepartment.Code = txtCode.Text;
            aDepartment.Title = txtTitle.Text;
            string message = (departmentManager.Save(aDepartment));
            MessageBox.Show(message, @"Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
