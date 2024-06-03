using LibraryData.API;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryData
{
    public class DataContext : DbContext, IDataContext
    {
        private readonly string ConnectionString;

        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Borrowing> Borrowings { get; set; }

        public DataContext(string? connectionString = null)
        {
            if (connectionString == null)
            {
                string _projectRootDir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
                string _DBRelativePath = @"Database\LibraryDB.mdf";
                string _DBPath = Path.Combine(_projectRootDir, _DBRelativePath);
                this.ConnectionString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={_DBPath};Integrated Security = True; Connect Timeout = 30;";
            }
            else
            {
                this.ConnectionString = connectionString;
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(this.ConnectionString);
        }

        public void SaveChanges()
        {
            base.SaveChanges();
        }
    }
}
