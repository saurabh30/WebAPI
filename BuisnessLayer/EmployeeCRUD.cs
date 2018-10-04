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

        public Int32 AddEmployee(Employee employee) {
            return obj.AddEmployee(employee);
        }

        public Employee DelEmployee(int id) {
            return obj.DelEmployee(id);
        }
        public Employee GetEmployee(int id)
        {
            return obj.GetEmployee(id);
        }

        public Employee UpdateEmployee(Employee employee) {
            return obj.UpdateEmployee(employee);
        }

    }
}
