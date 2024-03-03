using FactoryProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace FactoryProject.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class EmployeeWithShiftsController : ApiController
    {
        EmployeeWithShiftsBL EmpWthShfBL = new EmployeeWithShiftsBL();

        // GET: api/EmployeeWithShifts
        public IEnumerable<EmployeeWithShifts> Get()
        {
            return EmpWthShfBL.GetData();
        }

        // GET: api/EmployeeWithShifts/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/EmployeeWithShifts
        public string Post(EmployeeWithShifts empWithShifts)
        {
            return EmpWthShfBL.AddEmployeeWithShifts(empWithShifts);
        }

        // PUT: api/EmployeeWithShifts/5
        public string Put(int id, EmployeeWithShifts empWithShifts)
        {
            return EmpWthShfBL.UpdateEmployeeWithShifts(id, empWithShifts);
        }

        // DELETE: api/EmployeeWithShifts/5
        public string Delete(int id)
        {
            return EmpWthShfBL.DeleteEmployeeWithShifts(id);
        }
    }
}
