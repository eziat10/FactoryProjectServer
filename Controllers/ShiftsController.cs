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
    public class ShiftsController : ApiController
    {
        ShiftsBL ShiftBL = new ShiftsBL();
        // GET: api/Shifts
        public IEnumerable<Shifts_Table> Get()
        {
            return ShiftBL.GetShifts();

        }

        // GET: api/Shifts/5
        public Shifts_Table Get(int id)
        {
            return ShiftBL.GetShiftsById(id);
        }

        // POST: api/Shifts
        public string AddShift(Shifts_Table newShift)
        {
            return ShiftBL.AddShift(newShift);
        }

        // PUT: api/Shifts/5
        public string Put(int id, Shifts_Table Shift)
        {
            return ShiftBL.UpdateShift(id, Shift);
        }

        // DELETE: api/Shifts/5
        public string Delete(int id)
        {
            return ShiftBL.DeleteShift(id);
        }


    }
}
