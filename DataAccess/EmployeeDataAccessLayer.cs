using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccess
{
    public class EmployeeDataAccessLayer
    {
        string connectionString = "Data Source=DEL1-DHP-40424\\SQLEXPRESS;Initial Catalog=EMPLOYEEDB;Integrated Security=True";

        //To View all employees details
        public IEnumerable<Employee> GetAllEmployees()
        {
           
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                var employees = con.Query<Employee>("spGetAllEmployee", commandType: CommandType.StoredProcedure);
                return employees;
            }
            
        }

        public Employee GetEmployee(int id)
        {
            Employee employee = new Employee();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@EmpId", id);
                con.Open();
                employee = con.QueryFirstOrDefault<Employee>("spGetEmployee", param, commandType: CommandType.StoredProcedure);
                con.Close();
            }
            return employee;

        }

        public Employee UpdateEmployee(Employee employee)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Id", employee.Id);
                param.Add("@Name", employee.Name);
                param.Add("@Location", employee.Location);
                con.Open();
                con.Execute("spUpdateEmployee", param, commandType: CommandType.StoredProcedure);
                con.Close();
              
            }
            return employee;
        }    
        public Employee DelEmployee(int id)
        {
            Employee employee = new Employee();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@EmpId", id);
                con.Open();
                employee = con.QueryFirstOrDefault<Employee>("spGetEmployee", param, commandType: CommandType.StoredProcedure);
                con.Close();
                con.Close();
                param = new DynamicParameters();
                param.Add("@Id", id);
                con.Open();
                con.Execute("spDeleteEmployee", param, commandType: CommandType.StoredProcedure);
                con.Close();
            }
            return employee;

        }

        public Employee AddEmployee(Employee employee)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Name", employee.Name);
                param.Add("@Location", employee.Location);
                con.Open();
                con.Execute("spAddEmployee",param, commandType: CommandType.StoredProcedure);
                con.Close();
             }

            return employee;
        }




           
    }
}
