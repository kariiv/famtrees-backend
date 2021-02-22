using System;
using FamTrees.Core.Entities.PersonAggregate;
using FamTrees.Core.Exceptions;
using Xunit;
using Xunit.Abstractions;

namespace FamTrees.UnitTests.Core.Entities
{
    public class PersonTests
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public PersonTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        public void PersonCreationDateInFuture()
        {
            Assert.Throws<DateInFutureException>(() => 
                new Person(1, "Mari", "Maasikas", Sex.Female, DateTime.Parse("2022-02-16"),
                DateTime.Parse("1998-02-16")));

            Assert.Throws<DateInFutureException>(() =>
                new Person(1, "Mari", "Maasikas", Sex.Female, DateTime.Parse("1998-02-16"),
                    DateTime.Parse("2022-02-16")));

            Assert.Throws<DateInFutureException>(() =>
                new Person(1, "Mari", "Maasikas", Sex.Female, DateTime.Parse("3322-02-16"),
                    DateTime.Parse("1000-02-16")));
        }

        [Fact]
        public void PersonCreationLowDate()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                new Person(1, "Mari", "Maasikas", Sex.Female, 
                    DateTime.Parse("1020-02-16"), DateTime.Parse("2020-02-16")));

            Assert.Throws<ArgumentOutOfRangeException>(() =>
                new Person(1, "Mari", "Maasikas", Sex.Female, 
                    DateTime.Parse("1000-02-16"), DateTime.Parse("2020-02-16")));

            Assert.Throws<ArgumentOutOfRangeException>(() =>
                new Person(1, "Mari", "Maasikas", Sex.Female, 
                    DateTime.Parse("1000-02-16"), DateTime.Parse("1000-02-16")));

            new Person(1, "Mari", "Maasikas", Sex.Female, 
                DateTime.Parse("2020-02-16"), DateTime.Parse("1000-02-16"));

            new Person(1, "Mari", "Maasikas", Sex.Female, 
                DateTime.Parse("1820-02-16"), DateTime.Parse("1000-02-16"));
        }

        [Fact]
        public void PersonCreationDeadBeforeBorn()
        {
            Assert.Throws<PersonDeadBeforeBornException>(() =>
                new Person(1, "Mari", "Maasikas", Sex.Female, 
                    DateTime.Parse("1999-02-16"), DateTime.Parse("1998-02-16")));

            Assert.Throws<PersonDeadBeforeBornException>(() =>
                new Person(1, "Mari", "Maasikas", Sex.Female, 
                    DateTime.Parse("2020-02-16"), DateTime.Parse("2010-02-16")));

            new Person(1, "Mari", "Maasikas", Sex.Female, 
                DateTime.Parse("2020-02-16"), DateTime.Parse("1010-02-16"));

            new Person(1, "Mari", "Maasikas", Sex.Female,
                DateTime.Parse("2020-02-16"), DateTime.Parse("2020-02-16"));
        }


    }
}