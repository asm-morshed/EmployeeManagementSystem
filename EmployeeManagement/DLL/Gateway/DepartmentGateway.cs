using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data;
using EmployeeManagement.DLL.DAO;

namespace EmployeeManagement.DLL.Gateway
{
    class DepartmentGateway : DBGateway
    {
        private Department aDepartment = new Department();
        public string SaveDept(Department aDepartment)
        {
            string message = "";
            try
            {
                SqlConnectionObj.Open();
                string query = String.Format("insert into tbl_Department values ('{0}','{1}')", aDepartment.Code, aDepartment.Title);
                SqlCommandObj.CommandText = query;
                SqlCommandObj.ExecuteNonQuery();
                message = "Department Saved";
            }
            catch (Exception exception)
            {
                throw new Exception("Errordgdfgdfgdfg!!", exception);
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

        public bool HasThisDepartmentTitle(string title)
        {
            try
            {
                SqlConnectionObj.Open();
                string query = String.Format("select * from tbl_Department where Title='{0}'", title);
                SqlCommandObj.CommandText = query;
                SqlDataReader reader = SqlCommandObj.ExecuteReader();
                if (reader != null)
                {
                    return reader.HasRows;
                }
                return false;
            }
            catch (Exception exception)
            {
                throw new Exception("Error!!", exception);
            }
            finally
            {
                if (SqlConnectionObj != null && SqlConnectionObj.State == ConnectionState.Open)
                {
                    SqlConnectionObj.Close();
                }
            }
        }
        public bool HasThisDepartmentCode(string code)
        {
            try
            {
                SqlConnectionObj.Open();
                string query = String.Format("select * from tbl_Department where Code='{0}'", code);
                SqlCommandObj.CommandText = query;
                SqlDataReader reader = SqlCommandObj.ExecuteReader();
                if (reader != null)
                {
                    return reader.HasRows;
                }
                return false;
            }
            catch (Exception exception)
            {

                throw new Exception("Error!!", exception);
            }
            finally
            {
                if (SqlConnectionObj != null && SqlConnectionObj.State == ConnectionState.Open)
                {
                    SqlConnectionObj.Close();
                }
            }
        }
        public List<Department> GetAll()
        {
            List<Department> departments = new List<Department>();
            try
            {
                SqlConnectionObj.Open();
                string query = String.Format("select * from tbl_Department");
                SqlCommandObj.CommandText = query;
                SqlDataReader reader = SqlCommandObj.ExecuteReader();
                while (reader.Read())
                {
                    Department aDepartment = new Department();
                   // aDepartment.Id = reader["Id"].ToString();
                    aDepartment.Title = reader["Title"].ToString();
                    aDepartment.Code = reader["Code"].ToString();
                    departments.Add(aDepartment);
                }

            }
            catch (Exception exception)
            {
                throw new Exception("Error!!", exception);
            }
            finally
            {
                if (SqlConnectionObj != null && SqlConnectionObj.State == ConnectionState.Open)
                {
                    SqlConnectionObj.Close();
                }
            }
            return departments;
        }
        public Department GetDepartment(string departmentnTitle)
        {
            try
            {
                SqlConnectionObj.Open();
                string query = String.Format("select * from tbl_Department where title='{0}'", departmentnTitle);
                SqlCommandObj.CommandText = query;
                SqlDataReader reader = SqlCommandObj.ExecuteReader();
                Department aDepartment = new Department();
                while (reader.Read())
                {
                   // aDepartment.Id = reader["Id"].ToString();
                    aDepartment.Title = reader["Title"].ToString();
                    aDepartment.Code = reader["Code"].ToString();
                }
                return aDepartment;
            }
            catch (Exception exception)
            {
                throw new Exception("Error!!", exception);
            }
            finally
            {
                if (SqlConnectionObj != null && SqlConnectionObj.State == ConnectionState.Open)
                {
                    SqlConnectionObj.Close();
                }
            }
        }
    }
}
