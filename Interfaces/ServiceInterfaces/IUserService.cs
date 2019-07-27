using AcuityHome.DataAccessLayer.Entities;
using AcuityHome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcuityHome.Interfaces.ServiceInterfaces.ProfileServiceInterfaces
{
    public interface IUserService
    {
        ProfileViewModel RetrieveCurrentUser(string username);
    }
}
