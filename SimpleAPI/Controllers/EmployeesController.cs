using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SimpleAPI.Models;

namespace SimpleAPI.Controllers
{
    public class EmployeesController : ApiController
    {
        Employee[] employees = new Employee[]
        {
            new Employee { Id = 1 , Name = "Saurabh" , Location = "Noida" },
            new Employee { Id = 2 , Name = "Saurabh2" , Location = "Noida2" },
            new Employee { Id = 3 , Name = "Saurabh3" , Location = "Noida3" },
        };

        public IEnumerable<Employee> GetAllEmployees() {
            return employees;
        }

        public IHttpActionResult GetEmployee(int id) {
            var employee = employees.FirstOrDefault((p) => p.Id == id);
            if ( employee == null) return NotFound();
            return Ok(employee);
        }
    }
}
