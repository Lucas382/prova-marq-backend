
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Prova.MarQ.Domain.Entities;

namespace Prova.MarQ.Infra.Mappings
{
    public class TimeRecordMap: IEntityTypeConfiguration<TimeRecord>
    {
        public void Configure(EntityTypeBuilder<TimeRecord> builder)
        {
            builder.Property(c => c.PIN)
                .HasColumnType("varchar(4)")
                .HasMaxLength(4)
                .IsRequired();

            builder.Property(c => c.EmployeeId)
                .HasColumnType("varchar(11)")
                .HasMaxLength(11)
                .IsRequired();

        }
    }
}
