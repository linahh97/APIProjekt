using APIProjekt.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt.API.Model
{
    public class ProjektDbContext : DbContext
    {
        public ProjektDbContext(DbContextOptions<ProjektDbContext> options) : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<TimeReport> TimeReports { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Employee
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 1,
                FirstName = "Yasmin",
                LastName = "Larian",
                Email = "prettyprincess@hotmail.com",
                Phone = "0701234567",
                ProjectId = 1
            });
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 2,
                FirstName = "Cloe",
                LastName = "Santon",
                Email = "angel@hotmail.com",
                Phone = "0709876543",
                ProjectId = 1
            });
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 3,
                FirstName = "Sasha",
                LastName = "Mason",
                Email = "bunnyboo@hotmail.com",
                Phone = "0729874934",
                ProjectId = 1
            });
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 4,
                FirstName = "Jade",
                LastName = "Hunter",
                Email = "koolkat@live.com",
                Phone = "0701271244",
                ProjectId = 1
            });
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 5,
                FirstName = "Barbara",
                LastName = "Roberts",
                Email = "barbie@hotmail.com",
                Phone = "0737485932",
                ProjectId = 2
            });
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 6,
                FirstName = "Christie",
                LastName = "O'Neil",
                Email = "chrissy@hotmail.com",
                Phone = "0767512409",
                ProjectId = 2
            });

            //Project
            modelBuilder.Entity<Project>().HasData(new Project
            {
                ProjectId = 1,
                ProjectName = "Bratz Dolls"
            });
            modelBuilder.Entity<Project>().HasData(new Project
            {
                ProjectId = 2,
                ProjectName = "Barbie Dolls"
            });

            //TimeReport
            modelBuilder.Entity<TimeReport>().HasData(new TimeReport
            {
                TimeReportId = 1,
                EmployeeId = 1,
                StartDate = new DateTime(2022, 1, 3, 8, 0, 0),
                EndDate = new DateTime(2022, 1, 3, 16, 0, 0),
                Week = 1
            });
            modelBuilder.Entity<TimeReport>().HasData(new TimeReport
            {
                TimeReportId = 2,
                EmployeeId = 2,
                StartDate = new DateTime(2022, 1, 4, 8, 30, 0),
                EndDate = new DateTime(2022, 1, 4, 16, 30, 0),
                Week = 1
            });
            modelBuilder.Entity<TimeReport>().HasData(new TimeReport
            {
                TimeReportId = 3,
                EmployeeId = 2,
                StartDate = new DateTime(2022, 1, 5, 9, 0, 0),
                EndDate = new DateTime(2022, 1, 5, 14, 30, 0),
                Week = 1
            });
            modelBuilder.Entity<TimeReport>().HasData(new TimeReport
            {
                TimeReportId = 4,
                EmployeeId = 2,
                StartDate = new DateTime(2022, 1, 7, 8, 30, 0),
                EndDate = new DateTime(2022, 1, 7, 15, 0, 0),
                Week = 1
            });
            modelBuilder.Entity<TimeReport>().HasData(new TimeReport
            {
                TimeReportId = 5,
                EmployeeId = 3,
                StartDate = new DateTime(2022, 1, 10, 8, 0, 0),
                EndDate = new DateTime(2022, 1, 10, 15, 30, 0),
                Week = 2
            });
            modelBuilder.Entity<TimeReport>().HasData(new TimeReport
            {
                TimeReportId = 6,
                EmployeeId = 3,
                StartDate = new DateTime(2022, 1, 12, 8, 0, 0),
                EndDate = new DateTime(2022, 1, 12, 16, 0, 0),
                Week = 2
            });
            modelBuilder.Entity<TimeReport>().HasData(new TimeReport
            {
                TimeReportId = 7,
                EmployeeId = 4,
                StartDate = new DateTime(2022, 1, 12, 8, 0, 0),
                EndDate = new DateTime(2022, 1, 12, 16, 0, 0),
                Week = 2
            });
            modelBuilder.Entity<TimeReport>().HasData(new TimeReport
            {
                TimeReportId = 8,
                EmployeeId = 4,
                StartDate = new DateTime(2022, 1, 14, 9, 0, 0),
                EndDate = new DateTime(2022, 1, 14, 17, 0, 0),
                Week = 2
            });
            modelBuilder.Entity<TimeReport>().HasData(new TimeReport
            {
                TimeReportId = 9,
                EmployeeId = 5,
                StartDate = new DateTime(2022, 1, 17, 8, 0, 0),
                EndDate = new DateTime(2022, 1, 17, 16, 0, 0),
                Week = 3
            });
            modelBuilder.Entity<TimeReport>().HasData(new TimeReport
            {
                TimeReportId = 10,
                EmployeeId = 5,
                StartDate = new DateTime(2022, 1, 18, 8, 0, 0),
                EndDate = new DateTime(2022, 1, 18, 16, 0, 0),
                Week = 3
            });
            modelBuilder.Entity<TimeReport>().HasData(new TimeReport
            {
                TimeReportId = 11,
                EmployeeId = 5,
                StartDate = new DateTime(2022, 1, 19, 8, 0, 0),
                EndDate = new DateTime(2022, 1, 19, 16, 0, 0),
                Week = 3
            });
            modelBuilder.Entity<TimeReport>().HasData(new TimeReport
            {
                TimeReportId = 12,
                EmployeeId = 5,
                StartDate = new DateTime(2022, 1, 20, 8, 0, 0),
                EndDate = new DateTime(2022, 1, 20, 16, 0, 0),
                Week = 3
            });
            modelBuilder.Entity<TimeReport>().HasData(new TimeReport
            {
                TimeReportId = 13,
                EmployeeId = 6,
                StartDate = new DateTime(2022, 1, 18, 8, 0, 0),
                EndDate = new DateTime(2022, 1, 18, 16, 30, 0),
                Week = 3
            });
            modelBuilder.Entity<TimeReport>().HasData(new TimeReport
            {
                TimeReportId = 14,
                EmployeeId = 6,
                StartDate = new DateTime(2022, 1, 19, 7, 0, 0),
                EndDate = new DateTime(2022, 1, 19, 15, 30, 0),
                Week = 3
            });
            modelBuilder.Entity<TimeReport>().HasData(new TimeReport
            {
                TimeReportId = 15,
                EmployeeId = 6,
                StartDate = new DateTime(2022, 1, 20, 9, 0, 0),
                EndDate = new DateTime(2022, 1, 20, 17, 0, 0),
                Week = 3
            });
        }
    }
}
