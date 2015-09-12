using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EmployeeManagement.DLL.Gateway;
using EmployeeManagement.DLL.DAO;

namespace EmployeeManagement.BLL
{
    class EmployeeManager
    {
        private EmployeeGateway employeeGateway = new EmployeeGateway();
        private string message;
        public string Save(Employee anEmployee)
        {
            if (anEmployee.Name == string.Empty)
            {
                message = "Employee Name is missing";
            }
            else if (anEmployee.FatherName == string.Empty)
            {
                message = "Father Name is missing";
            }
            else if (anEmployee.Gender == string.Empty)
            {
                message = "Gender is missing";
            }
            else if (anEmployee.Address == string.Empty)
            {
                message = "Address is missing";
            }
            else if (anEmployee.City == string.Empty)
            {
                message = "City is missing";
            }
            else if (anEmployee.Contact == string.Empty)
            {
                message = "Contact is missing";
            }
           
            else if (anEmployee.Email == string.Empty)
            {
                message = "Email is missing";
            }
            else if (anEmployee.Basic == string.Empty)
            {
                message = "Basic is missing";
            }
            else if (anEmployee.Medical == string.Empty)
            {
                message = "Medical is missing";
            }
            else if (anEmployee.Home == string.Empty)
            {
                message = "Home is missing";
            }
            else if (anEmployee.Others == string.Empty)
            {
                message = "Others is missing";
            }
            else
            {
                message = employeeGateway.Save(anEmployee);
            }

            return message;
        }
        public Employee GetEmployee(string empid)
        {
            return employeeGateway.GetEmployeInfo(empid);
        }
        public Employee Increment(string empId,string increment)
        {
           return employeeGateway.IncrementSalary(empId, increment); 
        }
        public string UpdateLeave(string empId, string leaveExist)
        {
            return employeeGateway.UpdateLeave(empId, leaveExist);
        }
    }
}
