using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Web;

namespace FactoryProject.Models
{
    public class EmployeeWithShiftsBL
    {
        factoryDBEntities db = new factoryDBEntities();
        EmployeeBL EmpBL = new EmployeeBL();
        ShiftsBL ShiftsBL = new ShiftsBL();
        EmployeeShiftsBL EmployeeShiftsBL = new EmployeeShiftsBL();

        public List<EmployeeWithShifts> GetEmployeeWithShifts()
        {
            List<EmployeeWithShifts> employeeWithShifts = new List<EmployeeWithShifts>();

            foreach (var emp in db.Employee_Table)
            {
                EmployeeWithShifts empWithShifts = new EmployeeWithShifts();
                empWithShifts.EmployeeID = emp.EmployeeID;
                empWithShifts.First_Name = emp.First_Name;
                empWithShifts.Last_Name = emp.Last_Name;
                empWithShifts.Start_Work_Year = emp.Start_Work_Year;
                empWithShifts.DepartmentID = emp.DepartmentID;
                empWithShifts.Shifts = new List<Shifts_Table>();
                //db.EmployeeShift_Tables.Where(x = x.)
                //db.Shifts_Tables.Where(x = x. )

                var shiftsIDs = db.EmployeeShift_Tables
                    .Where(x => x.EmployeeID == emp.EmployeeID)
                    .Select(x => x.ShiftID).ToList();
                foreach (var shiftid in shiftsIDs)
                {
                    List<Shifts_Table> shifts = db.Shifts_Tables.Where(x => x.ShiftsID == shiftid).ToList();
                    empWithShifts.Shifts.AddRange(shifts);
                }
                employeeWithShifts.Add(empWithShifts);
            }

            //var shiftsIDs = db.EmployeeShift_Tables
            //                .Where(x => x.EmployeeID == emp.EmployeeID)
            //                .Select(x => x.ShiftID).ToList();

            //foreach (var shiftid in shiftsIDs)
            //{
            //    // Use FirstOrDefault to get a single shift based on shiftid
            //    Shifts_Table shift = db.Shifts_Tables.FirstOrDefault(x => x.ShiftsID == shiftid);

            //    // Check if shift is not null before adding to the list
            //    if (shift != null)
            //    {
            //        empWithShifts.Shifts.Add(shift);
            //    }
            //}



            return employeeWithShifts;
        }

        //public string UpdateEmployeeWithShifts(int id, EmployeeWithShifts empWithShifts)
        //{
          //  EmployeeWithShifts emp = EmployeeWithShifts.Where((x) => x.shiftsIDs == id).First();
            //if (emp != null)
            //{
              //  emp.Start_Work_Year = 
              // dep.Name = department.Name;
              //dep.ManagerID = department.ManagerID;
              //dep.DepartmentID = department.DepartmentID;
            //}
            //db.SaveChanges();
            //return (department + "UPDATED SUCCESFULLY"); }

        public List<EmployeeWithShifts> GetData()
        {
            return GetEmployeeWithShifts();
        }
        public string AddEmployeeWithShifts(EmployeeWithShifts empWithShifts)
        {
            
            // Add employee to Employee_Table
            Employee_Table emp = new Employee_Table
            {
                First_Name = empWithShifts.First_Name,
                Last_Name = empWithShifts.Last_Name,
                Start_Work_Year = empWithShifts.Start_Work_Year,
                DepartmentID = empWithShifts.DepartmentID
            };

            db.Employee_Table.Add(emp);
            db.SaveChanges();

            // Add shifts to Shifts_Table
            foreach (var shift in empWithShifts.Shifts)
            {
                Shifts_Table shiftEntity = new Shifts_Table
                {
                    date = shift.date,
                    Start_Time = shift.Start_Time,
                    End_Time = shift.End_Time
                };

                db.Shifts_Tables.Add(shiftEntity);
                db.SaveChanges();

                // Create entry in joint table EmployeeShift_Table
                EmployeeShift_Table employeeShift = new EmployeeShift_Table
                {
                    EmployeeID = emp.EmployeeID,
                    ShiftID = shiftEntity.ShiftsID
                };

                db.EmployeeShift_Tables.Add(employeeShift); //AFTER UPDATING E.S.CONTROLLER CONTROLLER COME BACK AND FINISH
                db.SaveChanges();
            }

            return "Employee with shifts created successfully";
        }

        public string UpdateEmployeeWithShifts(int id, EmployeeWithShifts empWithShifts)
        {
            // Update employee information
            Employee_Table emp = db.Employee_Table.Where(x => x.EmployeeID == id).First();

            if (emp != null)
            {
                emp.First_Name = empWithShifts.First_Name;
                emp.Last_Name = empWithShifts.Last_Name;
                emp.Start_Work_Year = empWithShifts.Start_Work_Year;
                emp.DepartmentID = empWithShifts.DepartmentID;

                db.SaveChanges();

                // Remove existing shifts for the employee
                var existingShifts = db.EmployeeShift_Tables.Where(x => x.EmployeeID == id);
                db.EmployeeShift_Tables.RemoveRange(existingShifts);
                db.SaveChanges();

                // Add new shifts for the employee
                foreach (var shift in empWithShifts.Shifts)
                {
                    Shifts_Table shiftEntity = new Shifts_Table
                    {
                        date = shift.date,
                        Start_Time = shift.Start_Time,
                        End_Time = shift.End_Time
                    };

                    db.Shifts_Tables.Add(shiftEntity);
                    db.SaveChanges();

                    // Create entry in joint table EmployeeShift_Table
                    EmployeeShift_Table employeeShift = new EmployeeShift_Table
                    {
                        EmployeeID = emp.EmployeeID,
                        ShiftID = shiftEntity.ShiftsID
                    };

                    db.EmployeeShift_Tables.Add(employeeShift);
                    db.SaveChanges();
                }

                return "Employee with shifts updated successfully";
            }

            return "Employee not found";
        }

        public string DeleteEmployeeWithShifts(int id)
        {
            
            Employee_Table emp = db.Employee_Table.Where(x => x.EmployeeID == id).First();
            if (emp != null)
            {
                // First Delte the employees shifts
                var existingShifts = db.EmployeeShift_Tables.Where(x => x.EmployeeID == id);
                db.EmployeeShift_Tables.RemoveRange(existingShifts);

                // then delete employee
                db.Employee_Table.Remove(emp);
                db.SaveChanges();

                return "Employee shifts deleted successfully";
            }

            return "All Employee Data Deleted Succesfully";
        }

    }
}