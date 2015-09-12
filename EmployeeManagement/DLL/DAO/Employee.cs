using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.DLL.DAO
{
    class Employee
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string FatherName { get; set; }
        public string Gender { get; set; }
        public string DateOfBirth { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Contact { get; set; }
        public Designation Designation { get; set; }
        public Department Department { get; set; }
        public string Email { get; set; }
        public string DateOfJoining { get; set; }
        public string ImagePath { get; set; }
        public string Basic { get; set; }
        public string Medical { get; set; }
        public string Home { get; set; }
        public string Others { get; set; }
        public string NumberOfIncrement { get; set; }
        public string NumberOfLeave { get; set; }
    }
}
