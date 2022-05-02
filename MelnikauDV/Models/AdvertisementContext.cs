using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic; 
using System.Linq;
using System.Threading.Tasks;
using MelnikauDV.Models.AccountModel;
using MelnikauDV;
using MelnikauDV.Models;

namespace MelnikauDV.Models
{
    public class AdvertisementContext : DbContext
    {
        public AdvertisementContext(DbContextOptions<AdvertisementContext> options) : base(options)
        {
           
            Database.EnsureCreated();
        }
        public AdvertisementContext()
        {

        }
        public DbSet<Advertisement> Advertisements { get; set; }
        //  public DbSet<AdvMark> AdvMarks { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<ProfitAdv> ProfitAdvs { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            string adminRoleName = "admin";
            string userRoleName = "user";
            string managerRoleName = "manager";
            string adminEmail = "admin@gmail.com";
            string adminPassword = "123457";
            string managerEmail = "manager@gmail.com";
            string managerPassword = "qwerty";

            // добавляем роли
            Role adminRole = new Role { Id = 1, Name = adminRoleName };
            Role userRole = new Role { Id = 2, Name = userRoleName };
            Role managerRole = new Role { Id = 3, Name = managerRoleName };
            User adminUser = new User { Id = 1, Email = adminEmail, Password = adminPassword, RoleId = adminRole.Id };
            User managerUser = new User { Id = 3, Email = managerEmail, Password = managerPassword, RoleId = managerRole.Id };

            modelBuilder.Entity<Role>().HasData(new Role[] { adminRole, userRole, managerRole });
            modelBuilder.Entity<User>().HasData(new User[] { adminUser, managerUser });

           
            base.OnModelCreating(modelBuilder);

        }
        public DbSet<AdvMark> AdvMark { get; set; }
        

    }
}
