using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.DatabaseContext
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options)
        : base(options)
        {
        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(e => e.State == EntityState.Added))
            {
                entry.Property("CreatedDateTime").CurrentValue = DateTime.Now;
                entry.Property("IsDeleted").CurrentValue = false;
            }

            return base.SaveChanges();
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //{
        //    options.UseSqlServer("Server=.;Database=RS2_ApplicationDb;MultipleActiveresultsets=True;Trusted_Connection=True");
        //}

        public MyContext() { }
        public DbSet<Users> Users { get; set; }
        public DbSet<Cities> Cities { get; set; }
        public DbSet<Countries> Countries { get; set; }
        public DbSet<UserLogger> UserLogger { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<UserRoles> UserRoles { get; set; }
        public DbSet<WorkingDays> WorkingDays { get; set; }
        public DbSet<Shifts> Shifts { get; set; }
        public DbSet<Events> Events { get; set; }
        public DbSet<EventStatuses> EventStatuses { get; set; }
        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<TaskStatuses> TaskStatuses { get; set; }
        public DbSet<UserTasks> UserTasks { get; set; }
        public DbSet<WorkingAbsences> WorkingAbsences { get; set; }
        public DbSet<AbsenceTypes> AbsenceTypes { get; set; }
        public DbSet<UserResidence> UserResidence { get; set; }
    }
}
