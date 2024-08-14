using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WrapAround.Domain.Students;

namespace WrapAround.Infrastructure.Students;

internal sealed class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.HasKey(student => student.Id);
        builder.Property(student => student.Id)
            .HasConversion(
                id => id.Value,
                value => StudentId.Create(value)
            );

        builder.Property(student => student.FirstName)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(student => student.LastName)
            .HasMaxLength(100)
            .IsRequired();

        //builder.HasOne<Guardian>()
        //    .WithMany()
        //    .HasForeignKey("GuardianId")
        //    .IsRequired();
    }
}
