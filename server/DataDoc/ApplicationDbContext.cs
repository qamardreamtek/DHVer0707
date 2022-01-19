using BlazorApp1.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorApp1.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public ApplicationDbContext()
            : base()
        {
        }
        public DbSet<ProgramUnit> ProgramUnits { get; set; }
        public DbSet<ProgramGrp> ProgramGrps { get; set; }

        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<ApplicationRole> ApplicationRole { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //    modelBuilder.Ignore<IdentityUserLogin<string>>();
        //    modelBuilder.Ignore<IdentityUserRole<string>>();
        //    modelBuilder.Ignore<IdentityUserClaim<string>>();
        //    modelBuilder.Ignore<IdentityUserToken<string>>();
        //    modelBuilder.Ignore<IdentityUser<string>>();
        //    modelBuilder.Ignore<ApplicationUser>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            //modelBuilder.Ignore<IdentityUserLogin<string>>();
            //modelBuilder.Ignore<IdentityUserRole<string>>();
            //modelBuilder.Ignore<IdentityUserClaim<string>>();
            //modelBuilder.Ignore<IdentityUserToken<string>>();
            //modelBuilder.Ignore<IdentityUser<string>>();
            //    modelBuilder.Ignore<ApplicationUser>();
            //modelBuilder.Entity<UserLoginInfo>.ke

                modelBuilder.Entity<ProgramUnit>().ToTable("ProgramUnit");
            modelBuilder.Entity<ProgramGrp>().ToTable("ProgramGrp");
            modelBuilder.Entity<ApplicationUser>().ToTable("ApplicationUser");
            modelBuilder.Entity<ApplicationRole>().ToTable("ApplicationRole");

            modelBuilder.Entity<ProgramUnit>()
           .HasIndex(b => b.Code)
           .IsUnique();
            modelBuilder.Entity<ProgramUnit>()
           .HasIndex(b => b.Name)
           .IsUnique();

            modelBuilder.Entity<ProgramGrp>()
           .HasIndex(b => b.Code)
           .IsUnique();
            modelBuilder.Entity<ProgramGrp>()
           .HasIndex(b => b.Name)
           .IsUnique();


        }
    }
}
