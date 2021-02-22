using System.Reflection;
using FamTrees.Core.Entities.PersonAggregate;
using FamTrees.Core.Entities.TreeAggregate;
using Microsoft.EntityFrameworkCore;

namespace FamTrees.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        
        public DbSet<Tree> Trees { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<PersonParent> PersonParents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}