using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EmployeeManagement.DLL.DAO;
using EmployeeManagement.DLL.Gateway;

namespace EmployeeManagement.BLL
{
    class DesignationManager
    {
        private DesignationGateway designationGateway = new DesignationGateway();
        private string message;

        public string Save(Designation aDesignation)
        {
            if (aDesignation.Title == string.Empty)
            {
                message = "Title is missing";
            }
            else if (aDesignation.Code == string.Empty)
            {
                message = "Code is missing";
            }
            else if (designationGateway.HasThisDesignationCode(aDesignation.Code))
            {
                message = "Designation Code is already Exist";
            }
            else if (designationGateway.HasThisDesignationTitle(aDesignation.Title))
            {
                message = "Designation Title is already Exist";
            }
            else
            {
                message = designationGateway.Save(aDesignation);
            }
            return message;
        }
        public List<Designation> GetAll()
        {
            return designationGateway.GetAll();
        }
    }
}
