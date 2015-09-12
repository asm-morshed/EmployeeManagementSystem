using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

using EmployeeManagement.DLL.DAO;

namespace EmployeeManagement.DLL.Gateway
{
    class EmployeeGateway:DBGateway
    {
        public string Save(Employee anEmployee)
        {
            string message = "";
            try
            {
                SqlConnectionObj.Open();
                string query = String.Format("insert into tbl_Employee values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}')", anEmployee.Id, anEmployee.Name, anEmployee.FatherName, anEmployee.Gender, anEmployee.DateOfBirth, anEmployee.Address, anEmployee.City, anEmployee.Contact, anEmployee.Designation.Title, anEmployee.Department.Title, anEmployee.Email, anEmployee.DateOfJoining, anEmployee.Basic, anEmployee.Medical, anEmployee.Home, anEmployee.Others, anEmployee.ImagePath, anEmployee.NumberOfLeave, '0');
                SqlCommandObj.CommandText = query;
                SqlCommandObj.ExecuteNonQuery();
                message = "Employee: " + anEmployee.Name + " has been saved";
            }
            catch (Exception exception)
            {
                throw new Exception("Error!!!", exception);
            }
            finally
            {
                if (SqlConnectionObj != null && SqlConnectionObj.State == ConnectionState.Open)
                {
                    SqlConnectionObj.Close();
                }
            }
            return message;

        }

        public string Update(Employee anEmployee)
        {
            string message = "";
            try
            {
                SqlConnectionObj.Open();
                string query = String.Format("update tbl_Employee set Name='{0}',FatherName='{1}'", anEmployee.Name, anEmployee.FatherName);
                SqlCommandObj.CommandText = query;
                SqlCommandObj.ExecuteNonQuery();
                message = "Employee Information Updated.";
            }
            catch (Exception exception)
            {
                throw new Exception("Error!!!", exception);
            }
            finally
            {
                if (SqlConnectionObj != null && SqlConnectionObj.State == ConnectionState.Open)
                {
                    SqlConnectionObj.Close();
                }
            }
            return message;
        }

        private DesignationGateway designationGateway = new DesignationGateway();
        private DepartmentGateway departmentGateway = new DepartmentGateway();
        
        public Employee GetEmployeInfo(string empId)
        {
            Employee anEmployee=new Employee();
            SqlConnectionObj.Open();
            string query = String.Format("select * from tbl_Employee WHERE empId LIKE '%{0}%'", empId);
            SqlCommandObj.CommandText = query;
            SqlDataReader reader = SqlCommandObj.ExecuteReader();
            while (reader.Read())
            {
                anEmployee.Id = reader["empId"].ToString();
                anEmployee.Name = reader["name"].ToString();
                anEmployee.FatherName = reader["fathersName"].ToString();
                anEmployee.Designation =designationGateway.GetDesignation( reader["designation"].ToString());
                anEmployee.Department =departmentGateway.GetDepartment( reader["department"].ToString());
                anEmployee.Basic = reader["basicc"].ToString();
                anEmployee.Medical = reader["medical"].ToString();
                anEmployee.Home = reader["home"].ToString();
                anEmployee.Others = reader["others"].ToString();
                anEmployee.ImagePath = reader["imagePath"].ToString();
                anEmployee.NumberOfLeave = reader["numberOfLeave"].ToString();
            }
            SqlConnectionObj.Close();
            return anEmployee;
        }
        public Employee IncrementSalary(string empId, string salaryIncrement)
        {
            Employee anEmployee = new Employee();
            int basic, home, medical, others,salary,numberOfIncrement;
            SqlConnectionObj.Open();
            string query = String.Format("select * from tbl_Employee WHERE empId LIKE '%{0}%'", empId);
            SqlCommandObj.CommandText = query;
            SqlDataReader reader = SqlCommandObj.ExecuteReader();
            while (reader.Read())
            {
                anEmployee.Basic = reader["basicc"].ToString();
                anEmployee.Medical = reader["medical"].ToString();
                anEmployee.Home = reader["home"].ToString();
                anEmployee.Others = reader["others"].ToString();
                anEmployee.NumberOfIncrement = reader["numberOfIncrement"].ToString();
            }
            if (anEmployee.NumberOfIncrement == "")
            {
                numberOfIncrement = 1;
            }
            else
            {
                numberOfIncrement = Convert.ToInt32(anEmployee.NumberOfIncrement) + 1;
            }
            salary = Convert.ToInt32(salaryIncrement);
            basic = Convert.ToInt32(anEmployee.Basic);
            //Basic = basic;
            basic += (basic * salary)/100;
            home = Convert.ToInt32(anEmployee.Home);
            home = (basic * 15) / 100;
            medical = Convert.ToInt32(anEmployee.Medical);
            medical=(basic * 10) / 100;
            others = Convert.ToInt32(anEmployee.Others);
            others = (basic * 10) / 100;
            SqlConnectionObj.Close();
            SqlConnectionObj.Open();
            anEmployee.Basic = basic.ToString();
            anEmployee.Home = home.ToString();
            anEmployee.Medical = medical.ToString();
            anEmployee.Others = others.ToString();
            anEmployee.NumberOfIncrement = numberOfIncrement.ToString();
            //string Basic=basic.ToString();
            //string Home = home.ToString();
            //string Medical = medical.ToString();
            //string Others = others.ToString();
            query = String.Format("update tbl_Employee  set basicc='{0}',medical='{1}',home='{2}',others='{3}',numberOfIncrement='{4}' WHERE empId = '{5}'", basic.ToString(), medical.ToString(), home.ToString(), others.ToString(),numberOfIncrement.ToString(), empId);
            SqlCommandObj.CommandText = query;
            SqlCommandObj.ExecuteNonQuery();
            SqlConnectionObj.Close();
            //return "Salary Updated";
            return anEmployee;
        }
        public List<Employee> GetAllEmployee(string searchName)
        {
            List<Employee> employees = new List<Employee>();
            try
            {
                SqlConnectionObj.Open();
                string query = String.Format("select * from tbl_Employee");
                SqlCommandObj.CommandText = query;
                SqlDataReader reader = SqlCommandObj.ExecuteReader();
                while (reader.Read())
                {
                    Employee employee = new Employee();
                    employee.Id = reader["Id"].ToString();
                    employee.Name = reader["Name"].ToString();
                    //employee.Designation = designationGateway.GetDesignation(Convert.ToInt32(reader["DesignationId"]));
                    employees.Add(employee);
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Error!!!", exception);
            }
            finally
            {
                if (SqlConnectionObj != null && SqlConnectionObj.State == ConnectionState.Open)
                {
                    SqlConnectionObj.Close();
                }
            }
            return employees;
        }

        public string UpdateLeave(string empId, string leaveExist)
        {
            SqlConnectionObj.Open();
            string query = String.Format("update tbl_Employee  set numberOfLeave='{0}' WHERE empId = '{1}'", leaveExist, empId);
            SqlCommandObj.CommandText = query;
            SqlCommandObj.ExecuteNonQuery();
            SqlConnectionObj.Close();
            return "Updated";
        }
    }
}
