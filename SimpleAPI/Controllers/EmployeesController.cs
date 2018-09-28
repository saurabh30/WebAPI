using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BuisnessLayer;
using DataAccess;


namespace SimpleAPI.Controllers
{
    public class EmployeesController : ApiController
    {
        EmployeeCRUD objemployee = new EmployeeCRUD();

        public IEnumerable<Employee> GetAllEmployees()
        {
            return objemployee.GetAllEmployees();
        }
     
    }
}
