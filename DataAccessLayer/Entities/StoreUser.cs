using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcuityHome.DataAccessLayer.Entities
{
    public class StoreUser : IdentityUser
    {
        //Properties that extend the default MS StoreUser class
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
