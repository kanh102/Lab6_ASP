using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Lab6_movie.Models;

namespace Lab6_movie.Data
{
    public class Lab6_movieContext : DbContext
    {
        public Lab6_movieContext (DbContextOptions<Lab6_movieContext> options)
            : base(options)
        {
        }

        public DbSet<Lab6_movie.Models.Genre> Genre { get; set; } = default!;
    }
}
