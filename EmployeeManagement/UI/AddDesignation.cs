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
using EmployeeManagement.DLL.Gateway;
using EmployeeManagement.BLL;

namespace EmployeeManagement.UI
{
    public partial class AddDesignation : Form
    {
        private DesignationManager designationManager = new DesignationManager();
        public AddDesignation()
        {
            InitializeComponent();
        }

        private void SaveDesignationButton_Click(object sender, EventArgs e)
        {
            Designation aDesignatin = new Designation();
            aDesignatin.Code = txtCode.Text;
            aDesignatin.Title = txtTitle.Text;
            string message = (designationManager.Save(aDesignatin));
            MessageBox.Show(message, @"Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
