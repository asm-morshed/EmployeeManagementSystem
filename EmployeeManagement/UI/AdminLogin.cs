using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using EmployeeManagement.UI;

namespace EmployeeManagement.UI
{
    public partial class AdminLogin : Form
    {
        EmployeeInformation employeeInformatin = new EmployeeInformation();

        public AdminLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        
        {
            if (txtName.Text == "Admin" && txtPassword.Text == "admin")
            {
                this.Hide();
                employeeInformatin.Show();
                
            }
            else
            {
                MessageBox.Show("Your Information is wrong",@"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            
        }
    }
}
