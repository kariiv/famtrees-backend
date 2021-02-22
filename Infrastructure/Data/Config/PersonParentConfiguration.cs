
using FamTrees.Core.Entities.PersonAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FamTrees.Infrastructure.Data.Config
{
    class PersonParentConfiguration : IEntityTypeConfiguration<PersonParent>
    {
        public void Configure(EntityTypeBuilder<PersonParent> builder)
        {
            builder.ToTable("PersonParent");
            
            builder.HasKey(pp => new {pp.PersonId, pp.ParentId});
            
            // builder.Property(ci => ci.PersonId)
            //     .UseHiLo("person_hilo")
            //     .IsRequired();
            //
            // builder.Property(ci => ci.ParentId)
            //     .UseHiLo("person_hilo")
            //     .IsRequired();


            // builder.HasOne(pp => pp.Person)
            //     .WithMany(p => p.PersonParents)
            //     .HasForeignKey(pp => pp.PersonId);

            builder.HasOne(p => p.Person)
                .WithMany(t => t.PersonParents)
                .HasForeignKey(tp => tp.PersonId);

            builder.HasOne(tp => tp.Parent)
                .WithMany(p => p.PersonOfParents)
                .HasForeignKey(tp => tp.ParentId);
        }
    }
}
