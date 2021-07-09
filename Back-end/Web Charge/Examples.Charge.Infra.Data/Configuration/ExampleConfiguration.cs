using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Examples.Charge.Domain.Aggregates.ExampleAggregate;

namespace Examples.Charge.Infra.Data.Configuration
{
    public class ExampleConfiguration : IEntityTypeConfiguration<Example>
    {
        public void Configure(EntityTypeBuilder<Example> builder)
        {
            builder.Ignore(b => b.DomainEvents);

            builder.ToTable("Example", "dbo").HasKey(t => t.Id);

            builder.Property(t => t.Id).IsRequired(true);
            builder.Property(t => t.Nome).IsRequired(true);

            builder.HasData(new Example { Id = 1, Nome = "Example 1" });
            builder.HasData(new Example { Id = 2, Nome = "Example 2" });
            builder.HasData(new Example { Id = 3, Nome = "Example 3" });
        }
    }
}
