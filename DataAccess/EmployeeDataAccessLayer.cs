﻿using System;
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

        public void UpdateEmployee(Employee employee)
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
            
        }    
        public void DelEmployee(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Id", id);
                con.Open();
                con.Execute("spDeleteEmployee", param, commandType: CommandType.StoredProcedure);
                con.Close();
            }        
        }

        public Int32 AddEmployee(Employee employee)
        {
            var id = 0;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Name", employee.Name);
                param.Add("@Location", employee.Location);
                param.Add("@id", dbType: DbType.Int32, direction: ParameterDirection.Output);
                con.Open();
                con.Execute("spAddEmployee",param, commandType: CommandType.StoredProcedure);
                id = param.Get<int>("@id");
                con.Close();
             }

            return id;
        }




           
    }
}
