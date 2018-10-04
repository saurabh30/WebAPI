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

        public IHttpActionResult GetEmployee(int id)
        {
            var employee = objemployee.GetEmployee(id);
            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        public IHttpActionResult DeleteEmployee(int id)
        {
             objemployee.DelEmployee(id);
             return Ok();
        }

        public IHttpActionResult PutEmployee([FromBody]Employee employee)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

          
            objemployee.UpdateEmployee(employee);
            return Ok();
        }

        public IHttpActionResult PostEmployee(Employee employee)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Int32 Id = objemployee.AddEmployee(employee);
            if (Id == 0)
                return NotFound();
            employee.Id = Id;
            return Created(new Uri(Request.RequestUri +""+ Id) , employee);
        }
    }
}
