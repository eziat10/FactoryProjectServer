using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using System.Web.Http.Cors;

using FactoryProject.Models;    

namespace FactoryProject.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class EmployeeController : ApiController
    {

        EmployeeBL EmpBL = new EmployeeBL();

        // GET: api/Employee
        public IEnumerable<Employee_Table> Get()
        {
            return EmpBL.GetEmployees();
        }

        // GET: api/Employee/5
        public Employee_Table Get(int id)
        {
            return EmpBL.GetEmployeeById(id);

        }

        //DO POST PUT AND DELETE 

        // POST: api/Employee
        public string AddEmployee(Employee_Table newEmployee)
        {
            return EmpBL.AddEmployee(newEmployee);
        }

        // PUT: api/Employee/5
        public string Put(int id, Employee_Table employee)
        {
            return EmpBL.UpdateEmployee(id, employee);
        }

        // DELETE: api/Employee/5
        public string Delete(int id)
        {
            return EmpBL.DeleteEmployee(id);
        }
    }
}
