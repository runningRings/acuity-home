using AcuityHome.DataAccessLayer;
using AcuityHome.DataAccessLayer.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcuityHome.DataAccessLayer
{
    public class AcuityHomeSeeder
    {
        private readonly AcuityHomeContext _context;
        private readonly IHostingEnvironment _hosting;
        private readonly UserManager<StoreUser> _userManager;

        public AcuityHomeSeeder(AcuityHomeContext context,
            IHostingEnvironment hosting,
            UserManager<StoreUser> userManager)
        {
            _context = context;
            _hosting = hosting;
            _userManager = userManager;
        }

        //This method ensures that a database has been created, and that a default user has been inserted
        public async Task Seed()
        {
            _context.Database.EnsureCreated();

            var user = await _userManager.FindByEmailAsync("arron-morris@hotmail.co.uk");

            if(user == null)
            {
                user = new StoreUser()
                {
                    FirstName = "Aaron",
                    LastName = "Morris",
                    UserName = "arron-morris@hotmail.co.uk",
                    Email = "arron-morris@hotmail.co.uk"

                };

               var result = await _userManager.CreateAsync(user, "P@ssw0rd!");

                if(result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Failed to create the default user");
                }
            }
        }
    }
}
