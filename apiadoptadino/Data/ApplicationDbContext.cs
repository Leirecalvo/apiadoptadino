using System;
using apiadoptadino.Models;
using Microsoft.EntityFrameworkCore;

namespace apiadoptadino.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<User> User { get; set; }
        public DbSet<Adoption> Adoption { get; set; }
        public DbSet<Dinosaur> Dinosaur { get; set; }
        public DbSet<TypeDino> TypeDino { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //    => options.UseSqlServer("Server=localhost,1433; Database=adoptadino; User=sa; Password=Bootcamp18");
    }
}