using System;
using Microsoft.EntityFrameworkCore;

namespace WEP_API.DataAccessLayer.Concrete
{
	public class Context:DbContext
	{
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("Server=localhost;Database=WEP_API;Uid=SA;Password=reallyStrongPwd123;TrustServerCertificate=True;MultiSubnetFailover=True");

        }
        public DbSet<Employee> Employees { get; set; }
    }
}

