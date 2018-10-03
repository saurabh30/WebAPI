using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace BuisnessLayer
{
    
    public class EmployeeCRUD
    {
        EmployeeDataAccessLayer obj = new EmployeeDataAccessLayer();

        public IEnumerable<Employee> GetAllEmployees() {
            return obj.GetAllEmployees();
        }

        public void AddEmployee(Employee employee) {
            obj.AddEmployee(employee);
        }

        public Employee GetEmployee(int? id)
        {
            return obj.GetEmployee(id);
        }
    }
}
