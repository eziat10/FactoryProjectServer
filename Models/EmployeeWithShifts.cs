using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FactoryProject.Models
{
    public class EmployeeWithShifts
    {

        public int EmployeeID { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Start_Work_Year { get; set; }
        public Nullable<int> DepartmentID { get; set; }
        public List<Shifts_Table> Shifts { get; set; }


    }


    }