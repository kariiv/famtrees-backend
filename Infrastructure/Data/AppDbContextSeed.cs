using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FamTrees.Core.Entities.PersonAggregate;
using FamTrees.Core.Entities.TreeAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FamTrees.Infrastructure.Data
{
    public class AppDbContextSeed
    {
        public static async Task SeedAsync(AppDbContext appDbContext, ILoggerFactory loggerFactory, int? retry = 0)
        {
            int retryForAvailability = retry.Value;
            try
            {
                // TODO: Only run this if using a real database
                // context.Database.Migrate();
                if (!await appDbContext.Trees.AnyAsync())
                {
                    await appDbContext.Trees.AddRangeAsync(GetPreconfiguredTrees());
                    await appDbContext.SaveChangesAsync();
                }
                if (!await appDbContext.People.AnyAsync())
                {
                    await appDbContext.People.AddRangeAsync(GetPreconfiguredPeople());
                    await appDbContext.SaveChangesAsync();
                }
                
            }
            catch (Exception ex)
            {
                if (retryForAvailability < 10)
                {
                    retryForAvailability++;
                    var log = loggerFactory.CreateLogger<AppDbContextSeed>();
                    log.LogError(ex.Message);
                    await SeedAsync(appDbContext, loggerFactory, retryForAvailability);
                }
                throw;
            }
        }
        static IEnumerable<Tree> GetPreconfiguredTrees()
        {
            return new List<Tree>
            {
                new ("Vaarika"),
                new ("Keris"),
            };
        }

        static IEnumerable<Person> GetPreconfiguredPeople()
        {
            return new List<Person>
            {
                new (1, "Kalle", "Mallikas", Sex.Male, DateTime.Parse("2000-02-16"), DateTime.MinValue),
                new (1, "Madis", "Mullikas", Sex.Male, DateTime.Parse("1998-02-16"), DateTime.MinValue),
                new (1, "Mikk", "Saare", Sex.Male, DateTime.Parse("1978-02-16"), DateTime.MinValue),
                new (1, "Mari", "Maasikas", Sex.Female, DateTime.Parse("1975-02-16"), DateTime.Parse("2007-02-16")),
                new (1, "Saara", "Murakas", Sex.Female, DateTime.Parse("1958-02-16"), DateTime.MinValue),
                new (1, "Kersti", "Tartu",Sex.Female, DateTime.Parse("1958-02-16"), DateTime.Parse("1998-02-16"))
            };
        }
    }
}