using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FactoryProject.Models
{
    public class ShiftsBL
    {
        factoryDBEntities db = new factoryDBEntities();
   
        public List<Shifts_Table> GetShifts()
        {
            return db.Shifts_Tables.ToList(); //if something is wrong it might be here, it has tables instead of table
        }

        public Shifts_Table GetShiftsById(int id)
        {
            return db.Shifts_Tables.Where(x => x.ShiftsID == id).First();
            
        }

        public string AddShift(Shifts_Table Shift)
        {
            db.Shifts_Tables.Add(Shift);
            db.SaveChanges();
            return (Shift.ShiftsID + "CREATED SUCCESFULLY");
        }

        public string UpdateShift(int id, Shifts_Table Shifts)
        {
            Shifts_Table Shift = db.Shifts_Tables.Where((x) => x.ShiftsID == id).First();
            if (Shift != null)
            {
                Shift.date = Shifts.date;
                Shift.Start_Time = Shifts.Start_Time;
                Shift.End_Time = Shifts.End_Time;
                //not including id because id shouldt be able to change
            }
            db.SaveChanges();
            return (Shifts + "UPDATED SUCCESFULLY");
        }
        public string DeleteShift(int id)
        {
            Shifts_Table Shifts = db.Shifts_Tables.Where(x => x.ShiftsID == id).First();
            if (Shifts != null)
            {
                db.Shifts_Tables.Remove(Shifts);
                db.SaveChanges();
            }
            return "DELETED SUCCESFULLY";
        }

    }
}