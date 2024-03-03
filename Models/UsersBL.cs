using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FactoryProject.Models
{
    public class UsersBL
    {
        factoryDBEntities db = new factoryDBEntities();

        public List<Users_Table>GetUsers()
        {
            return db.Users_Tables.ToList();    
        }

        
    }
}