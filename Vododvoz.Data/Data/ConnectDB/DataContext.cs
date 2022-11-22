using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vododvoz.Data.Data.Entyties;

namespace Vododvoz.Data.Data.ConnectDB
{
    public class DataContext : DbContext
    {
        readonly GetConnectionString _getConnectionString;

        public DbSet<Order> Orders { get; set; } = null;
        public DbSet<Employee> Employees { get; set; } = null;
        public DbSet<Devision> Devisions { get; set; } = null;

        public DataContext()
        {
            _getConnectionString = new GetConnectionString();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var connectionString = _getConnectionString.GetConnectionStrings("VodovozConnection");
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
