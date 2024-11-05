using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prova.MarQ.Domain.Entities;


namespace Prova.MarQ.Infra.Mappings
{
    public class EmployeeMap : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(c => c.Name)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.Document)
                .HasColumnType("varchar(11)")
                .HasMaxLength(11)
                .IsRequired();

            builder.Property(c => c.PIN)
                .HasColumnType("varchar(4)")
                .HasMaxLength(4)
                .IsRequired();

            builder.HasIndex(c => c.Document)
                .IsUnique();



        }
    }
}
