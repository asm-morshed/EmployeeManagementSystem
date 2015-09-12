using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EmployeeManagement.BLL;
using EmployeeManagement.DLL.Gateway;
using EmployeeManagement.DLL.DAO;

namespace EmployeeManagement.BLL
{
    class DepartmentManager
    {
         private DepartmentGateway departmentGateway = new DepartmentGateway();
        private string message;

        public string Save(Department aDepartment)
        {
            if (aDepartment.Title == string.Empty)
            {
                message = "Title is missing";
            }
            else if (aDepartment.Code == string.Empty)
            {
                message = "Code is missing";
            }
            else if (departmentGateway.HasThisDepartmentCode(aDepartment.Code))
            {
                message = "Designation Code is already Exist";
            }
            else if (departmentGateway.HasThisDepartmentTitle(aDepartment.Title))
            {
                message = "Designation Title is already Exist";
            }
            else
            {
                message = departmentGateway.SaveDept(aDepartment);
            }
            return message;
        }
        public List<Department> GetAll()
        {
            return departmentGateway.GetAll();
        }
    }
}
