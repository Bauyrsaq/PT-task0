using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryData.API
{
    public interface IDataContext : IDisposable
    {
        DbSet<User> Users { get; }
        DbSet<Book> Books { get; }
        DbSet<State> States { get; }
        DbSet<Borrowing> Borrowings { get; }

        static IDataContext CreateContext(string? connectionString = null)
        {
            return new DataContext(connectionString);
        }
    }
}
