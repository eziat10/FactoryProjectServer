using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FactoryProject.Models
{
    public class DepartmentsBL
    {
        factoryDBEntities db = new factoryDBEntities();
        //public factoryDBEntities()
        //{
         //   this.Configuration.LazyLoadingEnabled = false;
        //}
       
        public List<Departments__Table> GetDepartments()
        {
            return db.Departments__Table.ToList();  
            //I DONT UNDERSTAND WHATS THE ERR HERE
            //IT SEEMS TO BE THE RELATATIONSHIP WITH EMPLOYEESA FOREIGN KEY??
        }

        public Departments__Table GetDepartmentById(int id)
        {
            return db.Departments__Table.Where(x => x.DepartmentID == id).First();
            //.Where(x => x.DepartmentID == id).First(); ??
        }

        public string AddDepartment(Departments__Table department)
        {
            db.Departments__Table.Add(department);
            db.SaveChanges();
            return (department.Name + "CREATED SUCCESFULLY");

        }

        public string UpdateDepartment(int id, Departments__Table department)
        {
            Departments__Table dep = db.Departments__Table.Where((x) => x.DepartmentID == id).First();
            if(dep != null)
            {   
                dep.Name = department.Name;
                dep.ManagerID = department.ManagerID;
                //dep.DepartmentID = department.DepartmentID;
            }
            db.SaveChanges();
            return (department + "UPDATED SUCCESFULLY");

        }


        public string DeleteDepartment(int id)
        {
            Departments__Table dep = db.Departments__Table.Where(x => x.DepartmentID == id).First();
            if(dep != null)
            {
                db.Departments__Table.Remove(dep);
                db.SaveChanges();
            }
            return "DELETED SUCCESFULLY";
        }
    }
}