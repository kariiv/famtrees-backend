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
                if (!await appDbContext.PersonParents.AnyAsync())
                {
                    await appDbContext.PersonParents.AddRangeAsync(GetPreconfiguredPersonParents());
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
                new ("Riivik"),
                new ("Keris"),
            };
        }

        static IEnumerable<PersonParent> GetPreconfiguredPersonParents()
        {
            return new List<PersonParent>
            {
                new PersonParent(3, 1),
                new PersonParent(3, 2),
                new PersonParent(4, 3),
                new PersonParent(4, 48),
                new PersonParent(5, 3),
                new PersonParent(5, 48),
                new PersonParent(6, 3),
                new PersonParent(6, 8),
                new PersonParent(7, 3),
                new PersonParent(7, 8),
                new PersonParent(8, 45),
                new PersonParent(8, 44),
                new PersonParent(9, 1),
                new PersonParent(9, 2),
                new PersonParent(11, 9),
                new PersonParent(11, 10),
                new PersonParent(12, 9),
                new PersonParent(12, 10),
                new PersonParent(13, 12),
                new PersonParent(14, 12),
                new PersonParent(15, 2),
                new PersonParent(17, 15),
                new PersonParent(17, 16),
                new PersonParent(18, 15),
                new PersonParent(18, 16),

                new PersonParent(19, 44),
                new PersonParent(19, 45),

                new PersonParent(21, 19),
                new PersonParent(21, 20),
                new PersonParent(22, 19),
                new PersonParent(22, 20),
                new PersonParent(25, 19),
                new PersonParent(25, 20),
                new PersonParent(24, 22),
                new PersonParent(24, 23),
                new PersonParent(27, 25),
                new PersonParent(27, 26),
                new PersonParent(28, 44),
                new PersonParent(28, 45),
                new PersonParent(29, 28),
                new PersonParent(29, 47),
                new PersonParent(30, 31),
                new PersonParent(30, 28),
                new PersonParent(32, 31),
                new PersonParent(32, 28),
                new PersonParent(33, 28),
                new PersonParent(33, 47),
                new PersonParent(34, 33),
                new PersonParent(35, 44),
                new PersonParent(35, 45),
                new PersonParent(36, 35),
                new PersonParent(36, 37),
                new PersonParent(38, 35),
                new PersonParent(38, 39),

                new PersonParent(40, 35),
                new PersonParent(40, 46),
                new PersonParent(41, 35),
                new PersonParent(41, 46),
                new PersonParent(42, 35),
                new PersonParent(42, 46),
                new PersonParent(43, 35),
                new PersonParent(43, 46),
            };
        }

        static IEnumerable<Person> GetPreconfiguredPeople()
        {
            return new List<Person>
            {
                new (1, "Aida", "Vainomäe",Sex.Female, DateTime.Parse("1944-03-21"), DateTime.MinValue),
                new (1, "Eino", "Vainomäe",Sex.Male, DateTime.Parse("1942-07-23"), DateTime.Parse("2012-01-28")),
                new (1, "Aivo", "Vainomäe", Sex.Male, DateTime.Parse("1967-06-07"), DateTime.MinValue),
                new (1, "Anna", "Vainomäe", Sex.Female, DateTime.Parse("1993-02-06"), DateTime.MinValue),
                new (1, "Valdur", "Vainomäe",Sex.Male, DateTime.Parse("1991-10-30"), DateTime.MinValue),
                new (1, "Kauri", "Riivik", Sex.Male, DateTime.Parse("1998-01-01"), DateTime.MinValue),
                new (1, "Kairo", "Riivik", Sex.Male, DateTime.Parse("1996-08-29"), DateTime.Parse("2015-07-26")),
                new (1, "Merje", "Riivik", Sex.Female, DateTime.Parse("1975-09-23"), DateTime.MinValue),
                new (1, "Elo", "Raudsep",Sex.Female, DateTime.Parse("1971-12-31"), DateTime.MinValue),
                new (1, "Väino", "Raudsep",Sex.Male, DateTime.Parse("1966-12-14"), DateTime.MinValue),
                new (1, "Heleri", "Raudsep",Sex.Female, DateTime.Parse("1994-09-06"), DateTime.MinValue),
                new (1, "Rauno", "Raudsep",Sex.Male, DateTime.Parse("1990-08-15"), DateTime.MinValue),
                new (1, "Andri", "Raudsep",Sex.Male, DateTime.Parse("2017-09-25"), DateTime.MinValue),
                new (1, "Taago", "Raudsep",Sex.Male, DateTime.Parse("2020-03-10"), DateTime.MinValue),
                new (1, "Kairit", "Puust",Sex.Female, DateTime.Parse("1976-02-29"), DateTime.MinValue),
                new (1, "Rait", "Puust",Sex.Male, DateTime.Parse("1975-06-28"), DateTime.MinValue),
                new (1, "Kevin", "Puust",Sex.Male, DateTime.Parse("2000-03-09"), DateTime.MinValue),
                new (1, "Ele-Liis", "Puust",Sex.Female, DateTime.Parse("2004-09-01"), DateTime.MinValue),
                new (1, "Merle", "Mägi", Sex.Female, DateTime.Parse("1973-11-09"), DateTime.MinValue),
                new (1, "Raivo", "Mägi", Sex.Male, DateTime.Parse("1966-04-22"), DateTime.MinValue),
                new (1, "Kristjan", "Mägi", Sex.Male, DateTime.Parse("1995-12-07"), DateTime.MinValue),
                new (1, "Kristiina", "Klaas", Sex.Female, DateTime.Parse("1993-05-15"), DateTime.MinValue),
                new (1, "Joonas", "Klaas", Sex.Male, DateTime.Parse("1986-11-27"), DateTime.MinValue),
                new (1, "Annabel", "Klaas", Sex.Female, DateTime.Parse("2019-05-01"), DateTime.MinValue),
                new (1, "Merlin", "Eldemeel", Sex.Female, DateTime.Parse("1999-01-05"), DateTime.MinValue),
                new (1, "Kaur", "Eldemeel", Sex.Female, DateTime.Parse("1992-06-08"), DateTime.MinValue),
                new (1, "Eleanor", "Eldemeel", Sex.Female, DateTime.Parse("2020-03-15"), DateTime.MinValue),
                new (1, "Alar", "Johanson", Sex.Male, DateTime.Parse("1977-06-17"), DateTime.MinValue),
                new (1, "Henry", "Johanson", Sex.Male, DateTime.Parse("2004-07-20"), DateTime.MinValue),
                new (1, "Hanna-Liisa", "Esnar", Sex.Female, DateTime.Parse("2008-12-04"), DateTime.MinValue),
                new (1, "Jaanika", "Esnar", Sex.Female, DateTime.Parse("1989-06-24"), DateTime.MinValue),
                new (1, "Romek", "Esnar", Sex.Male, DateTime.Parse("2015-01-30"), DateTime.MinValue),
                new (1, "Erely", "Johanson", Sex.Female, DateTime.Parse("1998-03-15"), DateTime.MinValue),
                new (1, "Romek", "Johanson", Sex.Male, DateTime.Parse("2017-09-29"), DateTime.MinValue),
                new (1, "Rene", "Riivik", Sex.Male, DateTime.Parse("1972-08-15"), DateTime.MinValue),
                new (1, "Esper", "Ernits", Sex.Male, DateTime.Parse("1997-12-08"), DateTime.MinValue),
                new (1, "Esne", "Ernits", Sex.Female, DateTime.Parse("1972-08-23"), DateTime.MinValue),
                new (1, "Gertu", "Orb", Sex.Female, DateTime.Parse("2004-07-01"), DateTime.MinValue),
                new (1, "Aune", "Orb", Sex.Female, DateTime.Parse("1977-04-20"), DateTime.MinValue),
                new (1, "Remo", "Riivik", Sex.Male, DateTime.Parse("2005-03-30"), DateTime.MinValue),
                new (1, "Ranno", "Riivik", Sex.Male, DateTime.Parse("2007-08-17"), DateTime.MinValue),
                new (1, "Lorette-Iiris", "Riivik", Sex.Female, DateTime.Parse("2009-04-28"), DateTime.MinValue),
                new (1, "Mirette", "Riivik", Sex.Female, DateTime.Parse("2014-06-18"), DateTime.MinValue),
                new (1, "Arnold", "Riivik", Sex.Male, DateTime.Parse("1949-04-25"), DateTime.MinValue),
                new (1, "Ülle", "Silde", Sex.Female, DateTime.Parse("1952-06-11"), DateTime.MinValue),
                new (1, "Merle", "Riivik", Sex.Female, DateTime.Parse("1978-09-07"), DateTime.MinValue),
                new (1, "Eren", "Johanson", Sex.Female, DateTime.Parse("1980-12-03"), DateTime.MinValue),
                new (1, "Agnes", "Vaimann", Sex.Female, DateTime.Parse("1972-09-29"), DateTime.MinValue),
            };
        }
    }
}