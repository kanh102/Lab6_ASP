using Microsoft.EntityFrameworkCore;
using Lab6.Models;

namespace Lab6.Data
{
    public class Lab6Context : DbContext
    {
        public Lab6Context(DbContextOptions<Lab6Context> options)
            : base(options)
        {
        }

        public DbSet<Product> Product { get; set; } = default!;
    }
}