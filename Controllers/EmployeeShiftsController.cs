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
    public class EmployeeShiftsController : ApiController
    {
        EmployeeShiftsBL EmpShiftBL = new EmployeeShiftsBL();

        // GET: api/EmployeeShifts
        public IEnumerable<EmployeeShift_Table> Get()
        {
            return EmpShiftBL.GetEmployeeShifts();
        }

        // GET: api/EmployeeShifts/5
        public EmployeeShift_Table Get(int id)
        {
            return EmpShiftBL.GetEmployeeShiftsByID(id);
        }

        // POST: api/EmployeeShifts
        public string Post(EmployeeShift_Table NewEmpShift)
        {
            return EmpShiftBL.AddEmployeeShifts(NewEmpShift);
        }

        // PUT: api/EmployeeShifts/5
        public string Put(int id, EmployeeShift_Table EmpShift)
        {
            return EmpShiftBL.UpdateEmployeeShift(id, EmpShift);
        }

        // DELETE: api/EmployeeShifts/5
        public string Delete(int id)
        {
            return EmpShiftBL.DeleteEmployeeShift(id);
        }
    }
}
