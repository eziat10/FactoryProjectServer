using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FactoryProject.Models
{
    public class EmployeeBL
    {
        factoryDBEntities db = new factoryDBEntities();
        public List<Employee_Table> GetEmployees()
        {
            return db.Employee_Table.ToList(); //if something is wrong it might be here, it has tables instead of table
        }
        public Employee_Table GetEmployeeById(int id)
        {
            return db.Employee_Table.Where(x => x.EmployeeID == id).First();
        }
        public string AddEmployee(Employee_Table emp)
        {
            db.Employee_Table.Add(emp);
            db.SaveChanges();
            return (emp.EmployeeID + "CREATED SUCCESFULLY");
        }

        public string UpdateEmployee(int id, Employee_Table employee)
        {
            Employee_Table emp = db.Employee_Table.Where((x) => x.EmployeeID == id).First();
            if (emp != null)
            {
                emp.First_Name = employee.First_Name;
                emp.Last_Name = employee.Last_Name;
                emp.Start_Work_Year = employee.Start_Work_Year;
                emp.DepartmentID = employee.DepartmentID;
               //not including id because id shouldt be able to change
            }
            db.SaveChanges();
            return (employee + "UPDATED SUCCESFULLY");

        }
        public string DeleteEmployee(int id)
        {
            Employee_Table emp = db.Employee_Table.Where(x => x.EmployeeID == id).First();
            if (emp != null)
            {
                db.Employee_Table.Remove(emp);
                db.SaveChanges();
            }
            return "DELETED SUCCESFULLY";
        }

    }
    }