using Database.Domain.Entities;
using Database.Domain.Entities.Views;
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
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<VwUserRolePermisionDomain>()
                .ToView("VwUserRolePermision")
                .HasNoKey();
        }
        public DbSet<CityDomain> Cities { get; set; }
        public DbSet<PermisionDomain> Permisions { get; set; }
        public DbSet<RolePermisionDomain> RolePermisions { get; set; }
        public DbSet<StudentDomain> Students { get; set; }
        public DbSet<CourseDomain> Courses { get; set; }
        public DbSet<StudentCourseDomain> StudentCourses { get; set; }
        public DbSet<VwUserRolePermisionDomain> VwUserRolePermision { get; set; }
    }
}
