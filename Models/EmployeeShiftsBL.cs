using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FactoryProject.Models
{
    
    public class EmployeeShiftsBL
    {
        factoryDBEntities db = new factoryDBEntities();
        public List<EmployeeShift_Table> GetEmployeeShifts()
        {
            return db.EmployeeShift_Tables.ToList(); 

        }

        public EmployeeShift_Table GetEmployeeShiftsByID(int id)
        {
            return db.EmployeeShift_Tables.Where(x => x.EmployeeShiftID == id).First();
        }

        public string AddEmployeeShifts(EmployeeShift_Table empShift)
        {
            db.EmployeeShift_Tables.Add(empShift);
            db.SaveChanges();
            return ("CREATED SUCCESFULLY");
        }

        public string UpdateEmployeeShift(int id, EmployeeShift_Table empShift)
        {
            EmployeeShift_Table eShift = db.EmployeeShift_Tables.Where((x)=> x.EmployeeShiftID == id).First() ;
            if(eShift != null)
            {
                eShift.EmployeeID = empShift.EmployeeID;
                eShift.ShiftID = empShift.ShiftID;
            }
            db.SaveChanges();
            return (empShift + "UPDATED SUCCESFULLY");

        }
        public string DeleteEmployeeShift(int id)
        {
            EmployeeShift_Table empShift = db.EmployeeShift_Tables.Where(x => x.EmployeeShiftID == id).First();
            if (empShift != null)
            {
                db.EmployeeShift_Tables.Remove(empShift);
                db.SaveChanges();
            }
            return "DELETED SUCCESFULLY";
        }
    }
}