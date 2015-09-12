using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EmployeeManagement.DLL.DAO;
using System.Data;
using System.Data.SqlClient;

namespace EmployeeManagement.DLL.Gateway
{
    class DesignationGateway:DBGateway
    {
        private Designation aDesignation = new Designation();

        public string Save(Designation aDesignation)
        {
            string message = "";
            try
            {
                SqlConnectionObj.Open();
                string query = String.Format("insert into tbl_Designation values ('{0}','{1}')", aDesignation.Code, aDesignation.Title);
                SqlCommandObj.CommandText = query;
                SqlCommandObj.ExecuteNonQuery();
                message = "Designation Saved";
            }
            catch (Exception exception)
            {
                throw new Exception("Error!", exception);
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

        public bool HasThisDesignationTitle(string title)
        {
            try
            {
                SqlConnectionObj.Open();
                string query = String.Format("select * from tbl_Designation where Title = '{0}'", title);
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

        public bool HasThisDesignationCode(string code)
        {
            try
            {
                SqlConnectionObj.Open();
                string query = String.Format("Select * from tbl_Designation where code='{0}'", code);
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

        public List<Designation> GetAll()
        {
            List<Designation> designations = new List<Designation>();
            try
            {
                SqlConnectionObj.Open();
                string query = String.Format("select * from tbl_Designation");
                SqlCommandObj.CommandText = query;
                SqlDataReader reader = SqlCommandObj.ExecuteReader();
                while (reader.Read())
                {
                    Designation aDesignation = new Designation();
                    aDesignation.Title = reader["Title"].ToString();
                    aDesignation.Code = reader["Code"].ToString();
                    designations.Add(aDesignation);
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
            return designations;
        }
        public Designation GetDesignation(string designationTitle)
        {
            try
            {
                SqlConnectionObj.Open();
                string query = String.Format("select * from tbl_Designation where title='{0}'", designationTitle);
                SqlCommandObj.CommandText = query;
                SqlDataReader reader = SqlCommandObj.ExecuteReader();
                Designation aDesignation = new Designation();
                while (reader.Read())
                {
                    //aDesignation.Id = reader["Id"].ToString();
                    aDesignation.Title = reader["Title"].ToString();
                    aDesignation.Code = reader["Code"].ToString();
                }
                return aDesignation;
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
