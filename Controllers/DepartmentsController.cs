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
    public class DepartmentsController : ApiController
    {
        DepartmentsBL DepBL = new DepartmentsBL();

        // GET: api/Departments
        public IEnumerable<Departments__Table> Get()
        {
           return DepBL.GetDepartments();
            
        }

        // GET: api/Departments/5
        public Departments__Table Get(int id)
        {
           return DepBL.GetDepartmentById(id);

        }

        // POST: api/Departments
        public string Post(Departments__Table newDepartment)
         {
            return DepBL.AddDepartment(newDepartment);
         }

        // PUT: api/Departments/5
        public string Put(int id, Departments__Table department)
        {
            return DepBL.UpdateDepartment(id, department);
        }

        // DELETE: api/Departments/5
        public string Delete(int id)
        {
            return DepBL.DeleteDepartment(id);
        }


    }
}
