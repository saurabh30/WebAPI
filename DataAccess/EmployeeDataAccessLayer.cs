using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleAPI.Models;

namespace DataAccess
{
    public class EmployeeDataAccessLayer
    {
        string connectionString = "Data Source=DEL1-DHP-40424\\SQLEXPRESS;Initial Catalog=EMPLOYEEDB;Integrated Security=True";

        //To View all employees details
        public IEnumerable<Employee> GetAllEmployees()
        {

            List<Employee> listEmployee = new List<Employee>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spGetAllEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Employee employee = new Employee();

                    employee.Id = Convert.ToInt32(rdr["Id"]);
                    employee.Name = rdr["Name"].ToString();
                    employee.Location = rdr["Location"].ToString();

                    listEmployee.Add(employee);
                }
            }
            return listEmployee;

        } 
           
    }
}
