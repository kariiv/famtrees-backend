using FamTrees.Core.Entities.TreeAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FamTrees.Infrastructure.Data.Config
{
    public class TreeConfiguration : IEntityTypeConfiguration<Tree>
    {
        public void Configure(EntityTypeBuilder<Tree> builder)
        {
            builder.ToTable("Tree");

            builder.HasKey(t => t.Id);

            builder.Property(ci => ci.Id)
                .UseHiLo("tree_hilo")
                .IsRequired();

            builder.Property(ci => ci.Name)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}