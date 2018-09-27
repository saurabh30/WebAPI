using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataAccess;


namespace SimpleAPI.Controllers
{
    public class EmployeesController : ApiController
    {
        EmployeeDataAccessLayer objemployee = new EmployeeDataAccessLayer();

        public IEnumerable<Employee> GetAllEmployees()
        {
            return objemployee.GetAllEmployees();
        }
       
    }
}
