using AcuityHome.DataAccessLayer.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcuityHome.DataAccessLayer
{
    public class AcuityHomeContext : IdentityDbContext<StoreUser>
    {
        public AcuityHomeContext(DbContextOptions<AcuityHomeContext> options) : base(options)
        {

        }

        public DbSet<SavedLocation> SavedLocation { get; set; }
        public DbSet<Location> Location { get; set; }
        public DbSet<Street> Street { get; set; }



    }
}
