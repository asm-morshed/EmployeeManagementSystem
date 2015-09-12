using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using EmployeeManagement.DLL.Gateway;

namespace EmployeeManagement.UI
{
    public partial class EmployeeInformation : Form
    {
        public string EmployeeId;
        public object returnValue;

        public EmployeeInformation()
        {
            InitializeComponent();
        }
        DBGateway aDbgateway = new DBGateway();
        private void btnAddEmployee_Click(object sender, EventArgs e)
        {

            
            SqlConnection cn = new SqlConnection(@"server=.\sqlexpress;Initial Catalog=EmployeeManagementDB;Integrated Security=true");
            SqlCommand cmd = new SqlCommand();
            
            cmd.CommandText = "select Max(id) from tbl_employee";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cn;
            cn.Open();
            returnValue = cmd.ExecuteScalar();
            int value=(int)returnValue;
            cn.Close();
            AddEmployee addEmployee = new AddEmployee();
            addEmployee.txtEmployeeId.Text = "Emp-01-" + returnValue.ToString();
            
            addEmployee.Show();
            
        }

        
        

        private void btnPaymentInfo_Click(object sender, EventArgs e)
        {
            PaySystem paySystem = new PaySystem();
            paySystem.Show();

        }

        private void btnLeave_Click(object sender, EventArgs e)
        {
            Leave leave = new Leave();
            leave.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
