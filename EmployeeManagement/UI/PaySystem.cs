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
    public partial class PaySystem : Form
    {
        public PaySystem()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private string EmployeeId = "";
        private Employee anEmployee=new Employee();
        private EmployeeManager employeeManager = new EmployeeManager();
        private void btnSearch_Click(object sender, EventArgs e)
        {
            
            EmployeeId = txtsearchEmployee.Text;
            //MessageBox.Show(EmployeeId);
            LoadName(EmployeeId);
            
        }
        private void LoadName(string EmpId)
        {
            int sum = 0;
            anEmployee = new Employee();
            anEmployee = employeeManager.GetEmployee(EmpId);
            anEmployee = employeeManager.GetEmployee(txtsearchEmployee.Text);
            txtEmployeeId.Text = anEmployee.Id;
            txtEmployeeName.Text = anEmployee.Name;
            txtFatherName.Text = anEmployee.FatherName;
            txtDepartment.Text = anEmployee.Department.Title;
            txtDesignation.Text = anEmployee.Designation.Title;
            txtBasic.Text = anEmployee.Basic.ToString();
            txtMedical.Text = anEmployee.Medical.ToString();
            txtHome.Text = anEmployee.Home.ToString();
            txtOthers.Text = anEmployee.Others.ToString();
            sum = Convert.ToInt32(anEmployee.Basic) + Convert.ToInt32(anEmployee.Medical) + Convert.ToInt32(anEmployee.Home) + Convert.ToInt32(anEmployee.Others);
            txtTotal.Text = sum.ToString();
            string imageName = anEmployee.ImagePath ;
        
            
            //+anEmployee.ImagePath;

            Bitmap bmp = new Bitmap(@"D:\MY Work\EmployeeManagement\EmployeeManagement\Images\"+imageName);
            pictureBox1.Image = bmp;
 
        }

        private void btnIncrease_Click(object sender, EventArgs e)
        {
            int total = 0;
            
            anEmployee = employeeManager.Increment(txtEmployeeId.Text, txtIncrement.Text);
            txtNumberOfIncre.Text = anEmployee.NumberOfIncrement;
            txtBasic.Text = anEmployee.Basic;
            txtMedical.Text = anEmployee.Medical;
            txtHome.Text = anEmployee.Home;
            txtOthers.Text = anEmployee.Others;

            total = Convert.ToInt32(anEmployee.Basic) + Convert.ToInt32(anEmployee.Medical) + Convert.ToInt32(anEmployee.Home) + Convert.ToInt32(anEmployee.Others);
            txtTotal.Text = total.ToString();
            btnIncrease.Visible = false;
            labelIncrease.Visible = true ;
            

        }

        private void btnTotal_Click(object sender, EventArgs e)
        {
            int total, bonus,totalSalary=0;
            total = Convert.ToInt32(txtTotal.Text);
            bonus = (Convert.ToInt32(txtBonous.Text)*total)/100;
            totalSalary = total + bonus;
            txtTotal.Text=total.ToString()+" + "+bonus.ToString()+" = "+totalSalary.ToString();
            btnTotal.Visible = false;
            labelTotal.Visible = true;
        
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
            PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream(@"D:\MY Work\EmployeeManagement\EmployeeManagement\Payment-"+txtEmployeeId.Text+".pdf", FileMode.Create));
            doc.Open();

            iTextSharp.text.Image png = iTextSharp.text.Image.GetInstance(@"D:\MY Work\EmployeeManagement\EmployeeManagement\Images\"+txtEmployeeId.Text+".png");
            //png.ScalePercent(30f);
            png.ScaleToFit(250f, 2500f);

            png.SetAbsolutePosition(doc.PageSize.Width -110f -170f,doc.PageSize.Height -36f -216.6f);
            doc.Add(png);

            Paragraph paragraph = new Paragraph("Employee Id:\t"+txtEmployeeId.Text+
                "\nName:"+txtEmployeeName.Text+
                "\nFather Name:"+txtFatherName.Text+
                "\nDesignation:"+txtDesignation.Text+
                "\nDepartment: "+txtDepartment.Text+
                "\nIncrement: "+txtIncrement.Text+
                "\nNo of Increment: "+txtNumberOfIncre.Text+
                "\nBasic: "+txtBasic.Text+
                "\nMedical: "+txtMedical.Text+
                "\nHome: "+txtHome.Text+
                "\nOthers:"+txtOthers.Text+
                "\nBonous:"+txtBonous.Text+
                "\nTotal: "+txtTotal.Text+
                "\n\n\n"+txtNotes.Text);
            doc.Add(paragraph);
            
            doc.Close();
            MessageBox.Show("Pdf created");
            this.Hide();
        }
    }
}
