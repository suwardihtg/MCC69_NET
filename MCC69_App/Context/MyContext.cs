﻿using MCC69_App.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCC69_App.Context
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> dbContext) : base(dbContext)
        {

        }
        //ketik ovveride on control spasi
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //optionsBuilder.UseLazyLoadingProxies();
        }
        public DbSet<Regions> Regions { get; set; }
        public DbSet<Countries> Countries { get; set; }
        public DbSet<Departments> Departments { get; set; }
        public DbSet<Employees> Employees { get; set; }
        public DbSet<Jobs> Jobs { get; set; }
        public DbSet<Locations> Locations { get; set; }
        public DbSet<JobHistory> JobHistories { get; set; }
        public DbSet<MCC69_App.Models.Login> Login { get; set; }
        public DbSet<MCC69_App.Models.User> User { get; set; }
        public DbSet<MCC69_App.Models.Token> Token { get; set; }
        /*  public DbSet<User> Users { get; set; }
          public DbSet<Role> Roles { get; set; }
          public DbSet<UserRole> UserRoles { get; set; }*/
    }
}
