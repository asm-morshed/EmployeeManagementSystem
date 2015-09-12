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
using System.Data.SqlClient;
using System.IO;

using EmployeeManagement.BLL;
using EmployeeManagement.DLL.DAO;
using EmployeeManagement.DLL.Gateway;

namespace EmployeeManagement
{
    public partial class AddEmployee : Form
    {
        EmployeeManager employeeManager = new EmployeeManager();
        DesignationManager designationManager = new DesignationManager();
        DepartmentManager departmentManger = new DepartmentManager();
        private string gender;
        public AddEmployee()
        {
            InitializeComponent();
            LoadAllDesignation();
            LoadAllDepartment();
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "JPG Files(*.jpg)|*.jpg|PNG Files(*.png)|*.png|All Files(*.*)|*.*";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string picLoc = dlg.FileName.ToString();
                txtImageLocation.Text = picLoc;
                //pictureBoxImage.ImageLocation = picLoc;
                string imageLoc = txtImageLocation.Text;
                Bitmap bmp = new Bitmap(@imageLoc);
                pictureBoxImage.Image = bmp;

                

                //Bitmap bmp = new Bitmap("picLoc");
                picLoc = txtEmployeeId.Text;
                bmp.Save("D:\\MY Work\\EmployeeManagement\\EmployeeManagement\\Images\\"+picLoc+".png");

               // MessageBox.Show(picLoc);
            }
        }

        public void LoadAllDesignation()
        {
            try
            {
                cmbDesignation.DataSource = designationManager.GetAll();

                cmbDesignation.DisplayMember = "Title";
                cmbDesignation.ValueMember = "Id";
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void LoadAllDepartment()
        {
            try
            {
                cmbDepartment.DataSource = departmentManger.GetAll();

                cmbDepartment.DisplayMember = "Title";
                cmbDepartment.ValueMember = "Id";
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddDesignation_Click(object sender, EventArgs e)
        {
            AddDesignation addDesignation = new AddDesignation();
            addDesignation.Show();
        }

        private void btnAddDepartment_Click(object sender, EventArgs e)
        {
            AddDepartment addDepartment = new AddDepartment();
            addDepartment.Show();
        }
        private int basic,medical,home,others;
        private string Basic, Medical, Home, Others;
        private void salary()
        {
            basic =Convert.ToInt32( txtBasicSalary.Text);
            Basic = basic.ToString();
            medical = Convert.ToInt32(txtMedical.Text);
            medical = (basic * medical) / 100;
            Medical = medical.ToString();
            home = Convert.ToInt32(txtHome.Text);
            home = (basic * home) / 100;
            Home = home.ToString();
            others = Convert.ToInt32(txtOthers.Text);
            others = (basic * others) / 100;
            Others = others.ToString();
        }
        private void btnSaveSalaryinfo_Click(object sender, EventArgs e)
        {            
            salary();
            Employee anEmployee = new Employee();
            anEmployee.Id = txtEmployeeId.Text;
            anEmployee.Name = txtName.Text;
            anEmployee.FatherName = txtFatherName.Text;
            anEmployee.Gender = gender;
            anEmployee.DateOfBirth = dateOfBirth.Text;
            anEmployee.Address = txtAddress.Text;
            anEmployee.City = txtAddress.Text;
            anEmployee.Contact = txtConatct.Text;
            anEmployee.Department = (Department)cmbDepartment.SelectedItem;
            anEmployee.Designation = (Designation)cmbDesignation.SelectedItem;
            anEmployee.Email = txtEmail.Text;
            anEmployee.DateOfJoining = dateOfJoining.Text;
            anEmployee.ImagePath = txtEmployeeId.Text + ".png";
            anEmployee.Basic = Basic;
            anEmployee.Medical = Medical;
            anEmployee.Home = Home;
            anEmployee.Others = Others;
            anEmployee.NumberOfIncrement = "1";
            anEmployee.NumberOfLeave = "20";
      

            string message = employeeManager.Save(anEmployee);

            MessageBox.Show(message, @"Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
        }

        private void radioButtonMale_CheckedChanged(object sender, EventArgs e)
        {
            gender = "Male";
        }

        private void radioButtonFemale_CheckedChanged(object sender, EventArgs e)
        {
            gender = "Female";
            //MessageBox.Show(empIn.EmployeeId);
        }
    }
}
