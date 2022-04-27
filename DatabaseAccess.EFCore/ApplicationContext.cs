using Database.Domain.Entities;
using DatabaseAccess.EFCore.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.EFCore
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<CityDomain> Cities { get; set; }
        public DbSet<PermisionDomain> Permisions { get; set; }
        public DbSet<RolePermisionDomain> RolePermisions { get; set; }
        public DbSet<StudentDomain> Students { get; set; }
    }
}
