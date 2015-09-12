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

using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace EmployeeManagement.UI
{
    public partial class Leave : Form
    {
        
        public Leave()
        {
            InitializeComponent();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }
        private string EmployeeId = "";
        private Employee anEmployee = new Employee();
        private EmployeeManager employeeManager = new EmployeeManager();
        private void btnSearch_Click(object sender, EventArgs e)
        {
            EmployeeId = txtSearchEmployee.Text;
            LoadName(EmployeeId);
        }
        private void LoadName(string EmpId)
        {
            //int sum = 0;
            anEmployee = new Employee();
            anEmployee = employeeManager.GetEmployee(EmpId);
            //anEmployee = employeeManager.GetEmployee(txtSearchEmployee.Text);
            txtEmployeeId.Text = anEmployee.Id;
            txtEmployeeName.Text = anEmployee.Name;
            txtFatherName.Text = anEmployee.FatherName;
            txtDepartment.Text = anEmployee.Department.Title;
            txtDesignation.Text = anEmployee.Designation.Title;
            txtLeaveExist.Text = anEmployee.NumberOfLeave;
            //txtBasic.Text = anEmployee.Basic.ToString();
            //txtMedical.Text = anEmployee.Medical.ToString();
            //txtHome.Text = anEmployee.Home.ToString();
            //txtOthers.Text = anEmployee.Others.ToString();
            //sum = Convert.ToInt32(anEmployee.Basic) + Convert.ToInt32(anEmployee.Medical) + Convert.ToInt32(anEmployee.Home) + Convert.ToInt32(anEmployee.Others);
            //txtTotal.Text = sum.ToString();
            string imageName = anEmployee.ImagePath;


            //+anEmployee.ImagePath;

            Bitmap bmp = new Bitmap(@"D:\MY Work\EmployeeManagement\EmployeeManagement\Images\" + imageName);
            pictureBox1.Image = bmp;

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            DateTime d1 = dateTimePicker1.Value.Date;
            DateTime d2 = dateTimePicker2.Value.Date;
            TimeSpan diff = d2.Subtract(d1);
            txtTotalLeave.Text = diff.Days.ToString();
            int lexit=Convert.ToInt32(txtLeaveExist.Text)-Convert.ToInt32(txtTotalLeave.Text);
            txtLeaveExist.Text = lexit.ToString();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            employeeManager.UpdateLeave(txtEmployeeId.Text, txtLeaveExist.Text);
            Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
            PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream(@"D:\MY Work\EmployeeManagement\EmployeeManagement\Leave-" + txtEmployeeId.Text + ".pdf", FileMode.Create));
            doc.Open();

            iTextSharp.text.Image png = iTextSharp.text.Image.GetInstance(@"D:\MY Work\EmployeeManagement\EmployeeManagement\Images\" + txtEmployeeId.Text + ".png");
            //png.ScalePercent(30f);
            png.ScaleToFit(250f, 2500f);

            png.SetAbsolutePosition(doc.PageSize.Width - 110f - 170f, doc.PageSize.Height - 36f - 216.6f);
            doc.Add(png);
            

            Paragraph paragraph = new Paragraph("Employee Id:\t" + txtEmployeeId.Text +
                "\nName:" + txtEmployeeName.Text +
                "\nFather Name:" + txtFatherName.Text +
                "\nDesignation:" + txtDesignation.Text +
                "\nDepartment: " + txtDepartment.Text +
                "\n\n\n"+txtMessage.Text);
            doc.Add(paragraph);

            doc.Close();
            MessageBox.Show("Pdf created");
            this.Hide();
        }
    }
}
