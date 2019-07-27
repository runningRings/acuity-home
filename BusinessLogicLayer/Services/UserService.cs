using AcuityHome.DataAccessLayer.Entities;
using AcuityHome.Interfaces.ServiceInterfaces.ProfileServiceInterfaces;
using AcuityHome.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcuityHome.BusinessLogicLayer.Services
{
    public class UserService: IUserService
    {
        private readonly UserManager<StoreUser> _userManager;

        public UserService(UserManager<StoreUser> userManager)
        {
            _userManager = userManager;
        }

        //Service method to retrieve the current user, as a ProfileViewModel object, accessed via the parsed username string
        public ProfileViewModel RetrieveCurrentUser(string username)
        {

            var user = _userManager.FindByNameAsync(username).Result;

            ProfileViewModel userViewmodel = new ProfileViewModel()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                Email = user.Email
            };

            return userViewmodel;

        }


    }
}
