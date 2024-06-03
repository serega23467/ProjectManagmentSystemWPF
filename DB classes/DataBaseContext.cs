using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagmentSystemWPF
{
    public class DataBaseContext : DbContext
    {
        private static DataBaseContext instance;
        public DbSet<Role> Roles { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<ProjectTask> Tasks { get; set; } = null!;
        public DbSet<TaskEmployer> TasksEmployees { get; set; } = null!;
        public DbSet<ProjectCard> ProjectsCards{ get; set; } = null!;
        public DbSet<ProjectEmployer> ProjectsEmployees { get; set; } = null!;
        private DataBaseContext(){}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=ProjectManagmentDB.db");
        }
        public static DataBaseContext GetDB()
        {
            if(instance!= null)
            {
                return instance;
            }
            else
            {
                instance = new DataBaseContext();
                return instance;
            }
        }
    }
}
