using FamTrees.Core.Entities.PersonAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FamTrees.Infrastructure.Data.Config
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("Person");

            builder.HasKey(p => p.Id);

            builder.Property(ci => ci.Id)
                .IsRequired();

            builder.Property(ci => ci.FirstName)
                .IsRequired();

            builder.Property(ci => ci.LastName)
                .IsRequired();

            builder.Property(ci => ci.TreeId)
                .IsRequired();

            builder.HasOne(tp => tp.Tree)
                .WithMany(t => t.People)
                .HasForeignKey(tp => tp.TreeId);
        }
    }
}