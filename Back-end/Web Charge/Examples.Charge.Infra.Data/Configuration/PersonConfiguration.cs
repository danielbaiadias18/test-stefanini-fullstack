using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Examples.Charge.Domain.Aggregates.PersonAggregate;

namespace Examples.Charge.Infra.Data.Configuration
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.Ignore(b => b.DomainEvents);

            builder.ToTable("Person", "dbo").HasKey(t => t.BusinessEntityID);

            builder.Property(t => t.BusinessEntityID).HasColumnName("BusinessEntityID").IsRequired(true);
            builder.Property(t => t.Name).HasColumnName("Name").IsRequired(true);
            builder.HasMany(t => t.Phones).WithOne(t => t.Person);

            builder.HasData(new Person { BusinessEntityID = 1, Name = "User One" });
        }
    }
}
